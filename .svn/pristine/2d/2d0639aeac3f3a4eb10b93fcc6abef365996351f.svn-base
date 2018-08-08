using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMExport
{
    public partial class NoticeTask : Form
    {
        string ServerIP;
        public NoticeTask(string ip)
        {
            ServerIP = ip;
            InitializeComponent();
        }


        Point downPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                downPoint = new Point(e.X, e.Y);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - downPoint.X,
                    this.Location.Y + e.Y - downPoint.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {   
                if(textBox1.Text=="")
                {
                    MessageBox.Show("请输入频率", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                stNotice m = new stNotice();
                m.msg = System.Web.HttpUtility.UrlEncode(richTextBox1.Text);
                m.start_time = GetTimeStamp(Convert.ToDateTime(dateTimePicker1.Text));
                m.end_time = GetTimeStamp(Convert.ToDateTime(dateTimePicker2.Text));
                m.interval = Convert.ToInt32(textBox1.Text);
                string output = JsonConvert.SerializeObject(m);
                var url = @"http://" + ServerIP + ":81" + @"/gm?method=new_notice_task&params=" + output;
                common.HttpGet(url);
                MessageBox.Show("发布成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private int GetTimeStamp(DateTime dt)
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return timeStamp;
        }  
    }
}
