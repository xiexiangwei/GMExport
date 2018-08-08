using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMExport
{
    public partial class ChannelSwitch : Form
    {
        string ServerIP;
        public ChannelSwitch(string ip)
        {
            ServerIP = ip;
            InitializeComponent();
            RefreshData();
        }

        //刷新
        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        struct stChannelSwitch
        {
            public string config;
        }

        private string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }
        //同步数据
        private void Synchro_btn_Click(object sender, EventArgs e)
        {
            string configureText = this.configure_rtbox.Text;
            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(configureText);
                stChannelSwitch cfg;
                cfg.config = configureText;
                string str = JsonConvert.SerializeObject(cfg);
                var url = @"http://" + ServerIP + ":81" + @"/gm?method=update_channel_switch_config&params=" + str;
                common.HttpGet(url);
                MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("操作失败,格式错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshData()
        {
            var url = @"http://" + ServerIP + ":81" + @"/gm?method=get_channel_switch_config&params={}";
            string config = common.HttpGet(url);
            this.configure_rtbox.Text = ConvertJsonString(config);
        }
    }
}
