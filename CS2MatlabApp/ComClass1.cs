using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS2MatlabApp
{
    [Guid("D6F88E95-8A27-4ae6-B6DE-0542A0FC7039")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ComClass1Interface
    {
        [DispId(1)]
        int PostMessage1(int wParam, int lParam);

        [DispId(2)]
        int PostMessage2(int wParam, int lParam);
    }



    [Guid("13FE32AD-4BF8-495f-AB4D-6C61BD463EA4")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Matlab2Unity.ComClass")]
    public class ComClass1 : ComClass1Interface, IDisposable
    {
        private readonly Messanger m_Messanger;

        public ComClass1()
        {
        }

        internal ComClass1(Messanger messanger): this()
        {
            this.m_Messanger = messanger;
        }
        
        public int PostMessage1(int wParam, int lParam)
        {
            Message msg = Message.Create(m_Messanger.Handle,
                Messanger.WM_USER_1,
                (IntPtr)wParam,
                (IntPtr)lParam);
            WindowsAPI.PostMessage(msg);
            return 1;
        }

        public int PostMessage2(int wParam, int lParam)
        {
            Message msg = Message.Create(m_Messanger.Handle,
                Messanger.WM_USER_2,
                (IntPtr)wParam,
                (IntPtr)lParam);
            WindowsAPI.PostMessage(msg);
            return 1;
        }

        public void Dispose()
        {
            
        }
    }
}
