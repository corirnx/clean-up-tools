using System;
using System.Collections.Generic;
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

        void btnBack_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            for (var i = 0; i < lbDirs.Items.Count; i++)
                list.Add(lbDirs.Items[i].ToString());

            _handler.Save(list.ToArray());

            MessageBox.Show("saved settings successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CloseForm();
        }

        void CloseForm()
        {
            Close();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            new AddDirectoryForm(_handler).ShowDialog();

            Initialize();
        }

        void btnRemove_Click(object sender, EventArgs e)
        {

            var i = lbDirs.SelectedIndex;

            _handler.Remove(i);

            Initialize();
        }
    }
}
