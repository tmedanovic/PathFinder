using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Forms;
using PathFinder.Core;
using Webmicrolab.Plugins;

namespace PathFinder.Plugins.TestPlugin
{
    [Export(typeof(IPlugin))]
    public class TestPlugin : IPluginPF
    {
        public IPluginHostPF Host { get; set; }
        private ToolStrip m_toolstrip;
        private UserControl m_testForm;

        public void Initialize(IPluginHostPF host)
        {
            Host = host;
            ToolStripTest();
            KeystrokeActionTest();
            TestForm();
        }

        private void ToolStripTest()
        {
            m_toolstrip = new ToolStrip();
            m_toolstrip.Items.Add(new ToolStripButton("Hello from plugin",null, OnClick));
            m_toolstrip.Items.Add(new ToolStripSeparator());
            m_toolstrip.Items.Add(new ToolStripLabel(Host.OpenedWindows.First().WindowTitle));
            Host.Register(m_toolstrip);
        }

        private void TestForm()
        {
            m_testForm = new DockTestCtrl();
            Host.Register(m_testForm, DockFormStyle.DockRight);
        }

        private void OnClick(object sender, EventArgs eventArgs)
        {
            MessageBox.Show("Hello from plugin!");
        }

        private void KeystrokeActionTest()
        {
            var myAction = new Guid("AC2E5964-3D5B-469B-8CEA-AA4D24822E2B");
            KeystrokeAction action = new KeystrokeAction(myAction, "TestAction", Keys.A, Keys.Control, Callback);
            Host.RegisterKeyStroke(action);
        }

        private void Callback(KeystrokeAction keystrokeAction)
        {
            MessageBox.Show("action keypress: " + keystrokeAction.ActionName);
        }

        public Guid PluginId
        {
            get { return new Guid("A4B71D15-9DDB-40A2-A4F1-0C7DC55DE8DA");}
        }

        public string IconUri
        {
            get { return "https://css-tricks.com/apple-touch-icon.png"; }
        }

        public string Name 
        {
            get
            {
                return "Test plugin";
            }
        }
        public string Description 
        {
            get { return "This a plugin that does absolutely nothing except messing with your UI :)"; }
        }
        public Version Version 
        {
            get { return new Version("1.0.1"); }
        }

        public string CreatedBy
        {
            get { return "Dexter's Laboratory"; }
        }
    }
}
