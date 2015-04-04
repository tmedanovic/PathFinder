using System;
using System.Drawing;
using System.Windows.Forms;

namespace PathFinder.Core.Windows
{
    public class BaseWindow : UserControl 
    {
        public event EventHandler<WindowEventArgs> Closed;
        private bool m_mark;

        public virtual BorderStyle ControlBorderStyle { get; set; }

        public bool Marked
        {
            get { return m_mark; }
            set { Mark(value); }
        }

        public virtual void Initialize()
        {

        }

        public virtual string WindowTitle { get; set; }

        public void Mark(bool mark)
        {
            m_mark = mark;

            if (!m_mark)
            {
                BackColor = SystemColors.ControlLight;
            }
            else
            {
                BackColor = Color.FromArgb(191, 132, 119);
            }
        }

        public void Mark()
        {
            Mark(!m_mark);
        }

        protected void OnClosed()
        {
            if (Closed != null)
            {
                Closed(this, new WindowEventArgs(this));
            }
        }
    }
}
