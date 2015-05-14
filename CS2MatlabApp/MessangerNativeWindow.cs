using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS2MatlabApp
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    class MessangerNativeWindow: NativeWindow, IDisposable
    {
        public const int WM_USER_1 = WindowsAPI.WM_USER+1;
        public const int WM_USER_2 = WindowsAPI.WM_USER+2;


        public MessangerNativeWindow(): base()
        {
            /*var cp = new CreateParams
            {
                Caption = "C198A10C-BB4D-438C-8243-BC573E04E5AB",
                ClassName = "YourExcellentWindowClass",
                X = 0,
                Y = 0,
                Height = 0,
                Width = 0,
                Parent = IntPtr.Zero,
                Style = WindowsAPI.WindowStyles.WS_DISABLED
            };*/

            var cp = new CreateParams()
            {
                Caption = "C198A10C-BB4D-438C-8243-BC573E04E5AB"
            };

            // Fill in the CreateParams details.

            // Create the actual window 
            this.CreateHandle(cp);
        }
        
        /*// Listen to when the handle changes to keep the variable in sync
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void OnHandleChange()
        {
            hWnd = this.Handle;
        }*/

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_USER_1:
                    Console.WriteLine("NativeWindow got WM_USER_1, with Params:\n\t{0}\n\t{1}).", m.WParam, m.LParam);
                    break;
                case WM_USER_2:
                    Console.WriteLine("NativeWindow got WM_USER_1, with Params:\n\t{0}\n\t{1}).", m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public void Dispose()
        {
            base.DestroyHandle();
        }
    }
}
