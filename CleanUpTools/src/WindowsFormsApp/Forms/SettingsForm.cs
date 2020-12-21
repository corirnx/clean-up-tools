using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp.Infrastructure;

namespace WindowsFormsApp.Forms
{
    internal partial class SettingsForm : Form
    {
        readonly SettingsHandler _handler;

        public SettingsForm(SettingsHandler handler)
        {
            InitializeComponent();

            _handler = handler;
            Initialize();
        }

        void Initialize()
        {
            var dir = _handler.GetDirectories();
            // todo
            foreach (var d in dir)
                rtbContent.Text += $"{d.Directory.FullName};{d.Extension};{d.Recursive.ToString()};{Environment.NewLine}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var lines = rtbContent.Text.Split(Environment.NewLine);
            if (!lines.Any())
                return; // todo info

            _handler.SaveSettings(rtbContent.Text);

            // todo info

            return;
        }
    }
}
