using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS2MatlabApp
{
    public partial class Messanger : Form
    {
        public const int WM_USER_1 = WindowsAPI.WM_USER + 1;
        public const int WM_USER_2 = WindowsAPI.WM_USER + 2;

        public Messanger()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_USER_1:
                    OnMessageRecieved(m, "WM_USER_1");
                    break;
                case WM_USER_2:
                    OnMessageRecieved(m, "WM_USER_2");
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void OnMessageRecieved(Message m, string messageName)
        {
            textBoxDescription.AppendText(string.Format(
                "{0}: Got {2}, with Params:{1}\t{3}{1}\t{4}{1}", 
                DateTime.Now.ToLongTimeString(), Environment.NewLine,
                messageName, m.WParam, m.LParam));


            try
            {
                var customMessage = (CustomMessages) Enum.Parse(typeof (CustomMessages), messageName);
                HandleMatlabMessageEvent(customMessage, (int) m.WParam, (int) m.LParam);
            }
            catch (Exception ex)
            {
                textBoxDescription.AppendText(
                    string.Format(
                        "{0}: ERROR OCCURED ON HandleMatlabMessageEvent(): {1}\t{2}",
                        DateTime.Now.ToLongTimeString(), Environment.NewLine,
                        ex));
            }


        }

        private void HandleMatlabMessageEvent(CustomMessages msg, int lParam, int wParam)
        {
            switch (msg)
            {
                    case CustomMessages.WM_USER_1:
                        //TODO: OREN IMPLEMENT YOUR CODE HERE
                        break;

                    case CustomMessages.WM_USER_2:
                        break;
            }
        }

        enum CustomMessages
        {
            WM_USER_1,
            WM_USER_2
        }
    }
}
