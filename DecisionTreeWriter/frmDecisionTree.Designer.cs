using System.Windows.Forms;
using DecisionTreeWriter.Resources;

namespace DecisionTreeWriter
{
    partial class FrmDecisionTree
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuDecisionTree = new System.Windows.Forms.MenuStrip();
            this.tsFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openExistingTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.removeCurrentTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllTreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTreeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRightNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLeftNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSubTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.removeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classLanguageGenerationOption = new System.Windows.Forms.ToolStripMenuItem();
            this.CSharpOption = new System.Windows.Forms.ToolStripMenuItem();
            this.CppOption = new System.Windows.Forms.ToolStripMenuItem();
            this.JavaOption = new System.Windows.Forms.ToolStripMenuItem();
            this.PythonOption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcTreeDesigner = new System.Windows.Forms.TabControl();
            this.noCodeGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDecisionTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuDecisionTree
            // 
            this.mnuDecisionTree.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuDecisionTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFileMenu,
            this.tsTreeMenu,
            this.optionsToolStripMenuItem});
            this.mnuDecisionTree.Location = new System.Drawing.Point(0, 0);
            this.mnuDecisionTree.Name = "mnuDecisionTree";
            this.mnuDecisionTree.Size = new System.Drawing.Size(1219, 33);
            this.mnuDecisionTree.TabIndex = 1;
            this.mnuDecisionTree.Text = "menuStrip1";
            // 
            // tsFileMenu
            // 
            this.tsFileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openExistingTreeToolStripMenuItem,
            this.saveCurrentTreeToolStripMenuItem,
            this.toolStripSeparator3,
            this.removeCurrentTreeToolStripMenuItem,
            this.removeAllTreesToolStripMenuItem});
            this.tsFileMenu.Name = "tsFileMenu";
            this.tsFileMenu.Size = new System.Drawing.Size(50, 29);
            this.tsFileMenu.Text = "&File";
            // 
            // openExistingTreeToolStripMenuItem
            // 
            this.openExistingTreeToolStripMenuItem.Name = "openExistingTreeToolStripMenuItem";
            this.openExistingTreeToolStripMenuItem.Size = new System.Drawing.Size(241, 30);
            this.openExistingTreeToolStripMenuItem.Text = "&Open Existing Tree";
            this.openExistingTreeToolStripMenuItem.Click += new System.EventHandler(this.openExistingTreeToolStripMenuItem_Click);
            // 
            // saveCurrentTreeToolStripMenuItem
            // 
            this.saveCurrentTreeToolStripMenuItem.Name = "saveCurrentTreeToolStripMenuItem";
            this.saveCurrentTreeToolStripMenuItem.Size = new System.Drawing.Size(241, 30);
            this.saveCurrentTreeToolStripMenuItem.Text = "&Save Current Tree";
            this.saveCurrentTreeToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentTreeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(238, 6);
            // 
            // removeCurrentTreeToolStripMenuItem
            // 
            this.removeCurrentTreeToolStripMenuItem.Name = "removeCurrentTreeToolStripMenuItem";
            this.removeCurrentTreeToolStripMenuItem.Size = new System.Drawing.Size(241, 30);
            this.removeCurrentTreeToolStripMenuItem.Text = "&Close Current Tab";
            this.removeCurrentTreeToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentTreeToolStripMenuItem_Click);
            // 
            // removeAllTreesToolStripMenuItem
            // 
            this.removeAllTreesToolStripMenuItem.Name = "removeAllTreesToolStripMenuItem";
            this.removeAllTreesToolStripMenuItem.Size = new System.Drawing.Size(241, 30);
            this.removeAllTreesToolStripMenuItem.Text = "Close &All Tabs";
            this.removeAllTreesToolStripMenuItem.Click += new System.EventHandler(this.removeAllTreesToolStripMenuItem_Click);
            // 
            // tsTreeMenu
            // 
            this.tsTreeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewTreeToolStripMenuItem,
            this.toolStripSeparator2,
            this.addRootToolStripMenuItem,
            this.addRightNodeToolStripMenuItem,
            this.addLeftNodeToolStripMenuItem,
            this.addSubTreeToolStripMenuItem,
            this.toolStripSeparator4,
            this.removeNodeToolStripMenuItem});
            this.tsTreeMenu.Name = "tsTreeMenu";
            this.tsTreeMenu.Size = new System.Drawing.Size(55, 29);
            this.tsTreeMenu.Text = "&Tree";
            // 
            // createNewTreeToolStripMenuItem
            // 
            this.createNewTreeToolStripMenuItem.Name = "createNewTreeToolStripMenuItem";
            this.createNewTreeToolStripMenuItem.Size = new System.Drawing.Size(226, 30);
            this.createNewTreeToolStripMenuItem.Text = "&Create New Tree";
            this.createNewTreeToolStripMenuItem.Click += new System.EventHandler(this.createNewTreeToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // addRootToolStripMenuItem
            // 
            this.addRootToolStripMenuItem.Enabled = false;
            this.addRootToolStripMenuItem.Name = "addRootToolStripMenuItem";
            this.addRootToolStripMenuItem.Size = new System.Drawing.Size(226, 30);
            this.addRootToolStripMenuItem.Text = "Add &Root";
            // 
            // addRightNodeToolStripMenuItem
            // 
            this.addRightNodeToolStripMenuItem.Enabled = false;
            this.addRightNodeToolStripMenuItem.Name = "addRightNodeToolStripMenuItem";
            this.addRightNodeToolStripMenuItem.Size = new System.Drawing.Size(226, 30);
            this.addRightNodeToolStripMenuItem.Text = "Add Right &Node";
            this.addRightNodeToolStripMenuItem.Click += new System.EventHandler(this.addNodeToolStripMenuItem_Click);
            // 
            // addLeftNodeToolStripMenuItem
            // 
            this.addLeftNodeToolStripMenuItem.Enabled = false;
            this.addLeftNodeToolStripMenuItem.Name = "addLeftNodeToolStripMenuItem";
            this.addLeftNodeToolStripMenuItem.Size = new System.Drawing.Size(226, 30);
            this.addLeftNodeToolStripMenuItem.Text = "Add &Left Node";
            // 
            // addSubTreeToolStripMenuItem
            // 
            this.addSubTreeToolStripMenuItem.Enabled = false;
            this.addSubTreeToolStripMenuItem.Name = "addSubTreeToolStripMenuItem";
            this.addSubTreeToolStripMenuItem.Size = new System.Drawing.Size(226, 30);
            this.addSubTreeToolStripMenuItem.Text = "Add &SubTree";
            this.addSubTreeToolStripMenuItem.Click += new System.EventHandler(this.addSubTreeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(223, 6);
            // 
            // removeNodeToolStripMenuItem
            // 
            this.removeNodeToolStripMenuItem.Enabled = false;
            this.removeNodeToolStripMenuItem.Name = "removeNodeToolStripMenuItem";
            this.removeNodeToolStripMenuItem.Size = new System.Drawing.Size(226, 30);
            this.removeNodeToolStripMenuItem.Text = "Re&move Node";
            this.removeNodeToolStripMenuItem.Click += new System.EventHandler(this.removeNodeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classLanguageGenerationOption,
            this.toolStripSeparator1,
            this.generateXMLToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(110, 29);
            this.optionsToolStripMenuItem.Text = "&Generation";
            // 
            // classLanguageGenerationOption
            // 
            this.classLanguageGenerationOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CSharpOption,
            this.CppOption,
            this.JavaOption,
            this.PythonOption,
            this.noCodeGenerationToolStripMenuItem});
            this.classLanguageGenerationOption.Name = "classLanguageGenerationOption";
            this.classLanguageGenerationOption.Size = new System.Drawing.Size(214, 30);
            this.classLanguageGenerationOption.Text = "&Class language";
            // 
            // CSharpOption
            // 
            this.CSharpOption.Checked = true;
            this.CSharpOption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CSharpOption.Name = "CSharpOption";
            this.CSharpOption.Size = new System.Drawing.Size(254, 30);
            this.CSharpOption.Text = "C#";
            // 
            // CppOption
            // 
            this.CppOption.Name = "CppOption";
            this.CppOption.Size = new System.Drawing.Size(254, 30);
            this.CppOption.Text = "C++";
            // 
            // JavaOption
            // 
            this.JavaOption.Name = "JavaOption";
            this.JavaOption.Size = new System.Drawing.Size(254, 30);
            this.JavaOption.Text = "Java";
            // 
            // PythonOption
            // 
            this.PythonOption.Name = "PythonOption";
            this.PythonOption.Size = new System.Drawing.Size(254, 30);
            this.PythonOption.Text = "Python";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // generateXMLToolStripMenuItem
            // 
            this.generateXMLToolStripMenuItem.Name = "generateXMLToolStripMenuItem";
            this.generateXMLToolStripMenuItem.Size = new System.Drawing.Size(214, 30);
            this.generateXMLToolStripMenuItem.Text = "&Options";
            // 
            // tcTreeDesigner
            // 
            this.tcTreeDesigner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcTreeDesigner.Location = new System.Drawing.Point(12, 36);
            this.tcTreeDesigner.Name = "tcTreeDesigner";
            this.tcTreeDesigner.SelectedIndex = 0;
            this.tcTreeDesigner.Size = new System.Drawing.Size(1207, 544);
            this.tcTreeDesigner.TabIndex = 2;
            // 
            // noCodeGenerationToolStripMenuItem
            // 
            this.noCodeGenerationToolStripMenuItem.Name = "noCodeGenerationToolStripMenuItem";
            this.noCodeGenerationToolStripMenuItem.Size = new System.Drawing.Size(254, 30);
            this.noCodeGenerationToolStripMenuItem.Text = "No code generation";
            // 
            // FrmDecisionTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 581);
            this.Controls.Add(this.tcTreeDesigner);
            this.Controls.Add(this.mnuDecisionTree);
            this.MainMenuStrip = this.mnuDecisionTree;
            this.Name = "FrmDecisionTree";
            this.Text = "Decision Tree Writer";
            this.mnuDecisionTree.ResumeLayout(false);
            this.mnuDecisionTree.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuDecisionTree;
        private System.Windows.Forms.ToolStripMenuItem tsFileMenu;
        private System.Windows.Forms.ToolStripMenuItem tsTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem addRootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRightNodeToolStripMenuItem;
        private System.Windows.Forms.TabControl tcTreeDesigner;
        private System.Windows.Forms.ToolStripMenuItem addSubTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openExistingTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllTreesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem classLanguageGenerationOption;
        private ToolStripMenuItem CSharpOption;
        private ToolStripMenuItem CppOption;
        private ToolStripMenuItem JavaOption;
        private ToolStripMenuItem generateXMLToolStripMenuItem;
        private ToolStripMenuItem addLeftNodeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem removeNodeToolStripMenuItem;
        private ToolStripMenuItem PythonOption;
        private ToolStripMenuItem noCodeGenerationToolStripMenuItem;
    }
}