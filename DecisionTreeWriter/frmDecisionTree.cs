using System;
using System.Windows.Forms;
using DecisionTreeWriter.Presenters;
using DecisionTreeWriter.Resources;
using DecisionTreeWriter.UserControl;

namespace DecisionTreeWriter
{
    /// <summary>
    /// This is the main form. It has the responsability of displaying the container form
    /// and managing dialogs
    /// The rest is handled by the presenter.
    /// </summary>
    public partial class FrmDecisionTree : Form
    {
        private readonly TreePresenter _presenter;

        public FrmDecisionTree()
        {
            InitializeComponent();
            _presenter = new TreePresenter(tsTreeMenu, tcTreeDesigner);
            tcTreeDesigner.SelectedIndexChanged += _presenter.TabChanged;
            addRootToolStripMenuItem.Click += _presenter.AddRootClicked;
            addLeftNodeToolStripMenuItem.Click += _presenter.AddLeftNodeClicked;
            addRightNodeToolStripMenuItem.Click += _presenter.AddRightNodeClicked;
        }

        /// <summary>
        /// Creates a new decision tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createNewTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FrmAddTree();
            dialog.ShowDialog(this);

            var treeName = dialog.NewTreeName;

            if (string.IsNullOrWhiteSpace(treeName))
                return;

            _presenter.AddTabControl(treeName);
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var panel = tcTreeDesigner.SelectedTab.Controls[0];

            if (panel.Controls.Count != 0)
                return;

            MessageBox.Show(UIResources.AddRootMessage);
        }

        // TODO
        private void addSubTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //var panel = tcTreeDesigner.SelectedTab.Controls[0];

            //if (panel.Controls.Count == 0)
            //{
            //    MessageBox.Show(UIResources.AddRootMessage);
            //    return;
            //}

            //var nodeToAdd = new VisualSubTree() {Left = 250};
            //panel.Controls.Add(nodeToAdd);
        }
    }
}
