using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DecisionTreeWriter.UserControl;

namespace DecisionTreeWriter.Managers
{
    public static class PositionCalculationManager
    {
        public const int TopBuffer = 10;
        public const int BottomBuffer = 100;
        public const int LeftBuffer = 20;
        public const int RightBuffer = 20;
        public const int MinSpaceBetweenNodes = 20;

        /// <summary>
        /// Panel is drawn in a grid pattern and this establishes where  node will be
        /// </summary>
        /// <param name="parent">Parent node of the node</param>
        /// <param name="isRightNode">Whether it's on the right or left</param>
        /// <returns>the index</returns>
        public static int CalculateIndex(VisualNodeBase parent, bool isRightNode)
        {
            var modifier = !isRightNode ? 1 : 2;

            return (parent.Index - 1) * 2 + modifier;
        }

        /// <summary>
        /// Calculates the left position of the root node
        /// </summary>
        /// <param name="panelWidth">width of the containing panel</param>
        /// <param name="rootNodeWidth">Width of the root node panel</param>
        /// <returns>Left position (X)</returns>
        public static int CalculateRootLeftPosition(int panelWidth, int rootNodeWidth)
        {
            return panelWidth / 2 - (rootNodeWidth / 2);
        }

        /// <summary>
        /// Calculates the maximum number of nodes on a level
        /// </summary>
        /// <param name="level">level to calculate for</param>
        /// <returns></returns>
        public static double MaxNumberOfNodes(int level)
        {
            return Math.Pow(2, level - 1);
        }

        /// <summary>
        /// Calculates where the left of the node should be
        /// </summary>
        /// <param name="panelWidth">width of the containing panel</param>
        /// <param name="nodeLevel">The level, or row, of the panel</param>
        /// <param name="nodeIndex">The index of the ppanel in the row</param>
        /// <param name="nodeWidth">The base width as reference point</param>
        /// <param name="panelAutoScrollPositionX">The offset of the scrolling of the panel</param>
        /// <returns>The calculated left position</returns>
        public static int CalculateLeftPosition(int panelWidth, int nodeLevel, int nodeIndex, int nodeWidth, int panelAutoScrollPositionX)
        {
            // divides the panel into columns. Node will be in the middle of these columns.
            int columnWidth = (panelWidth - LeftBuffer - RightBuffer) / (int)MaxNumberOfNodes(nodeLevel);

            return columnWidth / 2 + columnWidth * (nodeIndex -1) - nodeWidth / 2 + panelAutoScrollPositionX;
        }

        /// <summary>
        /// Calculates where the top of the node should be
        /// </summary>
        /// <param name="level">The level, or row, of the node</param>
        /// <param name="rootNodeHeight">The height of the root node, used as reference</param>
        /// <param name="panelAutoScrollPositionY"></param>
        /// <returns></returns>
        public static int CalculateTopPosition(int level, int rootNodeHeight, int panelAutoScrollPositionY)
        {
            Debug.Write("Level: " + level + "  and height : " + ((level - 1) * rootNodeHeight + (level - 1) * rootNodeHeight / 2 + TopBuffer) + Environment.NewLine);
            return (level -1) * rootNodeHeight + (level - 1) * rootNodeHeight /2 + TopBuffer + panelAutoScrollPositionY;
        }

        /// <summary>
        /// Calculate new panel width 
        /// </summary>
        /// <param name="maxNumberOfNodes">maximum number of nodes on a row</param>
        /// <param name="rootNodeWidth">the width of the root node</param>
        /// <returns></returns>
        public static int CalculatePanelWidth(double maxNumberOfNodes, int rootNodeWidth)
        {
            return (int)(maxNumberOfNodes * rootNodeWidth + (maxNumberOfNodes - 1) * MinSpaceBetweenNodes + LeftBuffer + RightBuffer);
        }

        /// <summary>
        /// Calculate new panel height
        /// </summary>
        /// <param name="level">number of levels of nodes</param>
        /// <param name="rootNodeHeight"></param>
        /// <returns></returns>
        public static int CalculatePanelHeight(int level, int rootNodeHeight)
        {
            return level * rootNodeHeight + (level - 1) * rootNodeHeight + TopBuffer + BottomBuffer;
        }

        /// <summary>
        /// Re-focuses the panel when a node is added and the panel is resized
        /// </summary>
        /// <param name="selectedNode"></param>
        /// <param name="panel"></param>
        /// <returns></returns>
        internal static Point CalculateScrollPosition(VisualNodeBase selectedNode, Panel panel)
        {
            if(selectedNode == null)
                return new Point(0, 0);

            int x = (int)((selectedNode.Left + selectedNode.Width / 2) / (decimal)panel.Width * 100);
            int y = 100;

            return new Point(x, y);
        }
    }
}
