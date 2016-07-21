using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var processList = Process.GetProcesses();
            foreach (var proc in processList)
                listBox1.Items.Add(String.Format($"{proc.ProcessName}.exe"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                var taskName = listBox1.Items[listBox1.SelectedIndex].ToString();
                taskName = taskName.Substring(0, taskName.Length - 4);
                foreach (var procToKill in Process.GetProcessesByName(taskName))
                    procToKill.Kill();
                button1.PerformClick();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button2.PerformClick();
            //BrowsApp(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        //public void BrowsApp(string nameApp)
        //{
        //    WindowsIdentity identity = WindowsIdentity.GetCurrent();
        //    if (identity != null)
        //    {
        //        string currentUser = identity.Name.Split('\\')[1];

        //        string query = "Select * from Win32_Process Where Name = \"" + nameApp + "\"";
        //        var searcher = new ManagementObjectSearcher(query);
        //        var processes = searcher.Get();

        //        foreach (ManagementObject proc in processes)
        //        {
        //            string owner;
        //            var argList = new[] { string.Empty };
        //            int returnVal = Convert.ToInt32(proc.InvokeMethod("GetOwner", argList));
        //            if (returnVal == 0)
        //                owner = argList[0];
        //            else
        //                continue;

        //            if (owner != currentUser)
        //                continue;

        //            MessageBox.Show(proc["ExecutablePath"].ToString());
        //        }
        //    }
        //}
    }
}
