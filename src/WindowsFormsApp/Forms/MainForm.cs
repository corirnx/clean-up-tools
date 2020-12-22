using System;
using System.Windows.Forms;
using WindowsFormsApp.Infrastructure;

namespace WindowsFormsApp.Forms
{
    internal partial class MainForm : Form
    {
        readonly SettingsHandler _handler;
        readonly CleanUpHandler _cleanUp;

        internal MainForm(SettingsHandler handler)
        {
            InitializeComponent();

            _handler = handler;
            _cleanUp = new CleanUpHandler();

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

            rtbConsole.Text += $"{Environment.NewLine}start clean up {directories.Length} dirctories{Environment.NewLine}{Environment.NewLine}";

            try
            {
                for (int i = 0; i < directories.Length; i++)
                {
                    var resultLines = _cleanUp.TryDeleteFiles(directories[i]);

                    for (int j = 0; j < resultLines.Length; j++)
                        rtbConsole.Text += $"{resultLines[j]}{Environment.NewLine}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                rtbConsole.Text += $"{Environment.NewLine}clean up done{Environment.NewLine}";
            }
        }
    }
}
