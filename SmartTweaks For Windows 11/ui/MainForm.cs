using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
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
            var jsonBrute = jsonReader.GetJson(relativePath);
            var jsonArray = jsonBrute.RootElement.EnumerateArray();

            int xOffset = 10;
            int yOffset = 10;
            foreach (var item in jsonArray)
            {
                if (item.TryGetProperty("alias", out var alias))
                {
                    var label = new Label
                    {
                        Text = alias.GetString(),
                        Location = new System.Drawing.Point(xOffset, yOffset),
                        AutoSize = true
                    };
                    this.Controls.Add(label);
                    xOffset += 100;
                }
                if (item.TryGetProperty("cat", out var cat))
                {
                    var label = new Label
                    {
                        Text = cat.GetString(),
                        Location = new System.Drawing.Point(xOffset, yOffset),
                        AutoSize = true
                    };
                    this.Controls.Add(label);
                    xOffset += 100;
                }
                if (item.TryGetProperty("desc", out var desc))
                {
                    var label = new Label
                    {
                        Text = desc.GetString(),
                        Location = new System.Drawing.Point(xOffset, yOffset),
                        AutoSize = true
                    };
                    this.Controls.Add(label);
                    xOffset += 100;
                }
                yOffset += 25;
                xOffset = 10;
            }


           /* foreach (var alias in aliases)
            {
                var label = new Label
                {
                    Text = alias,
                    Location = new System.Drawing.Point(10, yOffset),
                    AutoSize = true
                };
                this.Controls.Add(label);
                yOffset += 25; // Adjust the offset for the next label
            }*/
        }
    }
}