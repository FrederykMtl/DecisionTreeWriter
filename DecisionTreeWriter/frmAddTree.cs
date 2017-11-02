using System;
using System.Windows.Forms;

namespace DecisionTreeWriter
{
    public partial class FrmAddTree : Form
    {
        public string NewTreeName { get; set; }

        public FrmAddTree()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewTree.Text))
            {
                MessageBox.Show(this, @"A tree name is required", @"Required field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                NewTreeName = txtNewTree.Text;
                Close();                
            }

        }
    }
}
