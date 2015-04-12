using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using PathFinder.Core;
using PathFinder.Core.Filesystem;

namespace PathFinder.WinForms.Controls
{
    public partial class PathBreadcrumb : UserControl
    {
        public PathBreadcrumb()
        {
            InitializeComponent();
        }

        private void OnNavigated(IFolderInfo folderInfo)
        {
            if (Navigated != null)
            {
                Navigated(this, new NavigatedEventArgs(folderInfo));
            }
        }

        public event EventHandler<NavigatedEventArgs> Navigated;

        public void SetPath(IFolderInfo info)
        {
            flowLayoutPanel1.Controls.Clear();

            if (info.IsFileSystemPath)
            {
                string[] parts = info.ParsingName.Split(new[] {'\\'}, StringSplitOptions.RemoveEmptyEntries);

                for (int index = 0; index < parts.Length; index++)
                {
                    var part = parts[index];
                    var path = GlueParts(parts, index);
                    var displayName = ShellHelper.FolderInfoFromPath(path).DisplayName;
                    var tag = new FolderInfo(path, true, displayName);
                    CreateLabel(displayName, tag, part == parts.Last());
                }
            }
            else
            {
                CreateLabel(info.DisplayName, info, true);
            }
        }

        private string GlueParts(string[] parts, int lastpart)
        {
            var part = String.Empty;

            for (var index = 0; index <= lastpart; index++)
            {
                part += parts[index] + "\\";
            }

            return part;
        }

        private void CreateLabel(string text, IFolderInfo tag, bool last)
        {
            var label = new Label();
            label.Font = new Font("Segoe UI", 8.25F, last? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, 238);

            if (!last)
            {
                label.Image = Properties.Resources.tab_right;
            }

            label.ImageAlign = ContentAlignment.MiddleRight;
            label.Cursor = Cursors.Hand;
            var size = MeasureString(text, label.Font);
            size.Width += 5;

            if (!last)
            {
                size.Width += 20;
            }

            label.Size = new Size((int)size.Width, flowLayoutPanel1.Height);
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Tag = tag;
            label.Click += label_Click;
            label.MouseEnter += label_MouseHover;
            label.MouseLeave += label_MouseLeave;
            flowLayoutPanel1.Controls.Add(label);
        }

        void label_MouseLeave(object sender, EventArgs e)
        {
            ((Label) sender).BackColor = Color.Transparent;
        }

        void label_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(65, 3, 187, 248);
        }

        void label_Click(object sender, EventArgs e)
        {
            var path = (FolderInfo)((Label) sender).Tag;
            OnNavigated(path);
        }

        private static SizeF MeasureString(string s, Font font)
        {
            SizeF result;
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    result = g.MeasureString(s, font);
                }
            }

            return result;
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (var label in flowLayoutPanel1.Controls.OfType<Label>())
            {
                label.Size = new Size(label.Width, flowLayoutPanel1.Height);
            }
        }

        //private void PathBreadcrumb_Resize(object sender, EventArgs e)
        //{
        //    foreach (var label in flowLayoutPanel1.Controls.OfType<Label>())
        //    {
        //        label.Size = new Size(label.Size.Width, flowLayoutPanel1.Height);
        //    }
        //}
    }
}
