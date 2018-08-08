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
    public partial class Mail : Form
    {
        string ServerIP = "";
        public Mail(string ip)
        {
            InitializeComponent();
            ServerIP = ip;
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

        private void BtnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                //发送邮件
                BtnSendMail.Enabled = false;
                if (TxtUid.Text == "")
                {
                    MessageBox.Show("请输入玩家uid", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (TxtMailTitle.Text == "")
                {
                    MessageBox.Show("请输入邮件标题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (TxtMailContent.Text == "")
                {
                    MessageBox.Show("请输入邮件内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BtnSendMail.Enabled = true;
                    return;
                }

                //组织http请求数据

                //道具列表
                Dictionary<int, int> propMap = new Dictionary<int, int>();
                for (int i = 1; i < 5; i++)
                {
                    var tb = (TextBox)this.Controls.Find(string.Format("TxtPropNum{0}", i), true)[0];
                    if (tb != null && tb.Text != "0")
                    {
                        var cb_prop = (ComboBox)this.Controls.Find(string.Format("CBProp{0}", i), true)[0];
                        if (cb_prop != null)
                        {
                            int propID = 0;
                            switch (cb_prop.Text)
                            {
                                case "金币": { propID = 1000; }; break;
                                case "锤子": { propID = 1002; }; break;
                                case "刷新道具": { propID = 1003; }; break;
                                case "纵向鱼雷": { propID = 1004; }; break;
                                case "横向鱼雷": { propID = 1005; }; break;
                                case "水雷": { propID = 1006; }; break;
                                case "消除器": { propID = 1007; }; break;
                                case "加3步": { propID = 1008; }; break;
                                case "加5步": { propID = 1009; }; break;
                                case "体力瓶": { propID = 1010; }; break;
                                case "大体力瓶": { propID = 1011; }; break;
                                case "超级体力瓶": { propID = 1012; }; break;
                            }
                            if (propMap.ContainsKey(propID))
                            {
                                propMap[propID] = propMap[propID] + Convert.ToInt32(tb.Text);
                            }
                            else
                            {
                                propMap.Add(propID, Convert.ToInt32(tb.Text));
                            }
                        }
                    }
                }
                var propList = "";
                foreach (var item in propMap)
                {
                    propList += string.Format("{0}:{1},",item.Key,item.Value);
                }
                stMail m = new stMail();
                m.uid = TxtUid.Text;
                m.mail_title = TxtMailTitle.Text;
                m.mail_content = TxtMailContent.Text;
                m.prop_list = propList;
                string output = JsonConvert.SerializeObject(m);
                var url = @"http://" + ServerIP + ":81" + @"/gm?method=send_mail&params=" + output;
                common.HttpGet(url);
                MessageBox.Show("邮件发送成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查输入内容是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                BtnSendMail.Enabled = true;
            }
        }
    }
}
