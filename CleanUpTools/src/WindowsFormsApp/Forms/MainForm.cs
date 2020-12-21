using System;
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
        }

        private void ctnSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
