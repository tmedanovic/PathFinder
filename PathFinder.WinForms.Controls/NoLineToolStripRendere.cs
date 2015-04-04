using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PathFinder.WinForms.Controls
{
    public class NoLineToolStripRendere : ToolStripSystemRenderer
    {
        public NoLineToolStripRendere() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }
    }
}
