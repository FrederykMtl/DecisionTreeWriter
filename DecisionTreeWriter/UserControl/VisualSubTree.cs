using System.Drawing;
using DataManager;
using DTO;

namespace DecisionTreeWriter.UserControl
{
    public partial class VisualSubTree
    {
        public VisualSubTree(int index, VisualNodeBase parent, INodeListManager nodeListManager) : base(index, parent, nodeListManager)
        {
            InitializeComponent();
            AssociatedNode = new Node(string.Empty, NodeType.SubTree);
        }

        protected override void SelectionNodeChanged()
        {
            BackColor = IsSelected ? Color.FromArgb(234, 173, 113) : Color.Peru;
        }
    }
}
