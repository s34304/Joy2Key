using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DirectInput;
using System.Threading;

using System.Runtime.InteropServices;  //StructLayout
using System.Configuration;  //读取app.config配置文件

namespace Joy2Key
{
    public partial class Form1 : Form
    {
        Thread th;
        DirectInput directInput;
        private Point targPoint;
        private Point nextPoint;
        private Point leftStickOrigin;//左摇杆绘制区域原点
        int scale;
        private bool releaseButton;
        private bool connectionSuccess;


        // Guid joystickGuid;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize DirectInput                    
            directInput = new DirectInput();
            targPoint = new Point(32767, 32767);
            nextPoint = new Point(0, 0);
            releaseButton = true;
            LoadAppSettings();
            connectionSuccess = false;

        }

        private void LoadAppSettings()
        {
            //获取Configuration对象
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //根据Key读取<add>元素的Value
            scale = int.Parse(config.AppSettings.Settings["scale"].Value);
            leftStickOrigin = new Point(int.Parse(config.AppSettings.Settings["leftStickOriginX"].Value), int.Parse(config.AppSettings.Settings["leftStickOriginY"].Value));
                        
        }

        /* ↓↓↓↓↓鼠标模拟↓↓↓↓↓ */
        //结构体布局 本机位置
        //   [StructLayout(LayoutKind.Sequential)]
        /*   struct NativeRECT
           {
               public int left;
               public int top;
               public int right;
               public int bottom;
           }
   */
        //将枚举作为位域处理
        [Flags]
        enum MouseEventFlag : uint //设置鼠标动作的键值
        {
            Move = 0x0001,               //发生移动
            LeftDown = 0x0002,           //鼠标按下左键
            LeftUp = 0x0004,             //鼠标松开左键
            RightDown = 0x0008,          //鼠标按下右键
            RightUp = 0x0010,            //鼠标松开右键
            MiddleDown = 0x0020,         //鼠标按下中键
            MiddleUp = 0x0040,           //鼠标松开中键
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,              //鼠标轮被移动
            VirtualDesk = 0x4000,        //虚拟桌面
            Absolute = 0x8000
        }

        //设置鼠标位置
        //    [DllImport("user32.dll")]
        //  static extern bool SetCursorPos(int X, int Y);

        //设置鼠标按键和动作
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy,
            uint data, UIntPtr extraInfo); //UIntPtr指针多句柄类型

        // [DllImport("user32.dll")]
        //  static extern IntPtr FindWindow(string strClass, string strWindow);

        //该函数获取一个窗口句柄,该窗口雷鸣和窗口名与给定字符串匹配 hwnParent=Null从桌面窗口查找
        // [DllImport("user32.dll")]
        //  static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
        //      string strClass, string strWindow);

        //   [DllImport("user32.dll")]
        //  static extern bool GetWindowRect(HandleRef hwnd, out NativeRECT rect);

        //定义变量
        // const int AnimationCount = 80;
        //private Point endPosition;
        //private int count;


        private void Button2_Click(object sender, EventArgs e)
        {
            //尝试关闭已经运行的线程
            CloseThread();
            //判断点击按钮
            JoystickSettings jst = new JoystickSettings();
            jst.UpdateSettings += new UpdateSettingsHandle(UpdateNewSettings); //给form1注册一个当参数修改后可以调用的方法UpdateNewSettings
            jst.Show();

            /*   Thread.Sleep(3000);
               mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
               mouse_event(MouseEventFlag.Move, 200, 200, 0, UIntPtr.Zero);
               mouse_event(MouseEventFlag.LeftUp, 200, 200, 0, UIntPtr.Zero);
               */
        }

        private void UpdateNewSettings(bool saveSettings)
        {
            LoadAppSettings();
            AppendText("LX: " + leftStickOrigin.X.ToString() + " next Y: " + leftStickOrigin.Y.ToString() + " scale: " + scale.ToString(), logList);
            //  throw new NotImplementedException();
        }

        private void MouseAction(JoystickUpdate state)
        {
            //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //string offset = state.Offset.ToString();
            int rawoffset = state.RawOffset;
            int value = (state.Value - 32767) / scale;
            switch (rawoffset)
            {
                case 0:
                    nextPoint.X = value;
                    break;
                case 4:
                    nextPoint.Y = value;
                    break;
            }
            AppendText("next X: " + targPoint.X + nextPoint.X + " next Y: " + targPoint.Y + nextPoint.Y, logList);
            // mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.Absolute, currPoint.X, currPoint.Y, 0, UIntPtr.Zero);
            if (releaseButton)
                mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.Absolute, targPoint.X, targPoint.Y, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, targPoint.X + nextPoint.X, targPoint.Y + nextPoint.Y, 0, UIntPtr.Zero);
            //摇杆回到中心后释放左键
            if (Math.Abs(nextPoint.X + nextPoint.Y) < 10)
            {
                releaseButton = true;
                mouse_event(MouseEventFlag.LeftUp | MouseEventFlag.Absolute, targPoint.X, targPoint.Y, 0, UIntPtr.Zero);
            }

            //currPoint = nextPoint;
        }
        /* ↑↑↑↑↑↑鼠标模拟↑↑↑↑↑↑ */

        private delegate void AddItemToListBoxDelegate(string str, ListBox listBox);//定义委托类型

        private void AppendText(string msg, ListBox listBox)
        {
            if (listBox.InvokeRequired)//判断是否能当前线程调用
            {
                AddItemToListBoxDelegate d = AppendText;
                listBox.Invoke(d, msg, listBox);
            }
            else
            {
                listBox.Items.Add(msg);
                if (listBox.Items.Count > 0)
                    listBox.SelectedIndex = listBox.Items.Count - 1;                
            }
        }

        private delegate void AddClassToListBoxDelegate(string str, ListBox listBox);//定义委托类型

        //添加
        private void AddDeviceInfo(ListBox listBox, DeviceInfo deviceInfo)
        {
            listBox.DisplayMember = "JoystickName";
            listBox.ValueMember = "JoystickGuid";

            DeviceInfo deviceObj = new DeviceInfo(deviceInfo.JoystickGuid, deviceInfo.JoystickName);

            if (listBox.InvokeRequired)//判断是否能当前线程调用
            {
                AddItemToListBoxDelegate d = AppendText;
                listBox.Invoke(d, deviceObj, listBox);
            }
            else
            {
                listBox.Items.Add(deviceObj);
                if (listBox.Items.Count > 0)
                    listBox.SelectedIndex = listBox.Items.Count - 1;
            }
            
            
        }



        private void PrecessData(Guid guid)
        {

            var joystick = new Joystick(directInput, guid);
            //  MessageBox.Show("Found Joystick/Gamepad with GUID: " + joystickGuid);

            // Query all suported ForceFeedback effects
            var allEffects = joystick.GetEffects();
            foreach (var effectInfo in allEffects)
                AppendText("Effect available " + effectInfo.Name, logList);

            // Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;

            // Acquire the joystick
            joystick.Acquire();

            if (!connectionSuccess)
            {                
                this.Invoke(new Action(() =>
                {
                    label1.Text = "连接成功";
                }));
            }

            // Poll events from joystick
            while (true)
            {
                joystick.Poll();
                var datas = joystick.GetBufferedData();
                foreach (var state in datas)
                {
                    MouseAction(state);
                }

                

                // Console.WriteLine(state);
                /*  this.Invoke(new Action(() =>
                  {
                      label1.Text = state.ToString();
                  }));
                  */
            }
        }

        private void ConnectDevice_Click(object sender, EventArgs e)
        {
            try
            {
                Guid guid = new Guid(GetDeviceGuid(devList));
                // Instantiate the joystick
                //异步执行，防止主线程阻塞
                if(guid != Guid.Empty)
                {
                    th = new Thread(() =>
                    {
                        PrecessData(guid);
                    });
                    th.Start();
                }
                else
                    MessageBox.Show("无效设备");

            }
            catch
            {
                // return false;
            }
        }

        public class DeviceInfo
        {
            public string JoystickGuid
            {
                get;
                set;
            }

            public string JoystickName
            {
                get;
                set;
            }
            public DeviceInfo()
            {
                JoystickGuid = Guid.Empty.ToString();
                JoystickName = "";
            }

            public DeviceInfo(string joystickGuid, string joystickName)
            {
                JoystickGuid = joystickGuid;
                JoystickName = joystickName;
            }
            //public override string ToString()
            //{
            //  return this.Text;
            //}
        }

        //获取
        private string GetDeviceGuid(ListBox listBox)
        {
            if (listBox.SelectedItem != null)
            {
                //  DeviceInfo obj = listBox1.SelectedItem as DeviceInfo;
                //  MessageBox.Show(obj.Value);
                DeviceInfo di = listBox.SelectedItem as DeviceInfo;
                return di.JoystickGuid;
            }
            return Guid.Empty.ToString();
        }

        void GetDevice_Click(object sender, EventArgs e)
        {

            // Find a Joystick Guid
            // joystickGuid = Guid.Empty;
            devList.Items.Clear();


            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                this.Invoke(new Action(() =>
                {
                    //  AppendText("设备列表");
                    AppendText(deviceInstance.InstanceGuid.ToString(), devList);
                }));
               
            }

            // If Gamepad not found, look for a Joystick
            // if (joystickGuid == Guid.Empty)
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
            {
                this.Invoke(new Action(() =>
                {   
                    DeviceInfo deviceInfo = new DeviceInfo(deviceInstance.InstanceGuid.ToString(), deviceInstance.InstanceName);
                    AddDeviceInfo(devList, deviceInfo);
                }));
                //   joystickGuid = deviceInstance.InstanceGuid;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseThread();
        }

        private void CloseThread()
        {
            try
            {
                if (th.IsAlive)
                    th.Abort(); //关闭线程
            }
            catch
            {

            }
        }

    }
}