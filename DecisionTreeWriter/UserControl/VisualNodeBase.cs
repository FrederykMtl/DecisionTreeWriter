using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataManager;
using DTO;

namespace DecisionTreeWriter.UserControl
{
    public partial class VisualNodeBase : System.Windows.Forms.UserControl
    {
        public bool IsSelected { get; set; }

        public Node AssociatedNode { get; protected set; }

        private readonly List<VisualNodeBase> _parents;
        private INodeListManager _nodeListManager;

        public VisualNodeBase LeftChild;
        public VisualNodeBase RightChild;

        public int Level { get; protected set; }
        public int Index { get; protected set; }

        public VisualNodeBase(int index, VisualNodeBase parent, INodeListManager nodeListManager)
        {
            InitializeComponent();

            Index = index;
            TabStop = false;

            _nodeListManager = nodeListManager;
            cboName.Leave += CboName_Leave;
            cboName.DataSource = nodeListManager.GetExistingNodesList();

            _parents = new List<VisualNodeBase>();

            if (parent != null)
                _parents.Add(parent);
        }

        /// <summary>
        /// Add an additional parent to the node
        /// </summary>
        /// <param name="parent">the parent reference</param>
        public void AddParent(VisualNodeBase parent)
        {
            _parents.Add(parent);
        }

        public bool HasParents()
        {
            return _parents.Any();
        }

        public List<VisualNodeBase> GetParents()
        {
            return _parents;
        }

        /// <summary>
        /// the leave event for the combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboName_Leave(object sender, EventArgs e)
        {
            AssociatedNode.Name = cboName.Text;
            _nodeListManager.AddNewNode(cboName.Text);
        }

        public string GetName()
        {
            return cboName.Text;
        }

        private void VisualNode_Leave(object sender, EventArgs e)
        {
            IsSelected = false;
            SelectionNodeChanged();
        }

        private void VisualNode_Enter(object sender, EventArgs e)
        {
            IsSelected = true;
            SelectionNodeChanged();
        }

        protected virtual void SelectionNodeChanged()
        {
            throw new NotImplementedException();
        }

        public delegate void AddNodeEventHandler(VisualNodeBase sender, bool isRightNode);
        public delegate void NodeSelectedEventHandler(VisualNodeBase selectedNode);
        // Declare the event.
        public event AddNodeEventHandler AddNodeEvent;
        public event NodeSelectedEventHandler NodeSelectedEvent;
         
        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaiseAddNodeEvent(bool isRightNode)
        {
            // Raise the event
            AddNodeEvent?.Invoke(this, isRightNode);
        }

        protected virtual void RaiseNodeSelectedEvent(VisualNodeBase node)
        {
            NodeSelectedEvent?.Invoke(node);
        }

        private void VisualNodeBase_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu = BuildContextMenu();
            }
        }

        private ContextMenu BuildContextMenu()
        {
            ContextMenu cm = new ContextMenu();

            if (AssociatedNode.RightNode == null)
            {
                MenuItem rightNodeMenu = new MenuItem("Add &Right Node");
                rightNodeMenu.Click += RightNodeMenu_Click;
                cm.MenuItems.Add(rightNodeMenu);
            }

            if (AssociatedNode.LeftNode == null)
            {
                MenuItem leftNodeMenu = new MenuItem("Add &Left Node");
                leftNodeMenu.Click += LeftNodeMenu_Click; 
                cm.MenuItems.Add(leftNodeMenu);
            }

            return cm;
        }

        private void LeftNodeMenu_Click(object sender, EventArgs e)
        {
            RaiseAddNodeEvent(false);
            DeactivateLeftNodeButton();
        }

        private void RightNodeMenu_Click(object sender, EventArgs e)
        {
            RaiseAddNodeEvent(true);
        }

        protected virtual void DeactivateLeftNodeButton()
        {
            throw new NotImplementedException();
        }

        protected virtual void DeactivateRightNodeButton()
        {
            throw new NotImplementedException();
        }
    }
}
