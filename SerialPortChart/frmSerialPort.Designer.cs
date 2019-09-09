namespace SerialPortChart
{
    partial class frmSerialPort
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSerialPort));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtShowData = new System.Windows.Forms.TextBox();
            this.btnClearRev = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbParity = new System.Windows.Forms.ComboBox();
            this.cbbStopBits = new System.Windows.Forms.ComboBox();
            this.cbbDataBits = new System.Windows.Forms.ComboBox();
            this.cbbBaudRate = new System.Windows.Forms.ComboBox();
            this.cbbComList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userCurve1 = new HslCommunication.Controls.UserCurve();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRevCount = new System.Windows.Forms.Label();
            this.lblRev = new System.Windows.Forms.Label();
            this.rbtnUnicode = new System.Windows.Forms.RadioButton();
            this.rbtnUTF8 = new System.Windows.Forms.RadioButton();
            this.rbtnASCII = new System.Windows.Forms.RadioButton();
            this.rbtnHex = new System.Windows.Forms.RadioButton();
            this.chkAutoLine = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtShowData);
            this.panel1.Controls.Add(this.btnClearRev);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 595);
            this.panel1.TabIndex = 0;
            // 
            // txtShowData
            // 
            this.txtShowData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtShowData.Location = new System.Drawing.Point(0, 273);
            this.txtShowData.Multiline = true;
            this.txtShowData.Name = "txtShowData";
            this.txtShowData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShowData.Size = new System.Drawing.Size(198, 320);
            this.txtShowData.TabIndex = 1;
            // 
            // btnClearRev
            // 
            this.btnClearRev.Location = new System.Drawing.Point(52, 285);
            this.btnClearRev.Name = "btnClearRev";
            this.btnClearRev.Size = new System.Drawing.Size(75, 23);
            this.btnClearRev.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("宋体", 10F);
            this.btnOpen.Location = new System.Drawing.Point(84, 188);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(89, 32);
            this.btnOpen.TabIndex = 9;
            this.btnOpen.Text = "打开串口";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(34, 188);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbParity);
            this.groupBox1.Controls.Add(this.cbbStopBits);
            this.groupBox1.Controls.Add(this.cbbDataBits);
            this.groupBox1.Controls.Add(this.cbbBaudRate);
            this.groupBox1.Controls.Add(this.cbbComList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 170);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "端口设置";
            // 
            // cbbParity
            // 
            this.cbbParity.FormattingEnabled = true;
            this.cbbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cbbParity.Location = new System.Drawing.Point(18, 126);
            this.cbbParity.Name = "cbbParity";
            this.cbbParity.Size = new System.Drawing.Size(98, 21);
            this.cbbParity.TabIndex = 9;
            // 
            // cbbStopBits
            // 
            this.cbbStopBits.FormattingEnabled = true;
            this.cbbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbbStopBits.Location = new System.Drawing.Point(18, 100);
            this.cbbStopBits.Name = "cbbStopBits";
            this.cbbStopBits.Size = new System.Drawing.Size(98, 21);
            this.cbbStopBits.TabIndex = 8;
            // 
            // cbbDataBits
            // 
            this.cbbDataBits.FormattingEnabled = true;
            this.cbbDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6"});
            this.cbbDataBits.Location = new System.Drawing.Point(18, 73);
            this.cbbDataBits.Name = "cbbDataBits";
            this.cbbDataBits.Size = new System.Drawing.Size(98, 21);
            this.cbbDataBits.TabIndex = 7;
            // 
            // cbbBaudRate
            // 
            this.cbbBaudRate.DisplayMember = "1";
            this.cbbBaudRate.FormattingEnabled = true;
            this.cbbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.cbbBaudRate.Location = new System.Drawing.Point(18, 44);
            this.cbbBaudRate.Name = "cbbBaudRate";
            this.cbbBaudRate.Size = new System.Drawing.Size(98, 21);
            this.cbbBaudRate.TabIndex = 6;
            this.cbbBaudRate.ValueMember = "1";
            // 
            // cbbComList
            // 
            this.cbbComList.DisplayMember = "1";
            this.cbbComList.FormattingEnabled = true;
            this.cbbComList.Location = new System.Drawing.Point(18, 18);
            this.cbbComList.Name = "cbbComList";
            this.cbbComList.Size = new System.Drawing.Size(98, 21);
            this.cbbComList.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "校验位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据位";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.userCurve1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(791, 485);
            this.panel2.TabIndex = 1;
            // 
            // userCurve1
            // 
            this.userCurve1.BackColor = System.Drawing.Color.Black;
            this.userCurve1.ColorLinesAndText = System.Drawing.Color.White;
            this.userCurve1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userCurve1.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userCurve1.ForeColor = System.Drawing.Color.White;
            this.userCurve1.IsAbscissaStrech = true;
            this.userCurve1.Location = new System.Drawing.Point(0, 41);
            this.userCurve1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userCurve1.Name = "userCurve1";
            this.userCurve1.Size = new System.Drawing.Size(789, 442);
            this.userCurve1.TabIndex = 1;
            this.userCurve1.TextAddFormat = "mm:ss";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRevCount);
            this.groupBox2.Controls.Add(this.lblRev);
            this.groupBox2.Controls.Add(this.rbtnUnicode);
            this.groupBox2.Controls.Add(this.rbtnUTF8);
            this.groupBox2.Controls.Add(this.rbtnASCII);
            this.groupBox2.Controls.Add(this.rbtnHex);
            this.groupBox2.Controls.Add(this.chkAutoLine);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(789, 41);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据接收区";
            // 
            // lblRevCount
            // 
            this.lblRevCount.AutoSize = true;
            this.lblRevCount.Location = new System.Drawing.Point(440, 18);
            this.lblRevCount.Name = "lblRevCount";
            this.lblRevCount.Size = new System.Drawing.Size(14, 14);
            this.lblRevCount.TabIndex = 7;
            this.lblRevCount.Text = "0";
            // 
            // lblRev
            // 
            this.lblRev.AutoSize = true;
            this.lblRev.Location = new System.Drawing.Point(350, 18);
            this.lblRev.Name = "lblRev";
            this.lblRev.Size = new System.Drawing.Size(84, 14);
            this.lblRev.TabIndex = 6;
            this.lblRev.Text = "接收字节数:";
            // 
            // rbtnUnicode
            // 
            this.rbtnUnicode.AutoSize = true;
            this.rbtnUnicode.Location = new System.Drawing.Point(255, 16);
            this.rbtnUnicode.Name = "rbtnUnicode";
            this.rbtnUnicode.Size = new System.Drawing.Size(74, 18);
            this.rbtnUnicode.TabIndex = 5;
            this.rbtnUnicode.Text = "Unicode";
            this.rbtnUnicode.UseVisualStyleBackColor = true;
            // 
            // rbtnUTF8
            // 
            this.rbtnUTF8.AutoSize = true;
            this.rbtnUTF8.Location = new System.Drawing.Point(196, 16);
            this.rbtnUTF8.Name = "rbtnUTF8";
            this.rbtnUTF8.Size = new System.Drawing.Size(60, 18);
            this.rbtnUTF8.TabIndex = 4;
            this.rbtnUTF8.Text = "UTF-8";
            this.rbtnUTF8.UseVisualStyleBackColor = true;
            // 
            // rbtnASCII
            // 
            this.rbtnASCII.AutoSize = true;
            this.rbtnASCII.Checked = true;
            this.rbtnASCII.Location = new System.Drawing.Point(137, 16);
            this.rbtnASCII.Name = "rbtnASCII";
            this.rbtnASCII.Size = new System.Drawing.Size(60, 18);
            this.rbtnASCII.TabIndex = 3;
            this.rbtnASCII.TabStop = true;
            this.rbtnASCII.Text = "ASCII";
            this.rbtnASCII.UseVisualStyleBackColor = true;
            // 
            // rbtnHex
            // 
            this.rbtnHex.AutoSize = true;
            this.rbtnHex.Location = new System.Drawing.Point(90, 16);
            this.rbtnHex.Name = "rbtnHex";
            this.rbtnHex.Size = new System.Drawing.Size(46, 18);
            this.rbtnHex.TabIndex = 2;
            this.rbtnHex.Text = "Hex";
            this.rbtnHex.UseVisualStyleBackColor = true;
            // 
            // chkAutoLine
            // 
            this.chkAutoLine.AutoSize = true;
            this.chkAutoLine.Location = new System.Drawing.Point(6, 16);
            this.chkAutoLine.Name = "chkAutoLine";
            this.chkAutoLine.Size = new System.Drawing.Size(82, 18);
            this.chkAutoLine.TabIndex = 1;
            this.chkAutoLine.Text = "自动换行";
            this.chkAutoLine.UseVisualStyleBackColor = true;
            // 
            // frmSerialPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 595);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSerialPort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实时温湿度";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbParity;
        private System.Windows.Forms.ComboBox cbbStopBits;
        private System.Windows.Forms.ComboBox cbbDataBits;
        private System.Windows.Forms.ComboBox cbbBaudRate;
        private System.Windows.Forms.ComboBox cbbComList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAutoLine;
        private System.Windows.Forms.RadioButton rbtnUnicode;
        private System.Windows.Forms.RadioButton rbtnUTF8;
        private System.Windows.Forms.RadioButton rbtnASCII;
        private System.Windows.Forms.RadioButton rbtnHex;
        private System.Windows.Forms.TextBox txtShowData;
        private System.Windows.Forms.Label lblRev;
        private System.Windows.Forms.Label lblRevCount;
        private System.Windows.Forms.Button btnClearRev;
        private HslCommunication.Controls.UserCurve userCurve1;
    }
}

