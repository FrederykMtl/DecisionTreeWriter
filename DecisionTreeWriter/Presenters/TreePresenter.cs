using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataManager;
using DecisionTreeWriter.Resources;
using DTO;
using FileManager;

namespace DecisionTreeWriter.Presenters
{
    public class TreePresenter
    {
        private readonly ToolStripMenuItem _decisionTreeMenu;
        private readonly TabControl _treeDesignerTabControl;
        private readonly Dictionary<string, PanelPresenter> _panelPresenters;
        private readonly INodeListManager _nodeListManager;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="decisionTreeMenu"></param>
        /// <param name="treeDesignerTabControl"></param>
        public TreePresenter(ToolStripMenuItem decisionTreeMenu, TabControl treeDesignerTabControl)
        {
            _decisionTreeMenu = decisionTreeMenu;
            _treeDesignerTabControl = treeDesignerTabControl;
            _panelPresenters = new Dictionary<string, PanelPresenter>();
            _nodeListManager = new NodeListManager(new FileController());
        }

        /// <summary>
        /// Adds a new tab for designing a decision tree
        /// </summary>
        /// <param name="treeName">Name of the new tree</param>
        public void AddTabControl(string treeName)
        {
            var newTab = new TabPage(treeName);

            var presenter = new PanelPresenter(treeName, _nodeListManager);

            newTab.AutoScroll = true;

            _panelPresenters.Add(treeName, presenter);

            newTab.Controls.Add(presenter.GetPanel());

            _treeDesignerTabControl.TabPages.Add(newTab);
            _treeDesignerTabControl.SelectTab(newTab);

            ManageTreeMenuState(presenter);
        }

        /// <summary>
        /// Handles a change of tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void TabChanged(object sender, EventArgs eventArgs)
        {
            TabControl control = (TabControl) sender;

            if(control.SelectedTab != null)
                ManageTreeMenuState(control.SelectedTab);
        }

        /// <summary>
        /// Finds a panel in the dictionary
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private PanelPresenter FindPanelByName(string name)
        {
            if(!_panelPresenters.ContainsKey(name))
                return null;

            return _panelPresenters[name];
        }

        /// <summary>
        /// Evaluates the state of the menu according to the selected tab
        /// </summary>
        /// <param name="tab"></param>
        private void ManageTreeMenuState(TabPage tab)
        {
            if(tab == null)
                return;

            var presenter = FindPanelByName(tab.Text);

            if (presenter != null)
                ManageTreeMenuState(presenter);
        }

        /// <summary>
        /// Evaluates the state of the menu according to the selected tab
        /// </summary>
        /// <param name="presenter"></param>
        private void ManageTreeMenuState(PanelPresenter presenter)
        {
            if(!presenter.HasRoot && !presenter.HasNodes)
                _decisionTreeMenu.DropDownItems[UIResources.AddRoot].Enabled = true;
            else
            {
                _decisionTreeMenu.DropDownItems[UIResources.AddRoot].Enabled = false;
            }

            if (presenter.HasRoot && !presenter.HasNodes)
            {
                _decisionTreeMenu.DropDownItems[UIResources.AddRightNode].Enabled = true;
                _decisionTreeMenu.DropDownItems[UIResources.AddLeftNode].Enabled = true;
                _decisionTreeMenu.DropDownItems[UIResources.AddSubTree].Enabled = true;
            }
            else
            {
                _decisionTreeMenu.DropDownItems[UIResources.AddRightNode].Enabled = false;
                _decisionTreeMenu.DropDownItems[UIResources.AddLeftNode].Enabled = false;
                _decisionTreeMenu.DropDownItems[UIResources.AddSubTree].Enabled = false;
            }
        }

        /// <summary>
        /// Adds a root node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddRootClicked(object sender, EventArgs e)
        {
            var presenter = FindPanelByName(_treeDesignerTabControl.SelectedTab.Text);

            if (presenter == null)
                return;

            presenter.AddRoot();

            ManageTreeMenuState(_treeDesignerTabControl.SelectedTab);
        }

        public void AddLeftNodeClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void AddRightNodeClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SaveTree(string panelName, UserConfigurations configurations)
        {
            var panel = FindPanelByName(panelName);
            panel.SaveTreeToFile(new FileController(), new XmlDocumentBuilder(), configurations);
        }

        public void RemoveCurrentNode()
        {
            var presenter = FindPanelByName(_treeDesignerTabControl.SelectedTab.Text);

            presenter?.RemoveCurrentNode();
        }
    }
}