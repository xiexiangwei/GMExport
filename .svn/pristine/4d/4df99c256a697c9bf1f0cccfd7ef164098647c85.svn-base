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
    public partial class UserInfo : Form
    {
        DataSet ds;//数据集合 
        public UserInfo(DataSet _ds)
        {
            InitializeComponent();
            ds = _ds;
        }

        private string TimeStamp2Date(int timestamp)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(timestamp);
            return dt.ToString("yyyy/MM/dd HH:mm:ss:ff");
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            //玩家基础数据
            TBUID.Text = ds.Tables[0].Rows[0][0].ToString();
            NameLbl.Text = ds.Tables[0].Rows[0][1].ToString();
            powerLbl.Text = ds.Tables[0].Rows[0][2].ToString();
            RedPackLbl.Text = ds.Tables[0].Rows[0][3].ToString();
            RedPackPoolLbl.Text = ds.Tables[0].Rows[0][4].ToString();
            LoginTimeLbl.Text = TimeStamp2Date(Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString()));
            OfflineTimeLbl.Text = TimeStamp2Date(Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString()));
            ContinueLoginDayLbl.Text = ds.Tables[0].Rows[0][7].ToString();
            CompleteShipTaskCountLbl.Text = ds.Tables[0].Rows[0][8].ToString();
            ChallengeLeftTimesLbl.Text = ds.Tables[0].Rows[0][9].ToString();
            ChallengeDayCollectLbl.Text = ds.Tables[0].Rows[0][10].ToString();
            ChallengeWeekCollectLbl.Text = ds.Tables[0].Rows[0][11].ToString();
            //最大关卡和星星总数
            MaxLevelLbl.Text = ds.Tables[1].Rows[0][0].ToString();
            TotalStarLbl.Text = ds.Tables[1].Rows[0][1].ToString();
            //玩家道具数据
            for (int n = 0; n < ds.Tables[2].Rows.Count; n++)
            {
                Control []lblList = this.Controls.Find(string.Format("lbl{0}",ds.Tables[2].Rows[n][2].ToString()), true);
                if (lblList.Length > 0)
                {
                    Label lbl = lblList[0] as Label;
                    lbl.Text = ds.Tables[2].Rows[n][3].ToString();
                }  
            }
            //道具流水日志
            for (int n = 0; n < ds.Tables[3].Rows.Count; n++)
            {

                int index = this.DGVPropLog.Rows.Add();
                this.DGVPropLog.Rows[index].Cells[0].Value = ds.Tables[3].Rows[n][2].ToString() == "0" ? "获得" : "消耗";
                this.DGVPropLog.Rows[index].Cells[1].Value = ds.Tables[3].Rows[n][3].ToString();
                this.DGVPropLog.Rows[index].Cells[2].Value = ds.Tables[3].Rows[n][4].ToString();
                this.DGVPropLog.Rows[index].Cells[3].Value = ds.Tables[3].Rows[n][5].ToString();
                this.DGVPropLog.Rows[index].Cells[4].Value = ds.Tables[3].Rows[n][7].ToString();
                this.DGVPropLog.Rows[index].Cells[5].Value = ds.Tables[3].Rows[n][8].ToString();
            }  
            //有米广告任务日志
            for (int n = 0; n < ds.Tables[4].Rows.Count; n++)
            {
                int index = this.DGVYoumiLog.Rows.Add();
                this.DGVYoumiLog.Rows[index].Cells[0].Value = ds.Tables[4].Rows[n][1].ToString();
                this.DGVYoumiLog.Rows[index].Cells[1].Value = ds.Tables[4].Rows[n][3].ToString();
                this.DGVYoumiLog.Rows[index].Cells[2].Value = ds.Tables[4].Rows[n][5].ToString();
                this.DGVYoumiLog.Rows[index].Cells[3].Value = ds.Tables[4].Rows[n][6].ToString();
                this.DGVYoumiLog.Rows[index].Cells[4].Value = ds.Tables[4].Rows[n][7].ToString();
                this.DGVYoumiLog.Rows[index].Cells[5].Value = ds.Tables[4].Rows[n][8].ToString();
                this.DGVYoumiLog.Rows[index].Cells[6].Value = ds.Tables[4].Rows[n][9].ToString();
                this.DGVYoumiLog.Rows[index].Cells[7].Value = ds.Tables[4].Rows[n][10].ToString();
                this.DGVYoumiLog.Rows[index].Cells[8].Value = ds.Tables[4].Rows[n][11].ToString();

            }  
        }
        // 移动窗体
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        // 窗体上鼠标按下时
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                // 移动窗体
                this.Capture = false;
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
