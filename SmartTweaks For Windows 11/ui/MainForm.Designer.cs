namespace SmartTweaks_For_Windows_11.ui
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tabctrl = new System.Windows.Forms.TabControl();
            this.btnexecute = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnload = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnrevert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabctrl
            // 
            this.tabctrl.Location = new System.Drawing.Point(9, 10);
            this.tabctrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabctrl.Name = "tabctrl";
            this.tabctrl.SelectedIndex = 0;
            this.tabctrl.Size = new System.Drawing.Size(607, 475);
            this.tabctrl.TabIndex = 0;
            this.tabctrl.SelectedIndexChanged += new System.EventHandler(this.tabctrl_SelectedIndexChanged);
            // 
            // btnexecute
            // 
            this.btnexecute.Location = new System.Drawing.Point(620, 10);
            this.btnexecute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnexecute.Name = "btnexecute";
            this.btnexecute.Size = new System.Drawing.Size(103, 19);
            this.btnexecute.TabIndex = 1;
            this.btnexecute.Text = "Run";
            this.btnexecute.UseVisualStyleBackColor = true;
            this.btnexecute.Click += new System.EventHandler(this.btnexecute_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(620, 33);
            this.btnsave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(103, 19);
            this.btnsave.TabIndex = 2;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(620, 57);
            this.btnload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(103, 19);
            this.btnload.TabIndex = 3;
            this.btnload.Text = "Load";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(9, 491);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(130, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Hover to show description";
            this.lblDesc.Click += new System.EventHandler(this.lblDesc_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnrevert
            // 
            this.btnrevert.Enabled = false;
            this.btnrevert.Location = new System.Drawing.Point(620, 81);
            this.btnrevert.Name = "btnrevert";
            this.btnrevert.Size = new System.Drawing.Size(103, 19);
            this.btnrevert.TabIndex = 5;
            this.btnrevert.Text = "Revert";
            this.btnrevert.UseVisualStyleBackColor = true;
            this.btnrevert.Click += new System.EventHandler(this.btnrevert_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 511);
            this.Controls.Add(this.btnrevert);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnexecute);
            this.Controls.Add(this.tabctrl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabctrl;
        private System.Windows.Forms.Button btnexecute;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnrevert;
    }
}