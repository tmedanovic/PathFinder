using System;
using System.Windows.Forms;

namespace PathFinder.Core
{
    public class KeystrokeAction
    {
        public KeystrokeAction(Guid actionId, string actionName, Keys defaultKeys, Keys modifiers, Action<KeystrokeAction> callback)
        {
            ActionId = actionId;
            ActionName = actionName;
            DefaultKeys = defaultKeys;
            Callback = callback;
        }

        public Guid ActionId { get; set; }

        public string ActionName { get; set; }

        public string ActionCategory { get; set; }

        public Keys Modifiers { get; set; }

        public Keys DefaultKeys { get; set; }

        public Action<KeystrokeAction> Callback { get; set; }
    }
}
