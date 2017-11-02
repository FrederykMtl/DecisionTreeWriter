using System;
using System.Drawing;
using System.Windows.Forms;
using DataManager;
using DecisionTreeWriter.Resources;
using DTO;

namespace DecisionTreeWriter.UserControl
{
    public partial class VisualRootNode
    {
        public VisualRootNode(int index, VisualNodeBase parent, INodeListManager nodeListManager) : base(index, parent, nodeListManager)
        {
            InitializeComponent();
            Level = 1;
            AssociatedNode = new Node(string.Empty, NodeType.Root);
        }

        protected override void SelectionNodeChanged()
        {
            BackColor = IsSelected ? Color.Aqua : Color.FromArgb(191, 255, 255);
        }

        private void btoAddLeft_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AssociatedNode.Name))
            {
                MessageBox.Show(UIResources.EnterRootNameMessage);
                return;
            }

            // Raise the event
            RaiseAddNodeEvent(false);
            DeactivateLeftNodeButton();
        }

        private void btoAddRight_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AssociatedNode.Name))
            {
                MessageBox.Show(UIResources.EnterRootNameMessage);
                return;
            }

            // Raise the event
            RaiseAddNodeEvent(true);
            DeactivateRightNodeButton();
        }

        protected override void DeactivateLeftNodeButton()
        {
            btoAddLeft.Enabled = false;
        }

        protected override void DeactivateRightNodeButton()
        {
            btoAddRight.Enabled = false;
        }
    }
}
