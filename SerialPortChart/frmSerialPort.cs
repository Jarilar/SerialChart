using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace SerialPortChart
{
    public partial class frmSerialPort : Form
    {
        private SerialPort ComDevice = new SerialPort();
        System.Timers.Timer timer = new System.Timers.Timer();
        SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
        public frmSerialPort()
        {
            InitializeComponent();
            this.init();

        }


        public void init()
        {

            cbbComList.Items.AddRange(SerialPort.GetPortNames());
            if (cbbComList.Items.Count > 0)
            {
                cbbComList.SelectedIndex = 0;
            }
            cbbBaudRate.SelectedIndex = 5;
            cbbDataBits.SelectedIndex = 0;
            cbbParity.SelectedIndex = 0;
            cbbStopBits.SelectedIndex = 0;
            pictureBox1.BackgroundImage = Properties.Resources.red;

            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);//绑定事件

            userCurve1.SetLeftCurve("A", new float[] { }, Color.Tomato);
            userCurve1.SetLeftCurve("B", new float[] { }, Color.DodgerBlue);


        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cbbComList.Items.Count <= 0)
            {
                MessageBox.Show("没有发现串口,请检查线路！");
                return;
            }

            if (ComDevice.IsOpen == false)
            {
                ComDevice.PortName = cbbComList.SelectedItem.ToString();
                ComDevice.BaudRate = Convert.ToInt32(cbbBaudRate.SelectedItem.ToString());
                ComDevice.Parity = (Parity)Convert.ToInt32(cbbParity.SelectedIndex.ToString());
                ComDevice.DataBits = Convert.ToInt32(cbbDataBits.SelectedItem.ToString());
                ComDevice.StopBits = (StopBits)Convert.ToInt32(cbbStopBits.SelectedItem.ToString());
                try
                {
                    ComDevice.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnOpen.Text = "关闭串口";
                pictureBox1.BackgroundImage = Properties.Resources.green;
            }
            else
            {
                try
                {
                    ComDevice.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnOpen.Text = "打开串口";
                pictureBox1.BackgroundImage = Properties.Resources.red;
            }

            cbbComList.Enabled = !ComDevice.IsOpen;
            cbbBaudRate.Enabled = !ComDevice.IsOpen;
            cbbParity.Enabled = !ComDevice.IsOpen;
            cbbDataBits.Enabled = !ComDevice.IsOpen;
            cbbStopBits.Enabled = !ComDevice.IsOpen;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void ClearSelf()
        {
            if (ComDevice.IsOpen)
            {
                ComDevice.Close();
            }
        }


        /// <summary>
        /// 字符串转换16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0) hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            return returnBytes;
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            ComDevice.Read(ReDatas, 0, ReDatas.Length);//读取数据
            this.AddData(ReDatas);//输出数据

        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="data">字节数组</param>
        public void AddData(byte[] data)
        {
            if (rbtnHex.Checked)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x2}" + " ", data[i]);
                }
                AddContent(sb.ToString().ToUpper());
            }
            else if (rbtnASCII.Checked)
            {
                AddContent(new ASCIIEncoding().GetString(data));
            }
            else if (rbtnUTF8.Checked)
            {
                AddContent(new UTF8Encoding().GetString(data));
            }
            else if (rbtnUnicode.Checked)
            {
                AddContent(new UnicodeEncoding().GetString(data));
            }
            else
            { }

            lblRevCount.Invoke(new MethodInvoker(delegate
            {
                lblRevCount.Text = (int.Parse(lblRevCount.Text) + data.Length).ToString();
            }));
        }


        /// <summary>
        /// 输入到显示区域
        /// </summary>
        /// <param name="content"></param>
        private void AddContent(string content)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (chkAutoLine.Checked && txtShowData.Text.Length > 0)
                {
                    txtShowData.AppendText("\r\n");
                }
                txtShowData.AppendText(content);
                string[] Datams = content.Split('E');
                userCurve1.AddCurveData("A", float.Parse(Datams[0]));
                userCurve1.AddCurveData("B", float.Parse(Datams[1]));
                //userCurve1.AddCurveData("C", float.Parse(Datams[2]));
            }));
        }



        private void TxtShowData_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
