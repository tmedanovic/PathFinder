using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PathFinder.Core.Filesystem;

namespace PathFinder.Plugins.PopularFileFolder.Controls
{
    public class FileFolderListView : ListView
    {
        private readonly ImageList m_iconList;

        public FileFolderListView()
        {
            m_iconList = new ImageList();
            m_iconList.ImageSize = new Size(16,16);
            m_iconList.ColorDepth = ColorDepth.Depth32Bit;
            SmallImageList = m_iconList;
        }

        public void RefreshItems(IEnumerable<IFileFolderInfo> fileFolderInfos)
        {
            try
            {
                Items.Clear();
                foreach (var fileFolderInfo in fileFolderInfos)
                {
                    Items.Add(FromFileFolerInfo(fileFolderInfo));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "FileFolderListView");
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
    }
}
