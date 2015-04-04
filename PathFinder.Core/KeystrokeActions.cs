using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PathFinder.Core
{
    public class KeystrokeActions
    {
        public static Guid ViewFull = new Guid("EEFB0F0F-5591-4B6F-A2D3-FA88B41A234C");
        public static Guid ViewFlow = new Guid("82DA6167-45C2-40F9-BB2C-A4724D0E0D6E");

        private static readonly List<KeystrokeAction> m_keysActions = new List<KeystrokeAction>();

        public static IEnumerable<KeystrokeAction> RegisteredActions
        {
            get { return m_keysActions.AsEnumerable(); }
        }

        public static void RegisterAction(KeystrokeAction action)
        {
            m_keysActions.Add(action);
        }

        public static void NotifyActions(Keys keys, Keys modifiers)
        {
            foreach (var action in m_keysActions)
            {
                if (action.DefaultKeys == keys && action.Modifiers == modifiers)
                {
                    action.Callback(action);
                }
            }
        }
    }
}
