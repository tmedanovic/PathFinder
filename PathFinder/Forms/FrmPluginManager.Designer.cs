namespace PathFinder.WinForms.Forms
{
    partial class FrmPluginManager
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
            this.tabPlugins = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bsPlugins = new System.Windows.Forms.BindingSource(this.components);
            this.availablePluginGrid = new PathFinder.WinForms.Controls.Plugins.PluginGridControl();
            this.tabPlugins.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlugins)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPlugins
            // 
            this.tabPlugins.Controls.Add(this.tabPage1);
            this.tabPlugins.Controls.Add(this.tabPage2);
            this.tabPlugins.Controls.Add(this.tabPage3);
            this.tabPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPlugins.Location = new System.Drawing.Point(0, 0);
            this.tabPlugins.Name = "tabPlugins";
            this.tabPlugins.SelectedIndex = 0;
            this.tabPlugins.Size = new System.Drawing.Size(745, 520);
            this.tabPlugins.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.availablePluginGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(737, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Available";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(737, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Installed";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(737, 494);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Updates";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bsPlugins
            // 
            this.bsPlugins.DataSource = typeof(PathFinder.Core.Plugins.IPluginInfo);
            // 
            // availablePluginGrid
            // 
            this.availablePluginGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.availablePluginGrid.Location = new System.Drawing.Point(3, 3);
            this.availablePluginGrid.Name = "availablePluginGrid";
            this.availablePluginGrid.Size = new System.Drawing.Size(731, 488);
            this.availablePluginGrid.TabIndex = 0;
            // 
            // FrmPluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 520);
            this.Controls.Add(this.tabPlugins);
            this.Name = "FrmPluginManager";
            this.Text = "Plugin manager";
            this.Load += new System.EventHandler(this.FrmPluginManager_Load);
            this.tabPlugins.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsPlugins)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsPlugins;
        private System.Windows.Forms.TabControl tabPlugins;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Controls.Plugins.PluginGridControl availablePluginGrid;

    }
}