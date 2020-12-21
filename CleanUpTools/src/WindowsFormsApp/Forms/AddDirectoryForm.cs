using System;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp.Infrastructure;

namespace WindowsFormsApp.Forms
{
    internal partial class AddDirectoryForm : Form
    {
        readonly SettingsHandler _handler;

        internal AddDirectoryForm(SettingsHandler handler)
        {
            InitializeComponent();

            _handler = handler;
        }

        void btnSelect_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(ofd.FileName);
                tbDirectory.Text = fileInfo.Directory.FullName;
                tbExtension.Text = fileInfo.Extension;
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbExtension.Text))
                if (MessageBox.Show("Extension is not set! Are you sure this is correct?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;

            _handler.Add(tbDirectory.Text, tbExtension.Text, cbRecursive.Checked);

            CloseForm();
        }

        void btnBack_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        void CloseForm()
        {
            Close();
        }
    }
}
