using System.Windows.Forms;

namespace PathFinder.WinForms.Controls.Windows
{
    public partial class _FileView : UserControl
    {
    //    private BorderStyle m_controlBorderStyle;
    //    private bool m_mark;

    //    public _FileView()
    //    {
    //        InitializeComponent();

    //        pathBreadcrumb1.Navigated += pathBreadcrumb1_Navigated;
    //        lvFiles.Navigated += lvFiles_Navigated;

    //        m_controlBorderStyle = BorderStyle.FixedSingle;
    //        Controls.Cast<Control>().ToList().ForEach(x => x.MouseEnter += lvFiles_MouseEnter);
    //        Controls.Cast<Control>().ToList().ForEach(x => x.GotFocus += lvFiles_GotFocus);
    //        Controls.Cast<Control>().ToList().ForEach(x => x.LostFocus += lvFiles_LostFocus);
           
    //        m_columnResizeTimer.Interval = 500;
    //        m_columnResizeTimer.Enabled = false;
    //        m_columnResizeTimer.Tick += m_columnResizeTimer_Tick;

    //        panel1.MouseDown += panel1_MouseDown;
    //        panel1.MouseMove += panel1_MouseMove;
    //        panel1.MouseUp += panel1_MouseUp;
    //    }

    //    void m_columnResizeTimer_Tick(object sender, EventArgs e)
    //    {          
    //        m_columnResizeTimer.Stop();
    //        AutosizeColumns();
    //    }

    //    private ShellItem m_startFolder;

    //    public _FileView(string path)
    //        : this(new ShellItem(path))
    //    {

    //    }

    //    public _FileView(ShellItem item) : this()
    //    {
    //       // lvFiles.Navigate(item);
    //        //lvFiles.CurrentFolder = item;
    //        m_startFolder = item;
    //    }

    //    public bool Marked
    //    {
    //        get { return m_mark; }
    //        set { Mark(value); }
    //    }

    //    public ShellItem CurrentFolder
    //    {
    //        get { return lvFiles.CurrentFolder; }
    //    }

    //    public string FolderName
    //    {
    //        get { return lvFiles.CurrentFolder.DisplayName; }
    //    }

    //    public ShellViewStyle FileViewStyle 
    //    {
    //        get { return lvFiles.View; }
    //        set { lvFiles.View = value; }
    //    }

    //    public BorderStyle ControlBorderStyle
    //    {
    //        get { return m_controlBorderStyle; }
    //        set
    //        {
    //            m_controlBorderStyle = value;

    //            switch (value)
    //            {
    //                case BorderStyle.None:
    //                    btnClose.Hide();
    //                   // pathBreadcrumb1.Dock = DockStyle.Fill;
    //                    lvFiles.Anchor = AnchorStyles.None;
    //                    lvFiles.Dock = DockStyle.Fill;
    //                    //  Dock = DockStyle.Fill;
    //                    break;
    //                case BorderStyle.FixedSingle:
    //                    pathBreadcrumb1.Dock = DockStyle.None;
    //                    btnClose.Show();
    //                    lvFiles.Dock = DockStyle.None;
    //                    lvFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
    //                    //Dock = DockStyle.Fill;
    //                    break;
    //            }
    //        }
    //    }

    //    public event EventHandler<FileViewEventArgs> Closed;
    //    public Timer m_columnResizeTimer = new Timer();

    //    public bool NonFileSystemTileView { get; set; }

    //    private void lvFiles_Navigated(object sender, EventArgs e)
    //    {
    //        if (lvFiles.CurrentFolder.IsFileSystem)
    //        {
    //            var path = lvFiles.CurrentFolder.FileSystemPath;

    //            pathBreadcrumb1.SetPath(path);
    //            PopularFolderTracker.Add(path);
    //        }
    //        else
    //        {
    //            var path = lvFiles.CurrentFolder.ToUri().ToString();
    //            pathBreadcrumb1.SetPath(path);
    //            PopularFolderTracker.Add(path);
    //        }
    //        // lvFiles.AutoresizeColumns();
    //        m_columnResizeTimer.Start();
    //    }

    //    private void pathBreadcrumb1_Navigated(object sender, NavigatedEventArgs e)
    //    {
    //        lvFiles.Navigate(e.Path);
    //    }

    //    public void Mark(bool mark)
    //    {
    //        m_mark = mark;

    //        if (!m_mark)
    //        {
    //            BackColor = SystemColors.ControlLight;
    //        }
    //        else
    //        {
    //            BackColor = Color.FromArgb(191, 132, 119);
    //        }
    //    }

    //    public void Mark()
    //    {
    //        Mark(!m_mark);
    //    }

    //    public void LoadDirectory()
    //    {
    //       lvFiles.CurrentFolder = m_startFolder;
    //    }

    //    private void btnClose_Click(object sender, EventArgs e)
    //    {
    //        OnClosed(this);
    //    }

    //    private void lvFiles_MouseEnter(object sender, EventArgs e)
    //    {
    //        lvFiles.Focus();
    //    }

    //    private void lvFiles_LostFocus(object sender, EventArgs e)
    //    {
    //        if (!m_mark)
    //        {
    //            BackColor = SystemColors.ControlLight;
    //        }
    //    }

    //    private void lvFiles_GotFocus(object sender, EventArgs e)
    //    {
    //        if (!m_mark)
    //        {
    //            BackColor = Color.FromArgb(156, 170, 193);
    //        }
    //    }

    //    private void lvFiles_DoubleClick(object sender, EventArgs e)
    //    {
    //        if (!lvFiles.SelectedItems[0].IsFolder)
    //        {
    //            Process.Start(lvFiles.SelectedItems[0].FileSystemPath);
    //        }
    //    }

    //    protected virtual void OnClosed(_FileView window)
    //    {
    //        if (Closed != null)
    //        {
    //            //Closed(this, new FileViewEventArgs(window));
    //        }
    //    }

    //    #region Drag & Drop

    //    private bool m_isDragging = false;
    //    private int m_DDradius = 40;
    //    private int m_mX=0;
    //    private int m_mY=0;

    //    void panel1_MouseDown(object sender, MouseEventArgs e)
    //    {
    //        this.Focus();
    //     //   base.OnMouseDown(e);
    //        m_mX = e.X;
    //        m_mY = e.Y;
    //        this.m_isDragging = false;
    //    }

    //    //protected override void OnMouseDown(MouseEventArgs e)
    //    //{

    //    //}


    //    void panel1_MouseUp(object sender, MouseEventArgs e)
    //    {
    //        m_isDragging = false;
    //       // base.OnMouseUp(e);
    //    }

    //    //protected override void OnMouseUp(MouseEventArgs e)
    //    //{

    //    //}     

    //    void panel1_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        if (!m_isDragging)
    //        {
    //            if (e.Button == MouseButtons.Left && m_DDradius > 0)
    //            {
    //                int num1 = m_mX - e.X;
    //                int num2 = m_mY - e.Y;
    //                if (((num1 * num1) + (num2 * num2)) > m_DDradius)
    //                {
    //                    DoDragDrop(this, DragDropEffects.All);
    //                    m_isDragging = true;
    //                    return;
    //                }
    //            }
    //           // base.OnMouseMove(e);
    //        }
    //    }


    //    //protected override void OnMouseMove(MouseEventArgs e)
    //    //{

    //    //}

    //    #endregion

    //    //protected override CreateParams CreateParams
    //    //{
    //    //    get
    //    //    {
    //    //        CreateParams cp = base.CreateParams;
    //    //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
    //    //        return cp;
    //    //    }
    //    //}

    //    [DllImport("user32.DLL")]
    //    public static extern IntPtr FindWindowEx(IntPtr hwndParent,
    //        IntPtr hwndChildAfter, string lpszClass, string lpszWindow);   


    //    private void FileView_Load(object sender, EventArgs e)
    //    {
    //       // AutosizeColumns();
    //        var handle = FindWindowEx(lvFiles.ShellHandle, IntPtr.Zero, "SysListView32", null);
    //        ListViewHelper.RemoveStyle(handle, ListViewExtendedStyles.HeaderInAllViews);
    //        StyleHelper.SetExplorerTheme(handle);
    //    }

    //    private void lvFiles_Resize(object sender, EventArgs e)
    //    {
    //        AutosizeColumns();
    //    }

    //    private void AutosizeColumns()
    //    {
    //        for (int i = 0; i < 20; i++)
    //        {
    //            try
    //            {
    //                lvFiles.SetColumnWidth(i, ShellView.ColumnAutoSize);
    //            }
    //            catch (Exception)
    //            {
    //                break;
    //            }
    //        }
    //    }

    //    private void lvFiles_Navigating(object sender, NavigatingEventArgs e)
    //    {
    //        if (!e.Folder.IsFileSystem)
    //        {
    //            if (NonFileSystemTileView)
    //            {
    //                FileViewStyle = ShellViewStyle.Tile;
    //            }
    //        }
    //        else
    //        {
    //            if (NonFileSystemTileView)
    //            {
    //                FileViewStyle = ShellViewStyle.Details;

    //            }
    //        }
    //    }
    }
}