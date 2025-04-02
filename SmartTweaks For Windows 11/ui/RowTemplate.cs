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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RowTemplate_Load(object sender, EventArgs e)
        {

        }
    }
}
