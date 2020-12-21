using System;
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
            lbDirs.Items.Clear();

            foreach (var dir in _handler.Get())
                lbDirs.Items.Add($"{dir}");
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            new AddDirectoryForm(_handler).ShowDialog();

            Initialize();
        }

        void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbDirs.SelectedItem == null || string.IsNullOrWhiteSpace(lbDirs.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select something to remove", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _handler.Remove(lbDirs.SelectedItem.ToString());

            Initialize();
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
