using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using PathFinder.Core.Filesystem;
using PathFinder.WinForms.Tracking;
using WeifenLuo.WinFormsUI.Docking;

namespace PathFinder.WinForms.Forms
{
    public partial class FrmFileFolders : DockContent
    {
        private readonly ImageList m_iconList;
        private readonly IGenericRepository<IFileFolderInfo> m_repository;
        private readonly FileFolderContentType m_contentType;
        private readonly TrackerType m_trackerType;

        public FrmFileFolders(FileFolderContentType fileFolderContentType, TrackerType trackerType,
            IGenericRepository<IFileFolderInfo> repository)
        {
            InitializeComponent();
            m_repository = repository;
            m_repository.Changed += m_repository_Changed;
            m_iconList = new ImageList();
            m_iconList.ImageSize = new Size(16, 16);
            m_iconList.ColorDepth = ColorDepth.Depth32Bit;
            fileFolderListView1.SmallImageList = m_iconList;
            m_contentType = fileFolderContentType;
            m_trackerType = trackerType;
        }

        protected override string GetPersistString()
        {
            return GetType() + "#" + m_contentType + "#" + m_trackerType;
        }

        private void m_repository_Changed(object sender, EventArgs e)
        {
            RefreshItems(m_repository.GetAll());
        }

        public void RefreshItems(IEnumerable<IFileFolderInfo> fileFolderInfos)
        {
            fileFolderListView1.Items.Clear();
            foreach (var fileFolderInfo in fileFolderInfos)
            {
                try
                {
                    fileFolderListView1.Items.Add(FromFileFolerInfo(fileFolderInfo));
                }
                catch (Exception ex)
                {
                    m_repository.Remove(fileFolderInfo);
                    MessageBox.Show(this, ex.Message, "FileFolderListView");
                }
            }
        }

        private ListViewItem FromFileFolerInfo(IFileFolderInfo shellItem)
        {
            var lvItem = new ListViewItem();
            lvItem.Text = shellItem.DisplayName;
            lvItem.Tag = shellItem;

            if (shellItem.Icon != null)
            {
                var imgIndex = m_iconList.Images.IndexOfKey(shellItem.ParsingName);

                if (imgIndex < 0)
                {
                    m_iconList.Images.Add(shellItem.ParsingName, shellItem.Icon);
                }

                lvItem.ImageIndex = m_iconList.Images.IndexOfKey(shellItem.ParsingName);
            }
            return lvItem;
        }

        private void FrmPopularFolders_Load(object sender, EventArgs e)
        {
            SetCaption();
            m_repository.Load();
            RefreshItems(m_repository.GetAll());
        }

        private void SetCaption()
        {
            var captionFormat = "{0}";
            switch (m_trackerType)
            {
                case TrackerType.Popular:
                    captionFormat = "Popular {0}";
                    break;
                case TrackerType.History:
                    captionFormat = "{0} history";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (m_contentType)
            {
                case FileFolderContentType.File:
                    Text = String.Format(captionFormat, "Files");
                    break;
                case FileFolderContentType.Folder:
                    Text = String.Format(captionFormat, "Folders");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void fileFolderListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = fileFolderListView1.SelectedItems[0];

            if (item != null)
            {
                var ffi = (IFileFolderInfo) item.Tag;
                Process.Start(ffi.ParsingName);
            }
        }
    }
}

public enum FileFolderContentType
{
    File,
    Folder
}

public enum TrackerType
{
    Popular,
    History
}