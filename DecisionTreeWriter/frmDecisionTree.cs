using System;
using System.Windows.Forms;
using DecisionTreeWriter.Presenters;
using DecisionTreeWriter.Resources;
using DTO;

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
        private readonly UserConfigurations _configurations;

        // TODO
        public FrmDecisionTree()
        {
            InitializeComponent();
            _presenter = new TreePresenter(tsTreeMenu, tcTreeDesigner);

            tcTreeDesigner.SelectedIndexChanged += _presenter.TabChanged;
            addRootToolStripMenuItem.Click += _presenter.AddRootClicked;
            addLeftNodeToolStripMenuItem.Click += _presenter.AddLeftNodeClicked;
            addRightNodeToolStripMenuItem.Click += _presenter.AddRightNodeClicked;

            _configurations = new UserConfigurations
            {
                Language = SelectLanguage()
            };
        }

        private Languages SelectLanguage()
        {
            if(CSharpOption.Checked)
                return Languages.CSharp;

            if(CppOption.Checked)
                return Languages.CPlusPlus;

            if(JavaOption.Checked)
                return Languages.Java;

            if(PythonOption.Checked)
                return Languages.Python;

            return Languages.NoCodeGeneration;
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

        // TODO
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

        /// <summary>
        /// Saves the content of the current tree
        /// </summary>
        /// <param name="sender">object that called the method</param>
        /// <param name="e">event arguments</param>
        private void saveCurrentTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tcTreeDesigner.SelectedTab == null)
            {
                MessageBox.Show(@"There are no currently selected tab");
                return;
            }

            string currentTabName = tcTreeDesigner.SelectedTab.Controls[0].Name;
            _presenter.SaveTree(currentTabName, _configurations);
        }

        /// <summary>
        /// Closes all tabs
        /// </summary>
        /// <param name="sender">object that called the method</param>
        /// <param name="e">event arguments</param>
        private void removeAllTreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"This will close all current tabs and lose any unsaved changes." + Environment.NewLine + 
                                        @"Are you sure you want to proceed?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                tcTreeDesigner.TabPages.Clear();   
            }
        }

        /// <summary>
        /// closes the current tab
        /// </summary>
        /// <param name="sender">object that called the method</param>
        /// <param name="e">event arguments</param>
        private void removeCurrentTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"This will close the current tab and lose any unsaved changes." + Environment.NewLine +
                            @"Are you sure you want to proceed?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                tcTreeDesigner.TabPages.Remove(tcTreeDesigner.SelectedTab);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openExistingTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"TODO");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"This will remove the current node and any child node linked to it." + Environment.NewLine +
                @"Are you sure you want to proceed?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                _presenter.RemoveCurrentNode();
            }
        }
    }
}
