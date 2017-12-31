using System;
using System.Drawing;
using DataManager;
using DecisionTreeWriter.UserControl;

namespace DecisionTreeWriter.Managers
{
    internal class DecisionTreeDrawingManager
    {
        #region properties and variables
        private int _maxLevel;

        public int PanelWidth { get; set; }

        private VisualRootNode _root;
        private readonly INodeListManager _nodeListManager;

        // private int _panelWidth;
        private readonly IntPtr _panelHandle;
        public bool HasNodes => _root?.LeftChild != null || _root?.RightChild != null;
        #endregion

        #region Events
        // The handler to the event raised when the panel needs resizing
        public delegate void PanelResizeRequiredEventHandler(int height, int width);
        // The event raised when the panel needs resizing
        public event PanelResizeRequiredEventHandler PanelResizeRequired;
        #endregion

        /// <summary>
        /// Mandatory ctor
        /// </summary>
        /// <param name="panelHandle">Handle of the panel that iss managed</param>
        /// <param name="nodeListManager">an instance of NodeListManager</param>
        public DecisionTreeDrawingManager(IntPtr panelHandle, INodeListManager nodeListManager)
        {
            _panelHandle = panelHandle;
            _nodeListManager = nodeListManager;
        }

        /// <summary>
        /// Addes the root node to the panel
        /// </summary>
        /// <param name="panelWidth">current width of the panel</param>
        /// <returns></returns>
        public VisualRootNode CreateRoot(int panelWidth)
        {
            _root = new VisualRootNode(1, null, _nodeListManager)
            {
                Top = PositionCalculationManager.TopBuffer 
            };

            PanelWidth = panelWidth;
            _root.Left = PositionCalculationManager.CalculateRootLeftPosition(panelWidth, _root.Width);
            _maxLevel = 1;

            return _root;
        }

        /// <summary>
        /// Creates a node leaf
        /// </summary>
        /// <param name="parent">parent node</param>
        /// <param name="isRightNode">Is a node on the right</param>
        /// <param name="panelAutoScrollPosition"></param>
        /// <returns></returns>
        public VisualNode CreateNode(VisualNodeBase parent, bool isRightNode, Point panelAutoScrollPosition)
        {
            // check if the panel needs to be adjusted for the new rows
            if (_maxLevel < parent.Level + 1)
            {   
                _maxLevel = parent.Level + 1;

                if (_maxLevel > 3)
                {
                    EstablishNewPanelSize(_maxLevel);
                    RepositionAllNodes(panelAutoScrollPosition);
                    RedrawAllRelationshipLines();
                }
            }

            int newNodeIndex = PositionCalculationManager.CalculateIndex(parent, isRightNode);

            var node = new VisualNode(newNodeIndex, parent, _nodeListManager)
            {
                Top = PositionCalculationManager.CalculateTopPosition(parent.Level + 1, _root.Height, panelAutoScrollPosition.Y),
                Left = PositionCalculationManager.CalculateLeftPosition(PanelWidth, parent.Level + 1, newNodeIndex, parent.Width, panelAutoScrollPosition.X)
            };

            if (isRightNode)
                parent.RightChild = node;
            else       
                parent.LeftChild = node;

            DrawRelationshipLine(parent, node);

            return node;
        }

        /// <summary>
        /// Reorganizes all the nodes in the panel to fit added rows
        /// This does NOT redraw relationship lines
        /// </summary>
        /// <param name="panelAutoScrollPosition"></param>
        public void RepositionAllNodes(Point panelAutoScrollPosition)
        {
            if (_root == null)
                return;

            _root.Left = PositionCalculationManager.CalculateRootLeftPosition(PanelWidth, _root.Width);

            if(_root.LeftChild != null)
                RepositionNode(_root.LeftChild, panelAutoScrollPosition);

            if(_root.RightChild != null)
                RepositionNode(_root.RightChild, panelAutoScrollPosition);
        }

        /// <summary>
        /// Recursive algorithmn that repositions a node and its children
        /// </summary>
        /// <param name="node">Node to redraw / reposition</param>
        /// <param name="panelAutoScrollPosition"></param>
        private void RepositionNode(VisualNodeBase node, Point panelAutoScrollPosition)
        {
            node.Top = PositionCalculationManager.CalculateTopPosition(node.Level, _root.Height, panelAutoScrollPosition.Y);
            node.Left = PositionCalculationManager.CalculateLeftPosition(PanelWidth, node.Level, node.Index, node.Width, panelAutoScrollPosition.X);

            if (node.LeftChild != null)
            {
                RepositionNode(node.LeftChild, panelAutoScrollPosition);
            }

            if (node.RightChild == null)
                return;

            RepositionNode(node.RightChild, panelAutoScrollPosition);
        }

        /// <summary>
        /// Calls the manager to recalculate the new panel size and notifies subscribers
        /// </summary>
        /// <param name="level">Max level of nodes</param>
        private void EstablishNewPanelSize(int level)
        {
            var maxNumberOfNodes = PositionCalculationManager.MaxNumberOfNodes(level);

            PanelWidth = PositionCalculationManager.CalculatePanelWidth(maxNumberOfNodes, _root.Width);

            var height = PositionCalculationManager.CalculatePanelHeight(level - 1, _root.Height);

            RaisePanelResizeRequiredEvent(height, PanelWidth);
        }

        public void RedrawAllRelationshipLines()
        {
            if (_root == null)
                return;

            if (_root.LeftChild != null)
            {
                RedrawRelationshipLine(_root, _root.LeftChild);
            }

            if (_root.RightChild != null)
            {
                RedrawRelationshipLine(_root, _root.RightChild);
            }
        }

        /// <summary>
        /// Redraws all the nodes
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        private void RedrawRelationshipLine(VisualNodeBase parent, VisualNodeBase child)
        {
            DrawRelationshipLine(parent, child);
            
            if (child.LeftChild != null)
            {
                RedrawRelationshipLine(child, child.LeftChild);
            }

            if (child.RightChild != null)
            {
                RedrawRelationshipLine(child, child.RightChild);
            }
        }

        /// <summary>
        /// Draws a relationship line between parent and child
        /// </summary>
        /// <param name="parent">parent node</param>
        /// <param name="child">child node</param>
        private void DrawRelationshipLine(VisualNodeBase parent, VisualNodeBase child)
        {
            int x1 = parent.Left + parent.Width / 2;
            int y1 = parent.Top + parent.Height;
            int x2 = child.Left + child.Width / 2;
            int y2 = child.Top;

            using (var pen = new Pen(Color.Black))
            {
                Graphics graphics = Graphics.FromHwnd(_panelHandle);
                graphics.DrawBezier(pen, x1, y1, x1, y2, x2, y1, x2, y2);
            }
        }

        /// <summary>
        /// This event is raised to tell the panel it needs to resize itself
        /// </summary>
        /// <param name="height">height of panel</param>
        /// <param name="width">width of panel</param>
        private void RaisePanelResizeRequiredEvent(int height, int width)
        {
            // Raise the event
            PanelResizeRequired?.Invoke(height, width);
        }
    }
}