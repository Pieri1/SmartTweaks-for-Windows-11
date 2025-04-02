namespace SmartTweaks_For_Windows_11.ui
{
    partial class RowTemplate
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
            this.rowchkbox = new System.Windows.Forms.CheckBox();
            this.rowcmbbox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // rowchkbox
            // 
            this.rowchkbox.AutoSize = true;
            this.rowchkbox.Location = new System.Drawing.Point(3, 6);
            this.rowchkbox.Name = "rowchkbox";
            this.rowchkbox.Size = new System.Drawing.Size(95, 20);
            this.rowchkbox.TabIndex = 1;
            this.rowchkbox.Text = "checkBox1";
            this.rowchkbox.UseVisualStyleBackColor = true;
            this.rowchkbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // rowcmbbox
            // 
            this.rowcmbbox.FormattingEnabled = true;
            this.rowcmbbox.Location = new System.Drawing.Point(451, 5);
            this.rowcmbbox.Name = "rowcmbbox";
            this.rowcmbbox.Size = new System.Drawing.Size(305, 24);
            this.rowcmbbox.TabIndex = 2;
            // 
            // RowTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rowcmbbox);
            this.Controls.Add(this.rowchkbox);
            this.Name = "RowTemplate";
            this.Size = new System.Drawing.Size(760, 32);
            this.Load += new System.EventHandler(this.RowTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox rowchkbox;
        private System.Windows.Forms.ComboBox rowcmbbox;
    }
}
