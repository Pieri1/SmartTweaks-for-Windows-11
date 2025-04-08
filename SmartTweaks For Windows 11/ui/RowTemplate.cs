using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTweaks_For_Windows_11.ui
{
    public partial class RowTemplate : UserControl
    {
        public RowTemplate()
        {
            InitializeComponent();
        }

        public string RowchkboxText
        {
            get => rowchkbox.Text;
            set => rowchkbox.Text = value;
        }

        public void SetComboBoxItems(IEnumerable<string> items, string alias, int selectedindex)
        {
            rowcmbbox.Items.Clear();
            rowcmbbox.Items.AddRange(items.ToArray());
            rowcmbbox.Tag = alias;
            rowcmbbox.SelectedIndex = selectedindex;
        }

        public bool RowchkboxCheck
        {
            get => rowchkbox.Checked; 
        }

        public string RowcmbboxText
        {
            get => rowcmbbox.SelectedItem.ToString();
        }

        public string RowcmbboxTag
        {
            get => rowcmbbox.Tag.ToString();
        }

        private void Rowchkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (rowchkbox.Checked)
            {
                rowcmbbox.Enabled = true;
            }
            else
            {
                rowcmbbox.Enabled = false;
            }
        }

        private void RowTemplate_Load(object sender, EventArgs e)
        {

        }
    }
}
