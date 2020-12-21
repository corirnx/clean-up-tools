using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp.Infrastructure;

namespace WindowsFormsApp.Forms
{
    internal partial class SettingsForm : Form
    {
        readonly SettingsHandler _handler;

        internal SettingsForm(SettingsHandler handler)
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

        void btnBack_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (!SettingsValidator.ValidateText(rtbContent.Text))
            {
                MessageBox.Show("settings are not valid - please check format: directory.fullname;extension;recursive;", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _handler.SaveSettings(rtbContent.Text);

            MessageBox.Show("saved settings successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CloseForm();
        }

        void CloseForm()
        {
            Close();
        }
    }
}
