using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Controls;
using Microsoft.WindowsAPICodePack.Shell;
using PathFinder.Core;
using PathFinder.Core.Filesystem;
using PathFinder.Core.Windows;

namespace PathFinder.WinForms.Controls.Windows
{
    public partial class WinExplorerWindow : BaseWindow, IExplorerWindow
    {
        private BorderStyle m_controlBorderStyle;

        public WinExplorerWindow()
        {
            InitializeComponent();

            pathBreadcrumb1.Navigated += pathBreadcrumb1_Navigated;
            explorerBrowser1.NavigationComplete += explorerBrowser1_NavigationComplete;

            m_controlBorderStyle = BorderStyle.FixedSingle;
            //Controls.Cast<Control>().ToList().ForEach(x => x.MouseEnter += lvFiles_MouseEnter);
            Controls.Cast<Control>().ToList().ForEach(x => x.GotFocus += lvFiles_GotFocus);
            Controls.Cast<Control>().ToList().ForEach(x => x.LostFocus += lvFiles_LostFocus);

            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
        }

        public WinExplorerWindow(string path): this()
        {
            CurrentFolder = ShellHelper.FolderInfoFromPath(path);
        }

        public WinExplorerWindow(IFolderInfo item) : this()
        {
            CurrentFolder = item;
        }

        private IFolderInfo CurrentFolder { get; set; }

        public override string WindowTitle
        {
            get { return CurrentFolder.DisplayName; }
        }

        public ExplorerBrowserViewMode FileViewStyle 
        {
            get { return explorerBrowser1.ContentOptions.ViewMode; }
            set { explorerBrowser1.ContentOptions.ViewMode = value; }
        }

        public bool ShowDetails
        {
            get { return explorerBrowser1.NavigationOptions.PaneVisibility.Details != PaneVisibilityState.Hide; }
            set
            {
                explorerBrowser1.NavigationOptions.PaneVisibility.Details = value
                    ? PaneVisibilityState.Show
                    : PaneVisibilityState.Hide;
            }
        }

        public event EventHandler<NavigatedEventArgs> Navigated;

        public bool NoHeadersInAllViews
        {
            get { return explorerBrowser1.ContentOptions.NoHeaderInAllViews; }
            set { explorerBrowser1.ContentOptions.NoHeaderInAllViews = value; }
        }

        public override BorderStyle ControlBorderStyle
        {
            get { return m_controlBorderStyle; }
            set
            {
                m_controlBorderStyle = value;

                switch (value)
                {
                    case BorderStyle.None:
                        btnClose.Hide();
                     //   explorerBrowser1.Anchor = AnchorStyles.None;
                       // explorerBrowser1.Dock = DockStyle.Fill;
                        break;
                    case BorderStyle.FixedSingle:
                     //   pathBreadcrumb1.Dock = DockStyle.None;
                        btnClose.Show();
                      //  explorerBrowser1.Dock = DockStyle.None;
                     //   explorerBrowser1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
                        break;
                }
            }
        }

        public bool NonFileSystemTileView { get; set; }

        void explorerBrowser1_NavigationComplete(object sender, NavigationCompleteEventArgs e)
        {
            CurrentFolder = new FolderInfo(e.NewLocation.ParsingName, e.NewLocation.IsFileSystemObject, e.NewLocation.Name);
            pathBreadcrumb1.SetPath(CurrentFolder);

            if (NonFileSystemTileView)
            {
                if (!CurrentFolder.IsFileSystemPath)
                {
                    FileViewStyle = ExplorerBrowserViewMode.Tile;
                }
                else
                {
                    FileViewStyle = ExplorerBrowserViewMode.Details;
                }
            }
            else
            {
                FileViewStyle = ExplorerBrowserViewMode.Details;
            }

            OnNavigated(CurrentFolder);
        }

        private void pathBreadcrumb1_Navigated(object sender, NavigatedEventArgs e)
        {
            var obje = ShellObject.FromParsingName(e.FolderInfo.ParsingName);
            explorerBrowser1.Navigate(obje);
        }

        public override void Initialize()
        {
            var obje = ShellObject.FromParsingName(CurrentFolder.ParsingName);
            explorerBrowser1.Navigate(obje);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnClosed();
        }

        //private void lvFiles_MouseEnter(object sender, EventArgs e)
        //{
        //    explorerBrowser1.Focus();
        //}

        private void lvFiles_LostFocus(object sender, EventArgs e)
        {
            if (!Marked)
            {
                BackColor = SystemColors.ControlLight;
            }
        }

        private void lvFiles_GotFocus(object sender, EventArgs e)
        {
            if (!Marked)
            {
                BackColor = Color.FromArgb(156, 170, 193);
            }
        }

        private void OnNavigated(IFolderInfo folderInfo)
        {
            if (Navigated != null)
            {
                Navigated(this, new NavigatedEventArgs(folderInfo));
            }
        }

        #region Drag & Drop

        private bool m_isDragging = false;
        private int m_DDradius = 40;
        private int m_mX=0;
        private int m_mY=0;

        void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();
         //   base.OnMouseDown(e);
            m_mX = e.X;
            m_mY = e.Y;
            this.m_isDragging = false;
        }

        //protected override void OnMouseDown(MouseEventArgs e)
        //{

        //}


        void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m_isDragging = false;
           // base.OnMouseUp(e);
        }

        //protected override void OnMouseUp(MouseEventArgs e)
        //{

        //}     

        void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_isDragging)
            {
                if (e.Button == MouseButtons.Left && m_DDradius > 0)
                {
                    int num1 = m_mX - e.X;
                    int num2 = m_mY - e.Y;
                    if (((num1 * num1) + (num2 * num2)) > m_DDradius)
                    {
                        DoDragDrop(this, DragDropEffects.All);
                        m_isDragging = true;
                        return;
                    }
                }
               // base.OnMouseMove(e);
            }
        }


        //protected override void OnMouseMove(MouseEventArgs e)
        //{

        //}

        #endregion

        private void FileView_Load(object sender, EventArgs e)
        {
            explorerBrowser1.NavigationOptions.PaneVisibility.AdvancedQuery = PaneVisibilityState.Hide;
            explorerBrowser1.NavigationOptions.PaneVisibility.Commands = PaneVisibilityState.Hide;
            explorerBrowser1.NavigationOptions.PaneVisibility.Navigation = PaneVisibilityState.Hide;
            explorerBrowser1.NavigationOptions.PaneVisibility.Preview = PaneVisibilityState.Hide;
            explorerBrowser1.NavigationOptions.PaneVisibility.Query = PaneVisibilityState.Hide;
        }
    }
}