using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMExport
{
    class common
    {
        public static string HttpGet(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception)
            {
                MessageBox.Show("http请求失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "";
        }


        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dt">需要导的数据</param>
        /// <param name="tile">excel中列的标题</param>
        public static void doExport(string fileName, DataTable dt, string[] tile)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Export Excel File";
            saveFileDialog.FileName = fileName;
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string str = "";
            try
            {
                //写标题
                for (int i = 0; i < tile.Length; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += tile[i].ToString().Trim();
                }
                sw.WriteLine(str);
                //写内容
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }tempStr += dt.Rows[j][k].ToString();
                    }sw.WriteLine(tempStr);
                }
                sw.Close();myStream.Close();
            }
            catch (Exception ex)
            {
                sw.Close();myStream.Close();
            }
            finally
            {
                sw.Close();myStream.Close();
            }
        }
    }

    struct stMail
    {
       public  string uid;
       public string mail_title;
       public string mail_content;
       public string prop_list;
    }

    struct stNotice
    {
        public string msg;
        public int start_time;
        public int end_time;
        public int interval;
    }
}
