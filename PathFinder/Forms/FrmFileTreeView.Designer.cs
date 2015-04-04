namespace PathFinder.WinForms.Forms
{
    partial class FrmFileTreeView
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
            this.tvRoot = new GongSolutions.Shell.ShellTreeView();
            this.SuspendLayout();
            // 
            // tvRoot
            // 
            this.tvRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRoot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tvRoot.Location = new System.Drawing.Point(0, 0);
            this.tvRoot.Name = "tvRoot";
            this.tvRoot.Size = new System.Drawing.Size(357, 328);
            this.tvRoot.TabIndex = 1;
            // 
            // FrmFileTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 328);
            this.Controls.Add(this.tvRoot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HideOnClose = true;
            this.Name = "FrmFileTreeView";
            this.Text = "Root";
            this.ResumeLayout(false);

        }

        #endregion

        private GongSolutions.Shell.ShellTreeView tvRoot;
    }
}