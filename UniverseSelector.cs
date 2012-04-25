using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GalaxySmash
{
    public partial class UniverseSelector : Form
    {
        private string _selectedUniverseID = string.Empty;

        public UniverseSelector()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void UniverseSelector_Load(object sender, EventArgs e)
        {
            List<string> universeIDs = SettingsLocal.AllValuesAsString("UniverseID");

            listUniverses.Items.Clear();

            listUniverses.Items.AddRange(universeIDs.ToArray());

            listUniverses.SelectedIndex = 0;
        }

        public string SelectedUniverseID
        {
            get { return _selectedUniverseID; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _selectedUniverseID = listUniverses.Items[listUniverses.SelectedIndex].ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
