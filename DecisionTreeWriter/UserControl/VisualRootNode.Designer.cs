namespace DecisionTreeWriter.UserControl
{
    partial class VisualRootNode : VisualNodeBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btoAddRight = new System.Windows.Forms.Button();
            this.btoAddLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btoAddRight
            // 
            this.btoAddRight.Location = new System.Drawing.Point(169, 152);
            this.btoAddRight.Name = "btoAddRight";
            this.btoAddRight.Size = new System.Drawing.Size(147, 36);
            this.btoAddRight.TabIndex = 11;
            this.btoAddRight.Text = "Add &Right Branch";
            this.btoAddRight.UseVisualStyleBackColor = true;
            this.btoAddRight.Click += new System.EventHandler(this.btoAddRight_Click);
            // 
            // btoAddLeft
            // 
            this.btoAddLeft.Location = new System.Drawing.Point(15, 152);
            this.btoAddLeft.Name = "btoAddLeft";
            this.btoAddLeft.Size = new System.Drawing.Size(148, 36);
            this.btoAddLeft.TabIndex = 10;
            this.btoAddLeft.Text = "Add &Left Branch";
            this.btoAddLeft.UseVisualStyleBackColor = true;
            this.btoAddLeft.Click += new System.EventHandler(this.btoAddLeft_Click);
            // 
            // VisualRootNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.BackColor = System.Drawing.Color.Aqua;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this.btoAddRight);
            this.Controls.Add(this.btoAddLeft);
            this.Name = "VisualRootNode";
            this.Size = new System.Drawing.Size(332, 212);
            this.Controls.SetChildIndex(this.btoAddLeft, 0);
            this.Controls.SetChildIndex(this.btoAddRight, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btoAddRight;
        private System.Windows.Forms.Button btoAddLeft;
    }
}
