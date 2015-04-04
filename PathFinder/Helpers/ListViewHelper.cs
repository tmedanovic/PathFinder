using System;
using System.Runtime.InteropServices;

namespace PathFinder.WinForms.Helpers
{
    public enum ListViewExtendedStyles
    {
        /// <summary>
        /// LVS_EX_GRIDLINES
        /// </summary>
        GridLines = 0x00000001,
        /// <summary>
        /// LVS_EX_SUBITEMIMAGES
        /// </summary>
        SubItemImages = 0x00000002,
        /// <summary>
        /// LVS_EX_CHECKBOXES
        /// </summary>
        CheckBoxes = 0x00000004,
        /// <summary>
        /// LVS_EX_TRACKSELECT
        /// </summary>
        TrackSelect = 0x00000008,
        /// <summary>
        /// LVS_EX_HEADERDRAGDROP
        /// </summary>
        HeaderDragDrop = 0x00000010,
        /// <summary>
        /// LVS_EX_FULLROWSELECT
        /// </summary>
        FullRowSelect = 0x00000020,
        /// <summary>
        /// LVS_EX_ONECLICKACTIVATE
        /// </summary>
        OneClickActivate = 0x00000040,
        /// <summary>
        /// LVS_EX_TWOCLICKACTIVATE
        /// </summary>
        TwoClickActivate = 0x00000080,
        /// <summary>
        /// LVS_EX_FLATSB
        /// </summary>
        FlatsB = 0x00000100,
        /// <summary>
        /// LVS_EX_REGIONAL
        /// </summary>
        Regional = 0x00000200,
        /// <summary>
        /// LVS_EX_INFOTIP
        /// </summary>
        InfoTip = 0x00000400,
        /// <summary>
        /// LVS_EX_UNDERLINEHOT
        /// </summary>
        UnderlineHot = 0x00000800,
        /// <summary>
        /// LVS_EX_UNDERLINECOLD
        /// </summary>
        UnderlineCold = 0x00001000,
        /// <summary>
        /// LVS_EX_MULTIWORKAREAS
        /// </summary>
        MultilWorkAreas = 0x00002000,
        /// <summary>
        /// LVS_EX_LABELTIP
        /// </summary>
        LabelTip = 0x00004000,
        /// <summary>
        /// LVS_EX_BORDERSELECT
        /// </summary>
        BorderSelect = 0x00008000,
        /// <summary>
        /// LVS_EX_DOUBLEBUFFER
        /// </summary>
        DoubleBuffer = 0x00010000,
        /// <summary>
        /// LVS_EX_HIDELABELS
        /// </summary>
        HideLabels = 0x00020000,
        /// <summary>
        /// LVS_EX_SINGLEROW
        /// </summary>
        SingleRow = 0x00040000,
        /// <summary>
        /// LVS_EX_SNAPTOGRID
        /// </summary>
        SnapToGrid = 0x00080000,
        /// <summary>
        /// LVS_EX_SIMPLESELECT
        /// </summary>
        SimpleSelect = 0x00100000,

        //LVS_EX_HEADERINALLVIEWS = 0x02000000;
        HeaderInAllViews = 0x02000000
    }

    public enum ListViewMessages
    {
        First = 0x1000,
        SetExtendedStyle = 0x1036,
        GetExtendedStyle = 0x1037,
    }

    /// <summary>
    /// Contains helper methods to change extended styles on ListView, including enabling double buffering.
    /// Based on Giovanni Montrone's article on <see cref="http://www.codeproject.com/KB/list/listviewxp.aspx"/>
    /// </summary>
    public class ListViewHelper
    {
        private ListViewHelper()
        {
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            UInt32 msg,
            IntPtr wParam,
            IntPtr lParam);

        private const int SetExtendedStyle = 0x1036;

        /// <summary>
        /// The LVM_GETEXTENDEDLISTVIEWSTYLE message.
        /// </summary>
        private const int GetExtendedStyle = 0x1037;

        public static void AddStyle(IntPtr handle, ListViewExtendedStyles style)
        {
            // Read the current style.
            int styles;
            styles = SendMessage(handle, GetExtendedStyle, IntPtr.Zero, IntPtr.Zero).ToInt32();

            // Enable double buffering and border select.
            styles |= (int)style;

            // Write the new style.
            SendMessage(handle, SetExtendedStyle, IntPtr.Zero, (IntPtr)styles);
        }


        public static void RemoveStyle(IntPtr handle, ListViewExtendedStyles style)
        {
            // Read the current style.
            int styles;
            styles = SendMessage(handle, GetExtendedStyle, IntPtr.Zero, IntPtr.Zero).ToInt32();

            // Disable double buffering and border select.
            styles -= styles & (int)style;

            // Write the new style.
            SendMessage(handle, SetExtendedStyle, IntPtr.Zero, (IntPtr)styles);
        }
    }
}
