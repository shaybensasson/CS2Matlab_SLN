using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Windows.Forms;

namespace Assets
{
    public static class WindowsAPI
    {
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);

        //For use with WM_COPYDATA and COPYDATASTRUCT
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        //For use with WM_COPYDATA and COPYDATASTRUCT
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(int hWnd);

        public const int WM_USER = 0x400;
        public const int WM_COPYDATA = 0x4A;

        #region WindowsStyles
        public static class WindowStyles
        {

            public static readonly Int32

            WS_BORDER = 0x00800000,

            WS_CAPTION = 0x00C00000,

            WS_CHILD = 0x40000000,

            WS_CHILDWINDOW = 0x40000000,

            WS_CLIPCHILDREN = 0x02000000,

            WS_CLIPSIBLINGS = 0x04000000,

            WS_DISABLED = 0x08000000,

            WS_DLGFRAME = 0x00400000,

            WS_GROUP = 0x00020000,

            WS_HSCROLL = 0x00100000,

            WS_ICONIC = 0x20000000,

            WS_MAXIMIZE = 0x01000000,

            WS_MAXIMIZEBOX = 0x00010000,

            WS_MINIMIZE = 0x20000000,

            WS_MINIMIZEBOX = 0x00020000,

            WS_OVERLAPPED = 0x00000000,

            WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,

            WS_POPUP = unchecked((int)0x80000000),

            WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,

            WS_SIZEBOX = 0x00040000,

            WS_SYSMENU = 0x00080000,

            WS_TABSTOP = 0x00010000,

            WS_THICKFRAME = 0x00040000,

            WS_TILED = 0x00000000,

            WS_TILEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,

            WS_VISIBLE = 0x10000000,

            WS_VSCROLL = 0x00200000;

        }
        #endregion

        //Used for WM_COPYDATA for string messages
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }



        public static int SendWindowsStringMessage(IntPtr hWnd, int wParam, string msg)
        {
            int result = 0;

            if (hWnd != IntPtr.Zero)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(msg);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = msg;
                cds.cbData = len + 1;
                result = SendMessage(hWnd, WM_COPYDATA, wParam, ref cds);
            }

            return result;
        }

        public static int PostMessage(Message msg)
        {
            return PostMessage(msg.HWnd, msg.Msg, msg.LParam, msg.WParam);
        }
    }
}
