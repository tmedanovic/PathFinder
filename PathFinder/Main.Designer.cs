namespace PathFinder.WinForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.tsddbFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbView = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsddbWindow = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiPluginManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1346238561_folder_classic.png");
            this.imageList1.Images.SetKeyName(1, "1346238604_folder_classic_opened.png");
            this.imageList1.Images.SetKeyName(2, "1346228331_drive.png");
            this.imageList1.Images.SetKeyName(3, "1346228337_drive_cd.png");
            this.imageList1.Images.SetKeyName(4, "1346228356_drive_cd_empty.png");
            this.imageList1.Images.SetKeyName(5, "1346228364_drive_disk.png");
            this.imageList1.Images.SetKeyName(6, "1346228591_drive_network.png");
            this.imageList1.Images.SetKeyName(7, "1346228618_drive_link.png");
            this.imageList1.Images.SetKeyName(8, "1346228623_drive_error.png");
            this.imageList1.Images.SetKeyName(9, "1346228633_drive_go.png");
            this.imageList1.Images.SetKeyName(10, "1346228636_drive_delete.png");
            this.imageList1.Images.SetKeyName(11, "1346228639_drive_burn.png");
            this.imageList1.Images.SetKeyName(12, "1346238642_folder_classic_locked.png");
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
            this.dockPanel.Location = new System.Drawing.Point(0, 0);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(1261, 737);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel.Skin = dockPanelSkin1;
            this.dockPanel.TabIndex = 2;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Path finder";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dockPanel);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1261, 737);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1261, 762);
            this.toolStripContainer1.TabIndex = 6;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsMainMenu);
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tsMainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbFile,
            this.tsddbView,
            this.tsddbTools,
            this.tsddbWindow});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMainMenu.Size = new System.Drawing.Size(1261, 25);
            this.tsMainMenu.Stretch = true;
            this.tsMainMenu.TabIndex = 0;
            // 
            // tsddbFile
            // 
            this.tsddbFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.tsddbFile.Image = ((System.Drawing.Image)(resources.GetObject("tsddbFile.Image")));
            this.tsddbFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbFile.Name = "tsddbFile";
            this.tsddbFile.Size = new System.Drawing.Size(38, 22);
            this.tsddbFile.Text = "File";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(92, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsddbView
            // 
            this.tsddbView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbView.Image = ((System.Drawing.Image)(resources.GetObject("tsddbView.Image")));
            this.tsddbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbView.Name = "tsddbView";
            this.tsddbView.Size = new System.Drawing.Size(45, 22);
            this.tsddbView.Text = "View";
            // 
            // tsddbWindow
            // 
            this.tsddbWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOptions});
            this.tsddbWindow.Image = ((System.Drawing.Image)(resources.GetObject("tsddbWindow.Image")));
            this.tsddbWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbWindow.Name = "tsddbWindow";
            this.tsddbWindow.Size = new System.Drawing.Size(64, 22);
            this.tsddbWindow.Text = "Window";
            // 
            // tsmiOptions
            // 
            this.tsmiOptions.Name = "tsmiOptions";
            this.tsmiOptions.Size = new System.Drawing.Size(116, 22);
            this.tsmiOptions.Text = "Options";
            this.tsmiOptions.Click += new System.EventHandler(this.tsmiOptions_Click);
            // 
            // tsddbTools
            // 
            this.tsddbTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPluginManager});
            this.tsddbTools.Image = ((System.Drawing.Image)(resources.GetObject("tsddbTools.Image")));
            this.tsddbTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbTools.Name = "tsddbTools";
            this.tsddbTools.Size = new System.Drawing.Size(49, 22);
            this.tsddbTools.Text = "Tools";
            // 
            // tsmiPluginManager
            // 
            this.tsmiPluginManager.Name = "tsmiPluginManager";
            this.tsmiPluginManager.Size = new System.Drawing.Size(158, 22);
            this.tsmiPluginManager.Text = "Plugin manager";
            this.tsmiPluginManager.Click += new System.EventHandler(this.tsmiPluginManager_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 762);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Path finder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripDropDownButton tsddbFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripDropDownButton tsddbView; 
        private System.Windows.Forms.ToolStripDropDownButton tsddbWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripDropDownButton tsddbTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiPluginManager;
    }
}

