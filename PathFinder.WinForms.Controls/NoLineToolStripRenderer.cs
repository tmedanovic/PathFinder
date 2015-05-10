using System.Windows.Forms;

namespace PathFinder.WinForms.Controls
{
    public class NoLineToolStripRenderer : ToolStripSystemRenderer
    {
        public NoLineToolStripRenderer() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            //e.ArrowColor = Color.White;
            //base.OnRenderArrow(e);
        }
    }
}
