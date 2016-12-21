using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joy2Key
{
    public delegate void UpdateSettingsHandle(bool saveSettings);//定义委托
    public partial class JoystickSettings : Form
    {
        private Configuration config;
        
        public UpdateSettingsHandle UpdateSettings;

        public JoystickSettings()
        {
            InitializeComponent();
            //获取Configuration对象
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            LoadSettings();
        }

        private void LoadSettings()
        {
            //根据Key读取<add>元素的Value
            // leftRaduis.Text = config.AppSettings.Settings["scale"].Value;
            //leftOriginX.Text = config.AppSettings.Settings["leftStickOriginX"].Value;
            //leftOriginY.Text = config.AppSettings.Settings["leftStickOriginY"].Value;
            leftRaduis.Text = GetConfigValue("scale");
            leftOriginX.Text = GetConfigValue("leftStickOriginX");
            leftOriginY.Text = GetConfigValue("leftStickOriginY");
            //写入<add>元素的Value
            //config.AppSettings.Settings["name"].Value = "xieyc";
            //增加<add>元素
            //config.AppSettings.Settings.Add("url", "<a class="vglnk" </a>");
            //删除<add>元素                                                                                   
            // config.AppSettings.Settings.Remove("name");
            //一定要记得保存，写不带参数的config.Save()也可以
            // config.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            // System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }
        public static string GetConfigValue(string key)
        {
           // Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings[key].Value;
        }

        public static void SetConfigValue(string key,string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void SaveSettings()
        {
            //根据Key读取<add>元素的Value
           // config.AppSettings.Settings["scale"].Value = leftRaduis.Text;
           // config.AppSettings.Settings["leftStickOriginX"].Value = leftOriginX.Text;
           // config.AppSettings.Settings["leftStickOriginY"].Value = leftOriginY.Text;
            SetConfigValue("scale", leftRaduis.Text);
            SetConfigValue("leftStickOriginX", leftOriginX.Text);
            SetConfigValue("leftStickOriginY", leftOriginY.Text);

            //写入<add>元素的Value
            //config.AppSettings.Settings["name"].Value = "xieyc";
            //增加<add>元素
            //config.AppSettings.Settings.Add("url", "<a class="vglnk" </a>");
            //删除<add>元素                                                                                   
            // config.AppSettings.Settings.Remove("name");
            //一定要记得保存，写不带参数的config.Save()也可以
            //config.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            ConfigurationManager.RefreshSection("appSettings");

            UpdateSettings(true);//回调函数，通知form1更新参数
        }

        private void leftOriginX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void leftOriginY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void leftRaduis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
