using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnityEngine;


namespace Assets
{
    public class PlayerControllerInternal: IDisposable
    {
        public event EventHandler<MessageRecievedEventArgs> MessageRecieved;

        private MessangerNativeWindow m_Messanger;
        private readonly bool m_usingUnityLog;
        private readonly bool m_writeToDebug;

        public PlayerControllerInternal(bool writeToDebug, bool usingUnityLog)
        {
            m_writeToDebug = writeToDebug;
            m_usingUnityLog = usingUnityLog;
        }

        public void Start()
        {
            WriteDebug("Starting ...");

            m_Messanger = new MessangerNativeWindow(m_writeToDebug);

            m_Messanger.MessageRecieved += MessangerMessageRecieved;
        }

        private void WriteDebug(string format, params object[] args)
        {
            if (m_writeToDebug)
            {
                if (m_usingUnityLog)
                {
                    //MessageBox.Show(string.Format(format, args), "WriteDebug");
                    Debug.Log(string.Format(format, args));
                }
                else
                {
                    Console.WriteLine(format, args);
                }
            }
        }

        void MessangerMessageRecieved(object sender, MessageRecievedEventArgs e)
        {
            switch (e.Msg)
            {
                case CustomMessages.WM_USER_1:
                    WriteDebug(string.Format("We Got WM_USER_1 with parameter {0}, {1}", e.WParam, e.LParam));
                    break;

                case CustomMessages.WM_USER_2:
                    WriteDebug(string.Format("We Got WM_USER_2 with parameter {0}, {1}", e.WParam, e.LParam));
                    break;

                default:
                    WriteDebug(string.Format("UNIMPLEMENTED MESSAGE RECIEVED, {0}!", e.Msg));
                    return;
            }

            OnMessageRecieved(e);
        }

        private void OnMessageRecieved(MessageRecievedEventArgs ea)
        {
            if (MessageRecieved != null)
                MessageRecieved(this, ea);
        }

        public void Dispose()
        {
            WriteDebug("Disposing ...");

            try
            {
                m_Messanger.MessageRecieved -= MessangerMessageRecieved;
                m_Messanger.Dispose();
            }
            catch (Exception ex)
            {
                WriteDebug("ERROR when disposing messanger:{0}\t{1}", Environment.NewLine, ex.ToString());
            }
            finally
            {
                m_Messanger = null;
            }

            WriteDebug("Disposed.");
        }
    }
}
