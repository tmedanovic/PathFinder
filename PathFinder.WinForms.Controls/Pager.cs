using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PathFinder.Core.Controls;

namespace PathFinder.WinForms.Controls
{
    public partial class Pager : UserControl
    {
        private readonly Label m_nextPage;
        private readonly Label m_previousPage;
        private IPageInfo m_page;

        public Pager()
        {
            InitializeComponent();
            m_nextPage = CreatePagerLabel(">", false);
            m_previousPage = CreatePagerLabel("<", false);
            m_nextPage.Click += (sender, args) => OnChangePage(m_page.PageIndex + 1);
            m_previousPage.Click += (sender, args) => OnChangePage(m_page.PageIndex - 1);
        }

        public bool ShowNextAndPrevious { get; set; }

        public void SetPage(IPageInfo page)
        {
            m_page = page;
            var controls = CreateControls().ToArray();

            flpPager.SuspendLayout();
            flpPager.Controls.Clear();
            flpPager.Controls.AddRange(controls);
            flpPager.ResumeLayout();
        }

        private List<Control> CreateControls()
        {
            var pgrCtrls = new List<Control>();

            if (m_page.PreviousPages != null && m_page.PreviousPages.Count > 0)
            {
                if (ShowNextAndPrevious)
                {
                    pgrCtrls.Add(m_previousPage);
                }

                pgrCtrls.AddRange(m_page.PreviousPages.Select(x => CreatePageNumLabel(x, false)));
            }

            pgrCtrls.Add(CreatePageNumLabel(m_page.PageIndex, true));

            if (m_page.NextPages != null && m_page.NextPages.Count > 0)
            {
                pgrCtrls.AddRange(m_page.NextPages.Select(x => CreatePageNumLabel(x, false)));

                if (ShowNextAndPrevious)
                {
                    pgrCtrls.Add(m_nextPage);
                }
            }

            return pgrCtrls;
        }

        private Label CreatePageNumLabel(int page, bool current)
        {
            var lbl = CreatePagerLabel(page.ToString(), current, page);
            lbl.Click += PageNumLblOnClick;
            return lbl;
        }

        private void PageNumLblOnClick(object sender, EventArgs eventArgs)
        {
            var lbl = ((Label) sender);
            var pageNum = ((int) lbl.Tag);
            OnChangePage(pageNum);
        }

        private Label CreatePagerLabel(string text, bool bold, object tag = null)
        {
            var pgrLabel = new Label();
            pgrLabel.Size = new Size(10, flpPager.Height);
            pgrLabel.Font = new Font("Microsoft Sans Serif", 8.25F, bold ? FontStyle.Bold : FontStyle.Regular,
                GraphicsUnit.Point, 238);
            pgrLabel.TabIndex = 0;
            pgrLabel.Text = text;
            pgrLabel.Tag = tag;
            pgrLabel.Cursor = Cursors.Hand;
            pgrLabel.TextAlign = ContentAlignment.MiddleCenter;
            return pgrLabel;
        }

        private void OnChangePage(int page)
        {
            if (ChangePage != null)
            {
                ChangePage(this, new ChangePageEventArgs(page));
            }
        }

        public event EventHandler<ChangePageEventArgs> ChangePage;
    }

    public class ChangePageEventArgs : EventArgs
    {
        public ChangePageEventArgs(int page)
        {
            RequestedPage = page;
        }

        public int RequestedPage { get; set; }
    }
}