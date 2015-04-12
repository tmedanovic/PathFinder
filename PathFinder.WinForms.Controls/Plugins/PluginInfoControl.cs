using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PathFinder.WinForms.Controls
{
    public partial class PluginInfoControl : UserControl
    {
        public PluginInfoControl(Icon icon, string name, string description, object tag)
        {
            InitializeComponent();
            Controls.Cast<Control>().ToList().ForEach(x => x.Click += (s, e) => base.OnClick(new EventArgs()));
            pbIcon.Image = icon.ToBitmap();
            lblName.Text = name;
            lblDescription.Text = description;
            Tag = tag;
        }
    }
}
