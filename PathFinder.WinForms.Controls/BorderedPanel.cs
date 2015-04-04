using System.Drawing;
using System.Windows.Forms;

namespace PathFinder.WinForms.Controls
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class BorderedPanel : Panel
    {
        private Color m_borderColor = Color.Black;
        private bool m_showBorder = false;

        public Color BorderColor
        {
            get { return m_borderColor; }
            set { m_borderColor = value; }
        }

        public bool ShowBorder
        {
            get { return m_showBorder; }
            set { m_showBorder = value; }
        }

        public BorderedPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
                if (BorderStyle == BorderStyle.None && ShowBorder)
                {
                    using (var pen = new Pen(BorderColor))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
                    }
                }
            }
        }

    }
}
