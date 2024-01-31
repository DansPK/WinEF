using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WinEF
{
    public partial class WinEF_Interface : Form
    {
        public WinEF_Interface()
        {
            InitializeComponent();
        }

        public void ExercutePowershellScript()
        {

            string scriptPath = "\\WinEF\\WinEF\\Script\\Test\\Hello.ps1";
            

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -File \"{scriptPath}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                Console.WriteLine("PowerShell Output: " + output);
            }


        }   
        private void WinEF_Interface_Load(object sender, EventArgs e)
        {
            

        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            ExercutePowershellScript();
        }
    }
}
