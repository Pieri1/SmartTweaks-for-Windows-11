using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartTweaks_For_Windows_11.service;

namespace SmartTweaks_For_Windows_11.ui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AddAliasLabels();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void AddAliasLabels()
        {
            var jsonReader = new JsonReader();
            // Maybe this path will be a problem when the application is installed on a different machine
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\data\config.json");
            var aliases = jsonReader.GetAliasesFromJson(relativePath);

            int yOffset = 10;
            foreach (var alias in aliases)
            {
                var label = new Label
                {
                    Text = alias,
                    Location = new System.Drawing.Point(10, yOffset),
                    AutoSize = true
                };
                this.Controls.Add(label);
                yOffset += 25; // Adjust the offset for the next label
            }
        }
    }
}