using Webmicrolab.Common.Winforms.Controls;

namespace PathFinder.WinForms.Controls
{
    partial class PathBreadcrumb
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.borderedPanel1 = new BorderedPanel();
            this.borderedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(339, 25);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // borderedPanel1
            // 
            this.borderedPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.borderedPanel1.Controls.Add(this.flowLayoutPanel1);
            this.borderedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderedPanel1.Location = new System.Drawing.Point(0, 0);
            this.borderedPanel1.Name = "borderedPanel1";
            this.borderedPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.borderedPanel1.ShowBorder = true;
            this.borderedPanel1.Size = new System.Drawing.Size(341, 27);
            this.borderedPanel1.TabIndex = 1;
            // 
            // PathBreadcrumb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.borderedPanel1);
            this.Name = "PathBreadcrumb";
            this.Size = new System.Drawing.Size(341, 27);
            this.borderedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private BorderedPanel borderedPanel1;
    }
}
