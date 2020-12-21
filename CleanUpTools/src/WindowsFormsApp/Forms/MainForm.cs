using System;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp.Infrastructure;

namespace WindowsFormsApp.Forms
{
    internal partial class MainForm : Form
    {
        readonly SettingsHandler _handler;

        public MainForm(SettingsHandler handler)
        {
            InitializeComponent();

            _handler = handler;

            rtbConsole.Text += $"welcome! initialized app{Environment.NewLine}";
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm(_handler).ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCleanUp_Click(object sender, EventArgs e)
        {
            var directories = _handler.GetDirectories();
            rtbConsole.Text += $"{Environment.NewLine}start clean up {directories.Length} dirctories{Environment.NewLine}";

            for (int i = 0; i < directories.Length; i++)
            {
                rtbConsole.Text += $"clean up {directories[i].Directory.FullName}{Environment.NewLine}";
                // todo validate / handle / logs / duration
                //File.Delete(directories[i].Directory.FullName);
            }

            rtbConsole.Text += $"{Environment.NewLine}clean up done";
        }
    }
}
