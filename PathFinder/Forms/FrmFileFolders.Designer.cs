using System.Windows.Forms;

namespace PathFinder.WinForms.Forms
{
    partial class FrmFileFolders
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fileFolderListView1 = new System.Windows.Forms.ListView();
            this.folderNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // fileFolderListView1
            // 
            this.fileFolderListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.folderNameCol});
            this.fileFolderListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileFolderListView1.Location = new System.Drawing.Point(0, 0);
            this.fileFolderListView1.Name = "fileFolderListView1";
            this.fileFolderListView1.Size = new System.Drawing.Size(348, 422);
            this.fileFolderListView1.TabIndex = 0;
            this.fileFolderListView1.UseCompatibleStateImageBehavior = false;
            this.fileFolderListView1.View = System.Windows.Forms.View.List;
            this.fileFolderListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileFolderListView1_MouseDoubleClick);
            // 
            // folderNameCol
            // 
            this.folderNameCol.Text = "Folder name";
            this.folderNameCol.Width = 120;
            // 
            // FrmFileFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 422);
            this.Controls.Add(this.fileFolderListView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "FrmFileFolders";
            this.Text = "Popular folders";
            this.Load += new System.EventHandler(this.FrmPopularFolders_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private ListView fileFolderListView1;
        private System.Windows.Forms.ColumnHeader folderNameCol;

    }
}