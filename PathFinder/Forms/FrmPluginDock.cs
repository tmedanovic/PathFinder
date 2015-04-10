using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PathFinder.WinForms.Forms
{
    public partial class FrmPluginDock : DockContent
    {
        public FrmPluginDock(UserControl ctrl)
        {
            InitializeComponent();
            Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;;
        }
    }
}
