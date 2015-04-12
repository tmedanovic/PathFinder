using System.Windows.Forms;
using PathFinder.Core.Plugins;
using PathFinder.Service;
using PathFinder.WinForms.Plugins;

namespace PathFinder.WinForms.Forms
{
    public partial class FrmPluginManager : Form
    {
        private PluginManager m_pluginManager = new PluginManager();
        private readonly IPluginService m_pluginService;
        private readonly int m_pageSize = 10;

        public FrmPluginManager()
        {
            InitializeComponent();
            m_pluginService = new PluginTestService();
            availablePluginGrid.SetPageRequester(pageIndex => m_pluginService.GetAvailablePlugins(null, pageIndex, m_pageSize, (int)PluginType.All));
        }

        private void FrmPluginManager_Load(object sender, System.EventArgs e)
        {

        }
    }
}
