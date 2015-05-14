using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assets;

namespace CS2MatlabApp
{
    public delegate string delString(string message);

    public partial class Form1 : Form
    {
        //private readonly MLApp.MLApp m_MatlabApp;
        //private Messanger m_MessangerForm;

        private PlayerControllerInternal pc;

        public Form1()
        {
            InitializeComponent();

            pc = new PlayerControllerInternal(writeToDebug: true, usingUnityLog: false);
            pc.Start();

            // Create the MATLAB app instance 
            //m_MatlabApp = new MLApp.MLApp();

            //m_MatlabApp.MaximizeCommandWindow();
            //m_MatlabApp.Visible = 0;

            //m_MessangerForm = new Messanger();


            //TODO: Oren uncomment this if you'd like the messanger form to be hidden
            //m_MessangerForm.Visible = false;

            //m_MessangerForm.Show();

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //m_MatlabApp.Quit();
            //m_MessangerForm.Close();
            //m_MessangerForm.Dispose();
            //m_MessangerForm = null;

            pc.Dispose();
            
        }

        private void btnRunSync_Click(object sender, EventArgs e)
        {
            /*//http://www.mathworks.com/help/matlab/matlab_external/calling-net-methods-asynchronously.html
            //System.Threading.Thread.Sleep(1000);

            // Change to the directory where the function is located 
            //m_MatlabApp.Execute(@"cd c:\temp\example");
            var path = Path.GetFullPath(@"..\..\)");
            path = path.Substring(0, path.Length - 1);
            m_MatlabApp.Execute(string.Format(@"cd {0}", path));

            // Define the output 
            object result = null;

            using (var proxy = new ComClass1(m_MessangerForm))
            {
                // Call the MATLAB function
                m_MatlabApp.Feval("startMatlabApplication", 0, out result, proxy);
               
                //NOTE: result is redundant
            }*/

        }
    }
}
