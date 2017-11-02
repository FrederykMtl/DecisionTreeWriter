using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DataManager;
using DecisionTreeWriter.Managers;
using DecisionTreeWriter.Resources;
using DecisionTreeWriter.UserControl;
using DTO;
using FileManager;
using FileManager.Interfaces;

namespace DecisionTreeWriter.Presenters
{
    public class PanelPresenter
    {
        #region Properties
        private readonly Panel _panel;
        private readonly DecisionTreeDrawingManager _manager;
        private Node _root;

        private VisualNodeBase _selectedNode;

        public bool HasRoot => _root != null;
        public bool HasNodes => _manager.HasNodes;
        public bool HasSelectedNode => _selectedNode != null;

        public Control GetPanel() { return _panel; }
        #endregion

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="managedPanelName"></param>
        /// <param name="nodeListManager"></param>
        public PanelPresenter(string managedPanelName, INodeListManager nodeListManager)
        {
            _panel = new Panel
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                //|AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Name = managedPanelName,
                AutoScroll = false,
                AutoSize = false
            };

            _manager = new DecisionTreeDrawingManager(_panel.Handle, nodeListManager);
            _manager.PanelResizeRequired += _manager_PanelResizeRequired;

            _panel.Click += _panel_Click;
            _panel.Paint += _panel_Paint;
            _panel.Resize += _panel_Resize;
        }

        private void _panel_Resize(object sender, EventArgs e)
        {
            if (!HasRoot)
                return;

            _panel.SuspendLayout();
            _manager.PanelWidth = _panel.Width;

            _manager.RepositionAllNodes(_panel.AutoScrollPosition);
            _manager.RedrawAllRelationshipLines();
            _panel.ResumeLayout();
        }

        /// <summary>
        /// ressizes the panel according to passed parameters
        /// </summary>
        /// <param name="height">height of panel</param>
        /// <param name="width">width of panel</param>
        private void _manager_PanelResizeRequired(int height, int width)
        {
            _panel.SuspendLayout();
            _panel.Dock = DockStyle.None;

            if (_panel.Height != height || _panel.Width != width)
            {
                _panel.MaximumSize = new Size(width, height);
                _panel.Size = new Size(width, height);
            }

            var newPosition = PositionCalculationManager.CalculateScrollPosition(_selectedNode.LeftChild, _panel);
            _panel.HorizontalScroll.Value = newPosition.X;
            _panel.VerticalScroll.Value = newPosition.Y;
            //_panel.AutoScroll = false;
            _panel.ResumeLayout();
        }

        /// <summary>
        /// Handles a click in the panel area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _panel_Click(object sender, EventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;

            if(arg==null)
                return;

            if (arg.Button == MouseButtons.Left)
            {
                _panel.Focus();
                _selectedNode = null;
            }

            if (arg.Button == MouseButtons.Right)
            {
                BuildContextMenu().Show(_panel, new Point(arg.X, arg.Y));
                _panel.ContextMenu = BuildContextMenu();
            }
        }

        /// <summary>
        /// Handles the redraw of the panel
        /// </summary>
        /// <param name="sender">object tha raised the event.</param>
        /// <param name="e">paint event arguments</param>
        private void _panel_Paint(object sender, PaintEventArgs e)
        {            
            _manager.RedrawAllRelationshipLines();
        }

        /// <summary>
        /// Builds the contextual menu
        /// </summary>
        /// <returns></returns>
        private ContextMenu BuildContextMenu()
        {
            ContextMenu cm = new ContextMenu();

            if (!HasRoot)
            {
                MenuItem nodeMenu = new MenuItem("Add &Root");
                nodeMenu.Click += NodeMenu_Click;
                cm.MenuItems.Add(nodeMenu);
            }
            else
            {
                if (!HasSelectedNode)
                    return cm;

                if (_selectedNode.AssociatedNode.RightNode == null)
                {
                    MenuItem rightNodeMenu = new MenuItem("Add &Right Node");
                    rightNodeMenu.Click += RightNodeMenu_Click;
                    cm.MenuItems.Add(rightNodeMenu);
                }

                if (_selectedNode.AssociatedNode.LeftNode != null)
                    return cm;

                MenuItem leftNodeMenu = new MenuItem("Add &Left Node");
                leftNodeMenu.Click += LeftNodeMenu_Click;
                cm.MenuItems.Add(leftNodeMenu);
            }
            return cm;
        }

        /// <summary>
        /// Click on the "add left child node" menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftNodeMenu_Click(object sender, EventArgs e)
        {          
            NodeToAdd_AddNodeEvent(_selectedNode, false);
        }

        /// <summary>
        /// Click on the "add right child node" menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightNodeMenu_Click(object sender, EventArgs e)
        {
            NodeToAdd_AddNodeEvent(_selectedNode, true);
        }

        /// <summary>
        /// Add root from the right click contextual menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeMenu_Click(object sender, EventArgs e)
        {
            AddRoot();
        }

        /// <summary>
        /// Adds a UI node to the panel.
        /// </summary>
        public void AddRoot()
        {
            if (_panel.Controls.Count == 0)
            {
                var nodeToAdd = _manager.CreateRoot(_panel.Width);
                nodeToAdd.AddNodeEvent += NodeToAdd_AddNodeEvent;
                nodeToAdd.NodeSelectedEvent += NodeToAddOnNodeSelectedEvent;

                _panel.Controls.Add(nodeToAdd);
                _root = nodeToAdd.AssociatedNode;
            }
            else
            {
                MessageBox.Show(UIResources.TreeHasRootMessage);
            }
        }

        private void NodeToAddOnNodeSelectedEvent(VisualNodeBase selectedNode)
        {
            _selectedNode = selectedNode;
        }

        /// <summary>
        /// Manages the request to add a node
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="isRightNode"></param>
        private void NodeToAdd_AddNodeEvent(VisualNodeBase parent, bool isRightNode)
        {
            if (HasRoot)
            {
                var nodeToAdd = _manager.CreateNode(parent, isRightNode, _panel.AutoScrollPosition);
                nodeToAdd.AddNodeEvent += NodeToAdd_AddNodeEvent;
                nodeToAdd.NodeSelectedEvent += NodeToAddOnNodeSelectedEvent;

                _panel.Controls.Add(nodeToAdd);
            }
            else
            {
                MessageBox.Show(UIResources.AddRootMessage);
            }
        }

        //TODO
        /// <summary>
        /// Adds a SubTree node.
        /// </summary>
        /// <param name="treeName">name of the node</param>
        public void AddSubTree(string treeName)
        {
            //_nodes.Add(new VisualRootNode(treeName));
        }

        
        public void SaveTreeToFile(IFileController fileController, IXmlDocumentBuilder builder)
        {
            var document = builder.Build(_root, _panel.Name);

            fileController.SaveXmlFileContent(_panel.Name, document, "XML");
        }
    }
}
