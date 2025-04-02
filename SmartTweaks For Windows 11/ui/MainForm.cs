using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
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

        private void tabctrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDesc.Text = "Hover to show description";
        }

        private void SetUpForm()
        {
            var jsonReader = new JsonReader();
            var registryAgent = new RegistryAgent();
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
                bool dftopt = false;
                string curcfg = null;
                comboBoxItems.Clear();
                int comboBoxIndex = 0;
                if (item.TryGetProperty("name", out var name))
                {
                    if(item.TryGetProperty("desc", out var desc))
                        if (item.TryGetProperty("alias", out var alias))
                        {
                            if (item.TryGetProperty("cat", out var cat))
                            {
                                if (item.TryGetProperty("opts", out var opts))
                                {
                                    if (item.TryGetProperty("reg", out var reg))
                                    {
                                        if (item.TryGetProperty("key", out var key))
                                        {
                                            curcfg = registryAgent.RegRead(reg.GetString(), key.GetString());
                                        }
                                        else
                                        {
                                            curcfg = registryAgent.RegRead(reg.GetString());
                                        }
                                    }
                                    dftopt = false;
                                    foreach (var opt in opts.EnumerateArray())
                                    {
                                        if (opt.TryGetProperty("state", out var state))
                                        {
                                            if (opt.TryGetProperty("value", out var value))
                                            {
                                                if (opt.Equals(opts.EnumerateArray().Last()) && dftopt == false)
                                                {
                                                    comboBoxItems.Add(state.GetString() + " (On Use)");
                                                    comboBoxIndex = comboBoxItems.Count - 1;
                                                }
                                                else if (curcfg == value.GetString())
                                                {
                                                    dftopt = true;
                                                    comboBoxItems.Add(state.GetString() + " (On Use)");
                                                    comboBoxIndex = comboBoxItems.Count - 1;
                                                }
                                                else
                                                {
                                                    comboBoxItems.Add(state.GetString());
                                                }
                                            }
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

                                        rowTemplate.MouseEnter += (sender, e) => lblDesc.Text = desc.ToString();

                                        rowTemplate.SetComboBoxItems(comboBoxItems, alias.GetString(),comboBoxIndex);
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

                                        rowTemplate.MouseEnter += (sender, e) => lblDesc.Text = desc.ToString();

                                        rowTemplate.SetComboBoxItems(comboBoxItems, alias.GetString(),comboBoxIndex);
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

                                        rowTemplate.MouseEnter += (sender, e) => lblDesc.Text = desc.ToString();

                                        rowTemplate.SetComboBoxItems(comboBoxItems, alias.GetString(), comboBoxIndex);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblDesc_Click(object sender, EventArgs e)
        {

        }
    }
}