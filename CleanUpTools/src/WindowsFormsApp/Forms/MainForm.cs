using System;
using System.Windows.Forms;
using WindowsFormsApp.Infrastructure;

namespace WindowsFormsApp.Forms
{
    internal partial class MainForm : Form
    {
        readonly SettingsHandler _handler;

        internal MainForm(SettingsHandler handler)
        {
            InitializeComponent();

            _handler = handler;

            rtbConsole.Text += $"welcome! initialized app{Environment.NewLine}";
        }

        void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm(_handler).ShowDialog();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        void btnCleanUp_Click(object sender, EventArgs e)
        {
            var directories = _handler.Get();
            // todo

            rtbConsole.Text += $"{Environment.NewLine}start clean up {directories.Length} dirctories{Environment.NewLine}";

            for (int i = 0; i < directories.Length; i++)
            {
                var dir = directories[i].Split(';');
                rtbConsole.Text += $"clean up {dir[0]}{Environment.NewLine}";
                // todo logs / duration
                // todo recursive
                //File.Delete(directories[i].Directory.FullName);
            }

            rtbConsole.Text += $"{Environment.NewLine}clean up done{Environment.NewLine}";
        }
    }
}
