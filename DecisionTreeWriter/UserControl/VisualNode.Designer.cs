namespace DecisionTreeWriter.UserControl
{
    partial class VisualNode : VisualNodeBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btoAddRight = new System.Windows.Forms.Button();
            this.btoAddLeft = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btoAddRight
            // 
            this.btoAddRight.Location = new System.Drawing.Point(169, 151);
            this.btoAddRight.Name = "btoAddRight";
            this.btoAddRight.Size = new System.Drawing.Size(155, 36);
            this.btoAddRight.TabIndex = 9;
            this.btoAddRight.Text = "Add &Right Branch";
            this.btoAddRight.UseVisualStyleBackColor = true;
            this.btoAddRight.Click += new System.EventHandler(this.btoAddRight_Click);
            // 
            // btoAddLeft
            // 
            this.btoAddLeft.Location = new System.Drawing.Point(15, 151);
            this.btoAddLeft.Name = "btoAddLeft";
            this.btoAddLeft.Size = new System.Drawing.Size(155, 36);
            this.btoAddLeft.TabIndex = 8;
            this.btoAddLeft.Text = "Add &Left Branch";
            this.btoAddLeft.UseVisualStyleBackColor = true;
            this.btoAddLeft.Click += new System.EventHandler(this.btoAddLeft_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(15, 107);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 26);
            this.txtValue.TabIndex = 7;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Evaluation Value";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisualNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.Controls.Add(this.btoAddRight);
            this.Controls.Add(this.btoAddLeft);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label2);
            this.Name = "VisualNode";
            this.Size = new System.Drawing.Size(337, 212);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtValue, 0);
            this.Controls.SetChildIndex(this.btoAddLeft, 0);
            this.Controls.SetChildIndex(this.btoAddRight, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btoAddRight;
        private System.Windows.Forms.Button btoAddLeft;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
    }
}
