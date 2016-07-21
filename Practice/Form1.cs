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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewProcess f = new NewProcess();
            f.Show();
        }
    }
}
