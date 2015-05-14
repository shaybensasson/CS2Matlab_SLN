using System;
using System.Windows.Forms;

namespace Assets
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class MessangerNativeWindow: NativeWindow, IDisposable
    {
        
        public const int WM_USER_1 = WindowsAPI.WM_USER + 1;
        public const int WM_USER_2 = WindowsAPI.WM_USER + 2;

        private readonly bool m_writeToDebug;

        public event EventHandler<MessageRecievedEventArgs> MessageRecieved;

        public MessangerNativeWindow(bool writeToDebug)
            : base()
        {
            m_writeToDebug = writeToDebug;

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
                Caption = "Matlab-to-Unity Messanger Window"
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
                    if (m_writeToDebug)
                        Console.WriteLine("NativeWindow got WM_USER_1, with Params:\n\t{0}\n\t{1}).", m.WParam, m.LParam);

                    OnMessageRecieved(m, "WM_USER_1");
                    break;
                case WM_USER_2:

                    if (m_writeToDebug)
                        Console.WriteLine("NativeWindow got WM_USER_2, with Params:\n\t{0}\n\t{1}).", m.WParam, m.LParam);

                    OnMessageRecieved(m, "WM_USER_2");
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void OnMessageRecieved(Message m, string messageName)
        {
            try
            {
                var customMessage = (CustomMessages)Enum.Parse(typeof(CustomMessages), messageName);
                OnMessageRecieved(new MessageRecievedEventArgs(customMessage, (int)m.WParam, (int)m.LParam));
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                        "{0}: ERROR OCCURED ON HandleMatlabMessageEvent(): {1}\t{2}",
                        DateTime.Now.ToLongTimeString(), Environment.NewLine,
                        ex);
            }


        }

        private void OnMessageRecieved(MessageRecievedEventArgs ea)
        {
            if (MessageRecieved != null)
                MessageRecieved(this, ea);
        }

        public void Dispose()
        {
            base.DestroyHandle();
        }
    }
}
