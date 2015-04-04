using System;
using PathFinder.Core;
using WeifenLuo.WinFormsUI.Docking;

namespace PathFinder.WinForms.Helpers
{
    public static class DockStyleExtensions
    {
        public static DockState ToDockState(this DockFormStyle formStyle)
        {
            switch (formStyle)
            {
                case DockFormStyle.Unknown:
                    return DockState.Unknown;
                case DockFormStyle.Float:
                    return DockState.Float;
                case DockFormStyle.DockTopAutoHide:
                    return DockState.DockTopAutoHide;
                case DockFormStyle.DockLeftAutoHide:
                    return DockState.DockLeftAutoHide;
                case DockFormStyle.DockBottomAutoHide:
                    return DockState.DockBottomAutoHide;
                case DockFormStyle.DockRightAutoHide:
                    return DockState.DockRightAutoHide;
                case DockFormStyle.Document:
                    return DockState.Document;
                case DockFormStyle.DockTop:
                    return DockState.DockTop;
                case DockFormStyle.DockLeft:
                    return DockState.DockLeft;
                case DockFormStyle.DockBottom:
                    return DockState.DockBottom;
                case DockFormStyle.DockRight:
                    return DockState.DockRight;
                case DockFormStyle.Hidden:
                    return DockState.Hidden;
                default:
                    throw new ArgumentOutOfRangeException("formStyle");
            }
        }
    }
}
