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
            saveState();
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
            tabctrl.TabPages.Clear();
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
                                                if (curcfg == null)
                                                {
                                                    curcfg = "";
                                                }

                                                if (opt.Equals(opts.EnumerateArray().Last()) && dftopt == false)
                                                {
                                                    Console.WriteLine("alias: " + alias + "curcfg: " + curcfg + " ,value: " + value.GetString());
                                                    comboBoxItems.Add(state.GetString() + "(On Use)");
                                                    comboBoxIndex = comboBoxItems.Count - 1;
                                                }
                                                else if (curcfg.Equals(value.GetString()))
                                                {
                                                    Console.WriteLine("alias: " + alias + "curcfg: " + curcfg + " ,value: " + value.GetString());
                                                    dftopt = true;
                                                    comboBoxItems.Add(state.GetString() + "(On Use)");
                                                    comboBoxIndex = comboBoxItems.Count - 1;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("alias: " + alias + "curcfg: " + curcfg + " ,value: " + value.GetString());
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

        private string updateTempPs1()
        {
            // Maybe this path will be a problem when the application is installed on a different machine
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\data\config.json");
            string ps1Path = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\configs\Run.ps1");
            SettingAgent settingAgent = new SettingAgent();
            JsonReader jsonReader = new JsonReader();
            RegistryAgent registryAgent = new RegistryAgent();
            settingAgent.ClearPs1File(ps1Path);
            settingAgent.StartingPs1File(ps1Path);
            foreach (TabPage tabPage in tabctrl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is RowTemplate rowTemplate)
                    {
                        if (rowTemplate.RowchkboxCheck)
                        {
                            string cmdline = jsonReader.GetCmdString(relativePath, rowTemplate.RowcmbboxTag, rowTemplate.RowcmbboxText);
                            settingAgent.AppendToPs1File(cmdline, ps1Path);
                        }
                    }
                }
            }
            settingAgent.EndingPs1File(ps1Path);
            return ps1Path;
        }

        private void changeCheckBoxState(bool state)
        {
            foreach (TabPage tabPage in tabctrl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is RowTemplate rowTemplate)
                    {
                        rowTemplate.RowchkboxCheck = state;
                    }
                }
            }
        }

        private void saveState()
        {
            // Maybe this path will be a problem when the application is installed on a different machine
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\data\config.json");
            string Ps1Path = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\configs\SaveState.ps1");
            SettingAgent settingAgent = new SettingAgent();
            JsonReader jsonReader = new JsonReader();
            RegistryAgent registryAgent = new RegistryAgent();
            settingAgent.ClearPs1File(Ps1Path);
            settingAgent.StartingPs1File(Ps1Path);
            foreach (TabPage tabPage in tabctrl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is RowTemplate rowTemplate)
                    {
                        string cmdline = jsonReader.GetCmdString(relativePath, rowTemplate.RowcmbboxTag, rowTemplate.RowcmbboxText);
                        settingAgent.AppendToPs1File(cmdline, Ps1Path);
                    }
                }
            }
            settingAgent.EndingPs1File(Ps1Path);
        }

        private void btnexecute_Click(object sender, EventArgs e)
        {
            // Maybe this path will be a problem when the application is installed on a different machine
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string SaveStatePath = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\configs\SaveState.ps1");
            string BackUpPath = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\configs\BackUp.ps1");
            SettingAgent settingAgent = new SettingAgent();
            RegistryAgent registryAgent = new RegistryAgent();
            settingAgent.BackupPs1File(SaveStatePath, BackUpPath);
            saveState();
            string ps1Path = updateTempPs1();
            registryAgent.RunPs1File(ps1Path);
            SetUpForm();
            btnrevert.Enabled = true;
        }

        private void lblDesc_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SettingAgent settingAgent = new SettingAgent();
            string ps1Path = updateTempPs1();
            settingAgent.SavePs1File(ps1Path);
        }

        private void btnrevert_Click(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string BackUpPath = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\configs\BackUp.ps1");
            RegistryAgent registryAgent = new RegistryAgent();
            registryAgent.RunPs1File(BackUpPath);
            SetUpForm();
            btnrevert.Enabled = false;
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            JsonReader jsonReader = new JsonReader();
            SettingAgent settingAgent = new SettingAgent();
            // Maybe this path will be a problem when the application is installed on a different machine
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\data\config.json");
            var jsonBrute = jsonReader.GetJson(relativePath);
            var jsonArray = jsonBrute.RootElement.EnumerateArray();
            var scriptLines = settingAgent.ReadPs1File();
            foreach (TabPage tabPage in tabctrl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is RowTemplate rowTemplate)
                    {
                        var item = jsonReader.GetJsonItem(relativePath, rowTemplate.RowcmbboxTag);
                        if (item.Value.TryGetProperty("opts", out var opts))
                        {
                            foreach (var opt in opts.EnumerateArray())
                            {
                                if (opt.TryGetProperty("cmd", out var cmd))
                                {
                                    foreach(var line in scriptLines)
                                    {
                                        if (line.Contains(cmd.GetString()))
                                        {
                                            if (opt.TryGetProperty("state", out var state))
                                            {
                                                rowTemplate.SelectComboBoxItem(opt.GetProperty("state").GetString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btnselect_Click(object sender, EventArgs e)
        {
            changeCheckBoxState(true);
        }

        private void btndeselect_Click(object sender, EventArgs e)
        {
            changeCheckBoxState(false);
        }
    }
}