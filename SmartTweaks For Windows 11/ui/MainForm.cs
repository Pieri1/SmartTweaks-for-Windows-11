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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            var comboBoxItems = new List<string>();
            int yTaskOffset = 30;
            int yDeskOffset = 30;
            int yExpOffset = 30;
            var tabTaskbar = new TabPage("Taskbar");
            var tabDesktop = new TabPage("Desktop");
            var tabExplorer = new TabPage("Explorer");


            foreach (var item in jsonArray)
            {
                comboBoxItems.Clear();
                if (item.TryGetProperty("name", out var name))
                {
                    if (item.TryGetProperty("alias", out var alias))
                    {
                        if (item.TryGetProperty("cat", out var cat))
                        {
                            if (item.TryGetProperty("opts", out var opts))
                            {
                                foreach (var opt in opts.EnumerateArray())
                                {
                                    if (opt.TryGetProperty("state", out var state))
                                    {
                                        comboBoxItems.Add(state.GetString());
                                    }
                                }

                                if (cat.GetString() == "Taskbar")
                                {
                                    var rowTemplate = new RowTemplate
                                    {
                                        Location = new System.Drawing.Point(30, yTaskOffset),
                                        RowchkboxText = name.GetString(),
                                        AutoSize = true
                                    };
                                    rowTemplate.SetComboBoxItems(comboBoxItems, alias.GetString());
                                    yTaskOffset += rowTemplate.Height + 10;
                                    tabTaskbar.Controls.Add(rowTemplate);
                                }
                                else if (cat.GetString() == "Desktop")
                                {
                                    var rowTemplate = new RowTemplate
                                    {
                                        Location = new System.Drawing.Point(30, yDeskOffset),
                                        RowchkboxText = name.GetString(),
                                        AutoSize = true
                                    };
                                    rowTemplate.SetComboBoxItems(comboBoxItems, alias.GetString());
                                    yDeskOffset += rowTemplate.Height + 10;
                                    tabDesktop.Controls.Add(rowTemplate);
                                }
                                else if (cat.GetString() == "Explorer")
                                {
                                    var rowTemplate = new RowTemplate
                                    {
                                        Location = new System.Drawing.Point(30, yExpOffset),
                                        RowchkboxText = name.GetString(),
                                        AutoSize = true
                                    };
                                    rowTemplate.SetComboBoxItems(comboBoxItems, alias.GetString());
                                    yExpOffset += rowTemplate.Height + 10;
                                    tabExplorer.Controls.Add(rowTemplate);
                                }
                            }
                        }
                    }
                }
            }
            tabctrl.TabPages.Add(tabDesktop);
            tabctrl.TabPages.Add(tabExplorer);
            tabctrl.TabPages.Add(tabTaskbar);

        }
    }
}