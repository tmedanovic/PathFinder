using PathFinder.WinForms.App;

namespace PathFinder.WinForms.Forms
{
    partial class FrmOptions
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRegisterAsDefaultApp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.scbNewTabStartPath = new GongSolutions.Shell.ShellComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.scbRootTreeviewPath = new GongSolutions.Shell.ShellComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSingleInstance = new System.Windows.Forms.CheckBox();
            this.bsOptions = new System.Windows.Forms.BindingSource(this.components);
            this.gbOnClose = new System.Windows.Forms.GroupBox();
            this.rbOnCloseMinimizeToTray = new System.Windows.Forms.RadioButton();
            this.rbOnCloseMinimizeToTaskbar = new System.Windows.Forms.RadioButton();
            this.rbOnCloseClose = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOptions)).BeginInit();
            this.gbOnClose.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpGeneral);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(505, 377);
            this.tabControl1.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.groupBox4);
            this.tpGeneral.Controls.Add(this.groupBox3);
            this.tpGeneral.Controls.Add(this.groupBox2);
            this.tpGeneral.Controls.Add(this.groupBox1);
            this.tpGeneral.Controls.Add(this.gbOnClose);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(497, 351);
            this.tpGeneral.TabIndex = 1;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRegisterAsDefaultApp);
            this.groupBox4.Location = new System.Drawing.Point(17, 200);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(164, 89);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Register as system default file manager";
            // 
            // btnRegisterAsDefaultApp
            // 
            this.btnRegisterAsDefaultApp.Location = new System.Drawing.Point(26, 41);
            this.btnRegisterAsDefaultApp.Name = "btnRegisterAsDefaultApp";
            this.btnRegisterAsDefaultApp.Size = new System.Drawing.Size(103, 23);
            this.btnRegisterAsDefaultApp.TabIndex = 0;
            this.btnRegisterAsDefaultApp.Text = "Register";
            this.btnRegisterAsDefaultApp.UseVisualStyleBackColor = true;
            this.btnRegisterAsDefaultApp.Click += new System.EventHandler(this.btnRegisterAsDefaultApp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.scbNewTabStartPath);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(201, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 78);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New tab start path";
            // 
            // scbNewTabStartPath
            // 
            this.scbNewTabStartPath.Location = new System.Drawing.Point(72, 29);
            this.scbNewTabStartPath.Name = "scbNewTabStartPath";
            this.scbNewTabStartPath.Size = new System.Drawing.Size(203, 23);
            this.scbNewTabStartPath.TabIndex = 1;
            this.scbNewTabStartPath.Text = "shellComboBox2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start path: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.scbRootTreeviewPath);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(201, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 78);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Root treeview";
            // 
            // scbRootTreeviewPath
            // 
            this.scbRootTreeviewPath.Location = new System.Drawing.Point(72, 29);
            this.scbRootTreeviewPath.Name = "scbRootTreeviewPath";
            this.scbRootTreeviewPath.Size = new System.Drawing.Size(203, 23);
            this.scbRootTreeviewPath.TabIndex = 1;
            this.scbRootTreeviewPath.Text = "shellComboBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Root path: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSingleInstance);
            this.groupBox1.Location = new System.Drawing.Point(17, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application options";
            // 
            // cbSingleInstance
            // 
            this.cbSingleInstance.AutoSize = true;
            this.cbSingleInstance.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsOptions, "SingleInstance", true));
            this.cbSingleInstance.Location = new System.Drawing.Point(24, 24);
            this.cbSingleInstance.Name = "cbSingleInstance";
            this.cbSingleInstance.Size = new System.Drawing.Size(98, 17);
            this.cbSingleInstance.TabIndex = 2;
            this.cbSingleInstance.Text = "Single instance";
            this.cbSingleInstance.UseVisualStyleBackColor = true;
            this.cbSingleInstance.CheckedChanged += new System.EventHandler(this.cbSingleInstance_CheckedChanged);
            // 
            // bsOptions
            // 
            this.bsOptions.DataSource = typeof(PathFinder.WinForms.App.AppSettings);
            // 
            // gbOnClose
            // 
            this.gbOnClose.Controls.Add(this.rbOnCloseMinimizeToTray);
            this.gbOnClose.Controls.Add(this.rbOnCloseMinimizeToTaskbar);
            this.gbOnClose.Controls.Add(this.rbOnCloseClose);
            this.gbOnClose.Location = new System.Drawing.Point(17, 17);
            this.gbOnClose.Name = "gbOnClose";
            this.gbOnClose.Size = new System.Drawing.Size(164, 117);
            this.gbOnClose.TabIndex = 0;
            this.gbOnClose.TabStop = false;
            this.gbOnClose.Text = "On close";
            // 
            // rbOnCloseMinimizeToTray
            // 
            this.rbOnCloseMinimizeToTray.AutoSize = true;
            this.rbOnCloseMinimizeToTray.Location = new System.Drawing.Point(24, 75);
            this.rbOnCloseMinimizeToTray.Name = "rbOnCloseMinimizeToTray";
            this.rbOnCloseMinimizeToTray.Size = new System.Drawing.Size(120, 17);
            this.rbOnCloseMinimizeToTray.TabIndex = 2;
            this.rbOnCloseMinimizeToTray.TabStop = true;
            this.rbOnCloseMinimizeToTray.Text = "Minimize to tray icon";
            this.rbOnCloseMinimizeToTray.UseVisualStyleBackColor = true;
            this.rbOnCloseMinimizeToTray.CheckedChanged += new System.EventHandler(this.rbOnCloseClose_CheckedChanged);
            // 
            // rbOnCloseMinimizeToTaskbar
            // 
            this.rbOnCloseMinimizeToTaskbar.AutoSize = true;
            this.rbOnCloseMinimizeToTaskbar.Location = new System.Drawing.Point(24, 52);
            this.rbOnCloseMinimizeToTaskbar.Name = "rbOnCloseMinimizeToTaskbar";
            this.rbOnCloseMinimizeToTaskbar.Size = new System.Drawing.Size(115, 17);
            this.rbOnCloseMinimizeToTaskbar.TabIndex = 1;
            this.rbOnCloseMinimizeToTaskbar.TabStop = true;
            this.rbOnCloseMinimizeToTaskbar.Text = "Minimize to taskbar";
            this.rbOnCloseMinimizeToTaskbar.UseVisualStyleBackColor = true;
            this.rbOnCloseMinimizeToTaskbar.CheckedChanged += new System.EventHandler(this.rbOnCloseClose_CheckedChanged);
            // 
            // rbOnCloseClose
            // 
            this.rbOnCloseClose.AutoSize = true;
            this.rbOnCloseClose.Location = new System.Drawing.Point(24, 29);
            this.rbOnCloseClose.Name = "rbOnCloseClose";
            this.rbOnCloseClose.Size = new System.Drawing.Size(105, 17);
            this.rbOnCloseClose.TabIndex = 0;
            this.rbOnCloseClose.TabStop = true;
            this.rbOnCloseClose.Text = "Close application";
            this.rbOnCloseClose.UseVisualStyleBackColor = true;
            this.rbOnCloseClose.CheckedChanged += new System.EventHandler(this.rbOnCloseClose_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(418, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(337, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 419);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOptions";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOptions)).EndInit();
            this.gbOnClose.ResumeLayout(false);
            this.gbOnClose.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.GroupBox gbOnClose;
        private System.Windows.Forms.RadioButton rbOnCloseMinimizeToTray;
        private System.Windows.Forms.RadioButton rbOnCloseMinimizeToTaskbar;
        private System.Windows.Forms.RadioButton rbOnCloseClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource bsOptions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbSingleInstance;
        private System.Windows.Forms.GroupBox groupBox3;
        private GongSolutions.Shell.ShellComboBox scbNewTabStartPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private GongSolutions.Shell.ShellComboBox scbRootTreeviewPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRegisterAsDefaultApp;
    }
}