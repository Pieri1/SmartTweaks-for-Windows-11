using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
            SetUpForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void SetUpForm()
        {
            var jsonReader = new JsonReader();
            // Maybe this path will be a problem when the application is installed on a different machine
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\data\config.json");
            var jsonBrute = jsonReader.GetJson(relativePath);
            var jsonArray = jsonBrute.RootElement.EnumerateArray();

            int xOffset = 30;
            int yOffset = 30;
            foreach (var item in jsonArray)
            {
                if (item.TryGetProperty("name", out var name))
                {
                    var label = new Label
                    {
                        Text = name.GetString(),
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
                    xOffset += 500;
                }
                if(item.TryGetProperty("alias", out var alias))
                {
                    if (item.TryGetProperty("opts", out var opts))
                    {
                        var comboBox = new ComboBox
                        {
                            Tag = alias.GetString(),
                            Location = new System.Drawing.Point(xOffset, yOffset),
                            Width = 200
                        };

                        foreach (var opt in opts.EnumerateArray())
                        {
                            if (opt.TryGetProperty("state", out var state))
                            {
                                comboBox.Items.Add(state.GetString());
                            }
                        }

                        this.Controls.Add(comboBox);
                        xOffset += 210;
                    }
                }

                yOffset += 35;
                xOffset = 30;
            }
        }
    }
}