using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SelfUpdaterTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var CurrentVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            var Args = Environment.GetCommandLineArgs();
            foreach (var Argument in Args)
                if (Argument == "ShowVersion")
                    ShowVersionAndExit(CurrentVersion);
            textBoxVersion.Text = CurrentVersion;
        }

        void ShowVersionAndExit(string CurrentVersion)
        {
            MessageBox.Show("Версия программы " + CurrentVersion);
            Environment.Exit(1);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var FilePath = Path.GetDirectoryName(Application.ExecutablePath);
                var FileName = Path.GetFileName(Application.ExecutablePath);
                var OldFile = Application.ExecutablePath + "_old";
                File.Move(Application.ExecutablePath, OldFile);
                File.Copy(String.Format("{0}/new/{1}", FilePath, FileName), Application.ExecutablePath);
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = String.Format("/c ping localhost & del {0} & start {1}", OldFile, Application.ExecutablePath),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
