using Intel.RealSense;
using Intel.RealSense.Hand;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;




namespace hands_viewer.cs
{
   
    public partial class MainForm : Form
    {
        
        public Session session { get; private set; }

        private volatile bool closing = false;
        public volatile bool stop = false;
        public Dictionary<string, DeviceInfo> Devices { get; set; }

        private Bitmap bitmap = null;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private string filename = null;
        private string gestureName = null;
        private bool _isInitGesturesFirstTime = false;
        private bool _isListChangeEventSet;

        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        public MainForm(Session session)
        {
            InitializeComponent();
            this.session = session;
            PopulateDeviceMenu();
            cmbGesturesList.Enabled = false;
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            Panel2.Paint += new PaintEventHandler(Panel_Paint);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 2000;
            timer.Start();
        }

        private void _capture_DeviceListChanged(object sender,EventArgs e)
        {
            UpdateStatus("Device plugged/unplugged");
            PopulateDeviceMenu();        
        }

        private delegate void UpdateGesturesToListDelegate(string gestureName, int index);
        public void UpdateGesturesToList(string gestureName, int index)
        {
            cmbGesturesList.Invoke(new UpdateGesturesToListDelegate(delegate(string name, int cmbIndex) { cmbGesturesList.Items.Add(new Item(name, cmbIndex)); }), new object[] { gestureName, index });
        }

        public void setInitGesturesFirstTime(bool isInit)
        {
            _isInitGesturesFirstTime = isInit;
            
        }

        private delegate void ResetGesturesListDelegate();
        public void resetGesturesList()
        {
            cmbGesturesList.Invoke(new ResetGesturesListDelegate(delegate() { cmbGesturesList.Text = "";  cmbGesturesList.Items.Clear(); cmbGesturesList.SelectedIndex = -1; cmbGesturesList.Enabled = false; cmbGesturesList.Size = new System.Drawing.Size(100, 20); }), new object[] { });
        }

        private delegate void UpdateGesturesListSizeDelegate();
        public void UpdateGesturesListSize()
        {
            cmbGesturesList.Invoke(new UpdateGesturesListSizeDelegate(delegate() { cmbGesturesList.Enabled = true; cmbGesturesList.Size = new System.Drawing.Size(100, 70); }), new object[] { });
           
        }

        public bool getInitGesturesFirstTime()
        {
           return _isInitGesturesFirstTime;
        }

        public string GetCheckedSmoother()
        {
            foreach (ToolStripMenuItem m in MainMenu.Items)
            {
                if (!m.Text.Equals("Smoother")) continue;
                foreach (ToolStripMenuItem e in m.DropDownItems)
                {
                    if (e.Checked) return e.Text;
                }
            }
            return null;
        }

        public DeviceInfo GetDeviceFromFileMenu(string fileName)
        {
            ImplDesc desc = new ImplDesc()
            {
                group = ImplGroup.IMPL_GROUP_SENSOR,
                subgroup = ImplSubgroup.IMPL_SUBGROUP_VIDEO_CAPTURE
            };

            ImplDesc desc1;
            DeviceInfo dinfo;
            SenseManager pp = SenseManager.CreateInstance();
            if (pp == null)
            {
                return null;
            }
            
            try
            {
                desc1 = session.QueryImpl(desc, 0);

                if (desc1 == null) throw null;

                if (pp.CaptureManager == null) throw null;
		
                if (pp.CaptureManager.SetFileName(fileName, false) < Status.STATUS_NO_ERROR) throw null;
		
                if (pp.CaptureManager.LocateStreams() < Status.STATUS_NO_ERROR) throw null;

                if (pp.CaptureManager.Device != null)
                    pp.CaptureManager.Device.QueryDeviceInfo(out dinfo);
                else
                    throw null;
            }
            catch
            {
                pp.Dispose();
                return null;
            }

            
            pp.Close();
            pp.Dispose();

            StatusLabel.Text = "Ok";
            return dinfo;
        }

        private void PopulateDeviceMenu()
        {
            Devices = new Dictionary<string, DeviceInfo>();
            ImplDesc desc = new ImplDesc()
            {
                group = ImplGroup.IMPL_GROUP_SENSOR,
                subgroup = ImplSubgroup.IMPL_SUBGROUP_VIDEO_CAPTURE
            };
            ToolStripMenuItem sm = new ToolStripMenuItem("Device");

            for (int i = 0; ; i++)
            {
                ImplDesc desc1 = session.QueryImpl(desc, i);
                if ( desc1 == null )
                    break;
                Capture capture = null;

                if ( session.CreateImpl<Capture>(desc1, out capture) < Status.STATUS_NO_ERROR ) continue;

                
                if ( capture == null || capture.DeviceInfo == null ) continue;

                if (!_isListChangeEventSet)
                {
                    capture.DeviceListChanged += _capture_DeviceListChanged;
                    _isListChangeEventSet = true;
                }
                
                for (int j = 0;  j < capture.DeviceInfo.Length ; j++)
                {
                   
                    DeviceInfo dinfo = capture.DeviceInfo[j];
                    if (dinfo == null) break;

                    
                    if ( Devices.ContainsKey(dinfo.name) )
                    {
                        dinfo.name += j;
                    }
                    Devices.Add(dinfo.name, dinfo );

                    ToolStripMenuItem sm1 = new ToolStripMenuItem(dinfo.name, null, new EventHandler(Device_Item_Click));

                    sm.DropDownItems.Add(sm1);
                }
            }
            if (sm.DropDownItems.Count > 0)
            {
                var toolStripMenuItem = sm.DropDownItems[0] as ToolStripMenuItem;
                if (toolStripMenuItem != null)
                    toolStripMenuItem.Checked = true;
            }
            MainMenu.Items.RemoveAt(0);
            MainMenu.Items.Insert(0, sm);
        }

        private void RadioCheck(object sender, string name)
        {
            foreach (ToolStripMenuItem m in MainMenu.Items)
            {
                if (!m.Text.Equals(name)) continue;
                foreach (ToolStripMenuItem e1 in m.DropDownItems)
                {
                    e1.Checked = (sender == e1);
                }
            }
        }

        private void Device_Item_Click(object sender, EventArgs e)
        {
            RadioCheck(sender, "Device");
        }

        private void Module_Item_Click(object sender, EventArgs e)
        {
            RadioCheck(sender, "Module");
        }

        private void Start_Click(object sender, EventArgs e)
        {
            MainMenu.Enabled = false;
            Start.Enabled = false;
            Stop.Enabled = true;

            EnableTrackingMode(false);
           
            stop = false;
            System.Threading.Thread thread = new System.Threading.Thread(DoRecognition);
            thread.Start();
            System.Threading.Thread.Sleep(5);
        }

        delegate void DoRecognitionCompleted();
        private void DoRecognition()
        {
            HandsRecognition gr = new HandsRecognition(this);
            gr.SimplePipeline();
            this.Invoke(new DoRecognitionCompleted(
                delegate
                {
                    Start.Enabled = true;
                    Stop.Enabled = false;
                    EnableTrackingMode(true);
                    MainMenu.Enabled = true;
                    if (closing) Close();
                }
            ));
        }

        public string GetCheckedDevice()
        {
            foreach (ToolStripMenuItem m in MainMenu.Items)
            {
                if (!m.Text.Equals("Device")) continue;
                foreach (ToolStripMenuItem e in m.DropDownItems)
                {
                    if (e.Checked) return e.Text;
                }
            }
            return null;
        }

        public DeviceInfo GetCheckedDeviceInfo()
        {
            foreach (ToolStripMenuItem m in MainMenu.Items)
            {
                if (!m.Text.Equals("Device")) continue;
                for (int i = 0; i < m.DropDownItems.Count; i++)
                {
                    if (((ToolStripMenuItem)m.DropDownItems[i]).Checked)
                        return Devices.ElementAt(i).Value;
                }
            }
            return new DeviceInfo();
        }
      

        public bool GetDepthState()
        {
            return Depth.Checked;
        }

        public bool GetLabelmapState()
        {
            return Labelmap.Checked;
        }

        public bool GetJointsState()
        {
            return Joints.Checked;
        }

        public bool GetSkeletonState()
        {
            return Skeleton.Checked;
        }



 

        public bool GetExtremitiesState()
        {
            return Extremities.Checked;
        }



        public bool GetFullHandModeState()
        {
            return FullHandMode.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop = true;
            e.Cancel = Stop.Enabled;
            closing = true;
  
        }

        private delegate void UpdateStatusDelegate(string status);
        public void UpdateStatus(string status)
        {
            Status2.Invoke(new UpdateStatusDelegate(delegate(string s) { StatusLabel.Text = s; }), new object[] { status });
        }

        private delegate void UpdateInfoDelegate(string status,Color color);
        public void UpdateInfo(string status,Color color)
        {
            infoTextBox.Invoke(new UpdateInfoDelegate(delegate(string s, Color c)
            {
                if (status == String.Empty)
                {
                    infoTextBox.Text = String.Empty;
                    return;
                }

                if (infoTextBox.TextLength > 1200)
                {
                    infoTextBox.Text = String.Empty;
                }

                infoTextBox.SelectionColor = c;

                infoTextBox.SelectedText = s;
                infoTextBox.SelectionColor = infoTextBox.ForeColor;
                
                infoTextBox.SelectionStart = infoTextBox.Text.Length;
                infoTextBox.ScrollToCaret();

            }), new object[] { status,color });
        }



        private delegate void UpdateFPSStatusDelegate(string status);
        public void UpdateFPSStatus(string status)
        {
            labelFPS.Invoke(new UpdateFPSStatusDelegate(delegate(string s) { labelFPS.Text = s; }), new object[] { status });
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            stop = true;
            EnableTrackingMode(true);
            resetGesturesList();
        }

        private delegate void UpdateEnableTrackingModeDelegate(bool flag);
        public void EnableTrackingMode(bool flag)
        {
           FullHandMode.Invoke(new UpdateEnableTrackingModeDelegate(delegate(bool enable) { FullHandMode.Enabled = enable; }), new object[] { flag });
        }

        public void DisplayBitmap(Bitmap picture)
        {
            lock (this)
            {
                if (bitmap != null)
                    bitmap.Dispose();
                bitmap = new Bitmap(picture);
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            lock (this)
            {
                if (bitmap == null || bitmap.Width == 0 || bitmap.Height==0) return;
                Bitmap bitmapNew = new Bitmap(bitmap);
                try
                {
                    if (Mirror.Checked)
                    {
                        bitmapNew.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }

                    if (Scale2.Checked)
                    {
                        /* Keep the aspect ratio */
                        Rectangle rc = (sender as PictureBox).ClientRectangle;
                        float xscale = (float) rc.Width / (float) bitmap.Width;
                        float yscale = (float) rc.Height / (float) bitmap.Height;
                        float xyscale = (xscale < yscale) ? xscale : yscale;
                        int width = (int) (bitmap.Width*xyscale);
                        int height = (int) (bitmap.Height*xyscale);
                        rc.X = (rc.Width - width) / 2;
                        rc.Y = (rc.Height - height) / 2;
                        rc.Width = width;
                        rc.Height = height;
                        e.Graphics.DrawImage(bitmapNew, rc);
                    }
                    else
                    {
                        e.Graphics.DrawImageUnscaled(bitmapNew, 0, 0);
                    }
                }              
                finally
                {
                    bitmapNew.Dispose();
                }
            }
        }

        public bool GetContourState()
        {
            return ContourCheckBox.Checked;
        }

        public void DisplayContour(PointI32[] contour, int blobNumber)
        {
            if (bitmap == null) return;
            lock (this)
            {
                Graphics g = Graphics.FromImage(bitmap);
                using (Pen contourColor = new Pen(Color.Blue, 3.0f))
                {
                    for (int i = 0; i < contour.Length; i++)
                    {
                        int baseX = (int)contour[i].x;
                        int baseY = (int)contour[i].y;

                        if (i + 1 < contour.Length)
                        {
                            int x = (int)contour[i + 1].x;
                            int y = (int)contour[i + 1].y;

                            g.DrawLine(contourColor, new Point(baseX, baseY), new Point(x, y));
                        }
                        else
                        {
                            int x = (int)contour[0].x;
                            int y = (int)contour[0].y;
                            g.DrawLine(contourColor, new Point(baseX, baseY), new Point(x, y));
                        }
                    }
                }
                g.Dispose();
            }
        }

  
        public void DisplayExtremities(int numOfHands, ExtremityData[][] extremitites = null)
        {
            if (bitmap == null) return;
            if (extremitites == null) return;
            
            int scaleFactor = 1;
            Graphics g = Graphics.FromImage(bitmap);

            float sz = 8;
            if (Labelmap.Checked)
                sz = 4;

            Pen pen = new Pen(Color.Red, 3.0f);
		    for (int i = 0; i < numOfHands; ++i) 
		    {
			    for (int j = 0 ;j < HandData.NUMBER_OF_EXTREMITIES; ++j) 			
			    {
                    int x = (int)extremitites[i][j].pointImage.x / scaleFactor;
                    int y = (int)extremitites[i][j].pointImage.y / scaleFactor;
                    g.DrawEllipse(pen, x - sz / 2, y - sz / 2, sz, sz);
			    }
		    }
            pen.Dispose();
        }

        public void DisplayJoints(JointData[][] nodes, int numOfHands)
        {
            if (bitmap == null) return;
            if (nodes == null) return;

            if (Joints.Checked || Skeleton.Checked)
            {
                lock (this)
                {
                    int scaleFactor = 1;

                    Graphics g = Graphics.FromImage(bitmap);

                    using (Pen boneColor = new Pen(Color.DodgerBlue, 3.0f))
                    {
                        for (int i = 0; i < numOfHands; i++)
                        {
                            if (nodes[i][0] == null) continue;
                            int baseX = (int) nodes[i][0].positionImage.x/scaleFactor;
                            int baseY = (int) nodes[i][0].positionImage.y/scaleFactor;

                            int wristX = (int) nodes[i][0].positionImage.x/scaleFactor;
                            int wristY = (int) nodes[i][0].positionImage.y/scaleFactor;

                            if (Skeleton.Checked)
                            {
                                for (int j = 1; j < 22; j++)
                                {
                                    if (nodes[i][j] == null) continue;
                                    int x = (int) nodes[i][j].positionImage.x/scaleFactor;
                                    int y = (int) nodes[i][j].positionImage.y/scaleFactor;

                                    if (nodes[i][j].confidence <= 0) continue;

                                    if (j == 2 || j == 6 || j == 10 || j == 14 || j == 18)
                                    {

                                        baseX = wristX;
                                        baseY = wristY;
                                    }

                                    g.DrawLine(boneColor, new Point(baseX, baseY), new Point(x, y));
                                    baseX = x;
                                    baseY = y;
                                }
                            }

                            if (Joints.Checked)
                            {
                                using (
                                    Pen red = new Pen(Color.Red, 3.0f),
                                        black = new Pen(Color.Black, 3.0f),
                                        green = new Pen(Color.Green, 3.0f),
                                        blue = new Pen(Color.Blue, 3.0f),
                                        cyan = new Pen(Color.Cyan, 3.0f),
                                        yellow = new Pen(Color.Yellow, 3.0f),
                                        orange = new Pen(Color.Orange, 3.0f))
                                {
                                    Pen currnetPen = black;

                                    for (int j = 0; j < HandData.NUMBER_OF_JOINTS; j++)
                                    {
                                        float sz = 4;
                                        if (Labelmap.Checked)
                                            sz = 2;

                                        int x = (int) nodes[i][j].positionImage.x/scaleFactor;
                                        int y = (int) nodes[i][j].positionImage.y/scaleFactor;

                                        if (nodes[i][j].confidence <= 0) continue;

                                        //Wrist
                                        if (j == 0)
                                        {
                                            currnetPen = black;
                                        }

                                        //Center
                                        if (j == 1)
                                        {
                                            currnetPen = red;
                                            sz += 4;
                                        }

                                        //Thumb
                                        if (j == 2 || j == 3 || j == 4 || j == 5)
                                        {
                                            currnetPen = green;
                                        }
                                        //Index Finger
                                        if (j == 6 || j == 7 || j == 8 || j == 9)
                                        {
                                            currnetPen = blue;
                                        }
                                        //Finger
                                        if (j == 10 || j == 11 || j == 12 || j == 13)
                                        {
                                            currnetPen = yellow;
                                        }
                                        //Ring Finger
                                        if (j == 14 || j == 15 || j == 16 || j == 17)
                                        {
                                            currnetPen = cyan;
                                        }
                                        //Pinkey
                                        if (j == 18 || j == 19 || j == 20 || j == 21)
                                        {
                                            currnetPen = orange;
                                        }


                                        if (j == 5 || j == 9 || j == 13 || j == 17 || j == 21)
                                        {
                                            sz += 4;
                                        }

                                        g.DrawEllipse(currnetPen, x - sz/2, y - sz/2, sz, sz);
                                    }
                                }
                            }
                        }
                    }
                    g.Dispose();
                }
            }
        }

    

        private delegate void UpdatePanelDelegate();
        public void UpdatePanel()
        {

            Panel2.Invoke(new UpdatePanelDelegate(delegate()
            { Panel2.Invalidate();
            }));

        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RadioCheck(sender, "Pipeline");
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RadioCheck(sender, "Pipeline");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void Live_Click(object sender, EventArgs e)
        {
            Playback.Checked = Record.Checked = false;
            Live.Checked = true;
        }

        private void Playback_Click(object sender, EventArgs e)
        {
            Live.Checked = Record.Checked = false;
            Playback.Checked = true;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "RSSDK clip|*.rssdk|Old format clip|*.pcsdk|All files|*.*";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                filename = (ofd.ShowDialog() == DialogResult.OK) ? ofd.FileName : null;
            }
        }

        public bool GetPlaybackState()
        {
            return Playback.Checked;
        }



        private void Record_Click(object sender, EventArgs e)
        {
            Live.Checked = Playback.Checked = false;
            Record.Checked = true;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RSSDK clip|*.rssdk|All Files|*.*";
            sfd.CheckPathExists = true;
            sfd.OverwritePrompt = true;
            sfd.AddExtension = true;
            filename = (sfd.ShowDialog() == DialogResult.OK) ? sfd.FileName : null;
        }

        public bool GetRecordState()
        {
            return Record.Checked;
        }

        public string GetFileName()
        {
            return filename;
        }

        private void cmbGesturesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGesturesList.SelectedItem != null)
            {
                gestureName = cmbGesturesList.SelectedItem.ToString();
            }
            else
            {
                gestureName = string.Empty;
            }
        }

        public string GetGestureName()
        {
            return gestureName;
        }

        private void Depth_CheckedChanged(object sender, EventArgs e)
        {
            ContourCheckBox.Enabled = false;
        }

        private void Labelmap_CheckedChanged(object sender, EventArgs e)
        {
            ContourCheckBox.Enabled = true;
        }

        private void TrackingModeChanged(object sender, EventArgs e)
        {
           
            Labelmap.Enabled = true;

            Joints.Enabled = false;
            Joints.Checked = false;
            Skeleton.Enabled = false;
            Skeleton.Checked = false;
        
            Extremities.Enabled = false;
            Extremities.Checked = false;

            if (FullHandMode.Checked)
            {
                Labelmap.Enabled = true;
                Depth.Enabled = true;

                Joints.Enabled = true;
                Joints.Checked = true;
                Skeleton.Enabled = true;
                Skeleton.Checked = true;
                Extremities.Checked = false;
                Extremities.Enabled = true;
            }

        }

        private void ImageGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sp.IsOpen == true)
            {
                sp.Close();
                SaveProperties();
                try
                {
                    sp.Open();
                }
                catch
                { button1.Text = "连接"; MessageBox.Show("串口不存在或者被其他应用程序占用！", "提示"); }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sp.IsOpen == false)
                {
                    SaveProperties();
                    sp.Open();
                    button1.Text = "关闭";
                }
                else
                {
                    { sp.Close(); button1.Text = "连接"; }
                }
            }
            catch
            { MessageBox.Show("串口不存在或者被其他应用程序占用！", "提示");

            }
        }
        private void SaveProperties()
        {
            //sp.Parity = (Parity)Enum.Parse(typeof(Parity), comboBox4.Text);
            string StopB = comboBox7.Text.Substring(0, 1);//将停止位中的汉字截掉，以便和枚举变量匹配
            sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopB);
            sp.PortName = comboBox1.Text; //确定选中的串口
            sp.BaudRate = int.Parse(comboBox5.Text);
            string DataB = comboBox6.Text.Substring(0, 1);//将数据位中的汉字截掉，以便和整型变量匹配
            sp.DataBits = int.Parse(DataB);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sp.IsOpen == true)
            {
                sp.Close();
                SaveProperties();
                sp.Open();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sp.IsOpen == true)
            {
                sp.Close();
                SaveProperties();
                sp.Open();
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sp.IsOpen == true)
            {
                sp.Close();
                SaveProperties();
                sp.Open();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public static int ReturnStringX(string a, string b)//a为要判断字符串，b为文本
        {
            int count = 0;
            string n = a;
            try
            {
                for (int i = 0; i <= a.Count(); i++)
                {
                    Console.WriteLine(n);
                    if (n.Substring(0, n.Length).Equals(b))
                    {
                        count++;
                        n = n.Remove(0, n.Length);
                    }
                    else
                    {
                        n = n.Remove(0, 1);
                    }
                }
            }
            catch (Exception ) { }
            return count;
        }
        public static int FindMax(int count1,int count2,int count3)
        {
            int[] array = { count1, count2, count3 };
           int m =array.Max();
            return m;

        }
        private int TakeCount = 0;
        private void infoTextBox_TextChanged(object sender, EventArgs e )
        {
            TakeCount++;
            if(TakeCount>=3)//进入发送程序
            {
                infoTextBox.Enabled = false;
                TakeCount = 0;
                try
                {
                    
                    if (sp.IsOpen == false)
                    {
                        MessageBox.Show("串口未打开", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (sp.IsOpen == true && infoTextBox.Text != "")//判断串口是否打开
                    {

                        int count = 0;
                        int count1 = 0;
                        int count2 = 0;
                        int count3 = 0;
                        count1 = ReturnStringX("fist", infoTextBox.Text);
                        count2 = ReturnStringX("v_sign", infoTextBox.Text);
                        count3 = ReturnStringX("spreadfingers", infoTextBox.Text);
                        count = FindMax(count1, count2, count3);
                        if (count == count1)
                        {
                            sp.Write("fist");//应该设置一个定时器来确定发送间隔具体需要调试确定
                            infoTextBox.Clear();
                            Thread.Sleep(1000);
                            infoTextBox.Enabled = true;

                        }
                        else if (count == count2)
                        {
                            sp.Write("v_sign");
                            infoTextBox.Clear();
                            Thread.Sleep(1000);
                            infoTextBox.Enabled = true;
                        }
                        else if (count == count3)
                        {
                            sp.Write("spreadfinger");
                            infoTextBox.Clear();
                            Thread.Sleep(1000);
                            infoTextBox.Enabled = true;
                        }
                        //string str = infoTextBox.Text;
                        //string substr = "fist";
                        //string substr2 = "click";
                        //string substr3 = "spreadfinger";
                        //int Count1 = 0;
                        //int Count2 = 0;
                        //int Count3 = 0;
                        //for (int i = 0; i <= str.Length - substr.Length;)
                        //{
                        //    var index = str.IndexOf(substr, i);
                        //    if (index < 0) break;
                        //    Count1++;
                        //    i += index + 1;
                        //}
                        //for (int i = 0; i <= str.Length - substr2.Length;)
                        //{
                        //    var index = str.IndexOf(substr2, i);
                        //    if (index < 0) break;
                        //    Count2++;
                        //    i += index + 1;
                        //}
                        //for (int i = 0; i <= str.Length - substr3.Length;)
                        //{
                        //    var index = str.IndexOf(substr3, i);
                        //    if (index < 0) break;
                        //    Count3++;
                        //    i += index + 1;
                        //}
                        //if (Count1 > Count2 && Count1 > Count3)
                        //{
                        //    sp.Write("fist");
                        //    infoTextBox.Clear();
                        //    Count1 = 0;
                        //    Count2 = 0;
                        //    Count3 = 0;

                        //}
                        //if (Count2 > Count1 && Count2 > Count3)
                        //{
                        //    sp.Write("click");
                        //    infoTextBox.Clear();
                        //    Count1 = 0;
                        //    Count2 = 0;
                        //    Count3 = 0;
                        //}
                        //if (Count3 > Count2 && Count3 > Count1)
                        //{
                        //    sp.Write("spreadfinger");
                        //    infoTextBox.Clear();
                        //    Count1 = 0;
                        //    Count2 = 0;
                        //    Count3 = 0;
                        //}



                    }
                }
                catch
                {
                    MessageBox.Show("串口尚未连接，" + "\n" + "数据发送失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }


            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Click(object sender, EventArgs e)
        {

        }
    }
}
