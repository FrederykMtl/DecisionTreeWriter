using System;
using System.Drawing;
using System.Windows.Forms;
using DataManager;
using DecisionTreeWriter.Resources;
using DTO;

namespace DecisionTreeWriter.UserControl
{
    public partial class VisualNode
    {
        /// <summary>
        /// Default Xtor
        /// </summary>
        public VisualNode(int index, VisualNodeBase parent, INodeListManager nodeListManager) :base(index, parent, nodeListManager)
        {
            InitializeComponent();
            AssociatedNode = new Node(string.Empty, NodeType.Node);
            Level = parent.Level + 1;
        }

        /// <summary>
        /// Node is selected or uselected.
        /// </summary>
        protected override void SelectionNodeChanged()
        {          
            BackColor = IsSelected ? Color.FromArgb(63, 238, 56) : Color.Green;
            RaiseNodeSelectedEvent(this);
        }

        /// <summary>
        /// Handles all changes to the test value textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValue.Text))
                AssociatedNode.TestValue = null;

            if (!txtValue.Text.IsNumeric())
            {
                MessageBox.Show(UIResources.ValueIsNotNumericMessage);
                txtValue.Focus();
                return;
            }

            AssociatedNode.TestValue = int.Parse(txtValue.Text);
        }

        private void btoAddLeft_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AssociatedNode.Name))
            {
                MessageBox.Show(UIResources.EnterNodeNameMessage);
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
                MessageBox.Show(UIResources.EnterNodeNameMessage);
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
