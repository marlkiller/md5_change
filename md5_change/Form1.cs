using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using md5_change.Properties;

namespace md5_change
{
    public partial class Form1 : Form
    {
        private bool _status;
        private Thread _thread;

        // 循环等待时间:单位秒
        private static readonly object Lock = new object();
        private const int WaitTime = 1;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //AppendFile("C:\\Users\\voidm\\Desktop\\dev\\tmp\\Jar2Exe_src.msi");
            lable_msg.Text = Resources.plz_append_file;
        }

        private void AppendFile(string fileName)
        {
            if (IsExistsItem(fileName))
            {
                return;
            }

            var itemMsg = "";
            var item = new ListViewItem(fileName);
            var itemMd5Src = new ListViewItem.ListViewSubItem();
            try
            {
                itemMd5Src.Text = GetMd5HashFromFile(fileName);
            }
            catch (Exception ex)
            {
                itemMsg = ex.Message;
                itemMd5Src.Text = "";
            }

            item.SubItems.Add(itemMd5Src);

            var itemMd5New = new ListViewItem.ListViewSubItem
            {
                Text = ""
            };
            item.SubItems.Add(itemMd5New);

            var itemLen = new ListViewItem.ListViewSubItem();
            try
            {
                itemLen.Text = GetLenFile(fileName).ToString();
            }
            catch (Exception ex)
            {
                itemMsg = ex.Message;
                itemLen.Text = "";
            }

            item.SubItems.Add(itemLen);


            var itemCount = new ListViewItem.ListViewSubItem
            {
                Text = itemMsg
            };
            item.SubItems.Add(itemCount);

            listView1.Items.Add(item);
        }

        private static long GetLenFile(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                return fileStream.Length;
            }
        }

        /// <summary>
        /// 获取文件MD5值
        /// </summary>
        /// <param name="fileName">文件绝对路径</param>
        /// <returns>MD5值</returns>
        private static string GetMd5HashFromFile(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                var retVal = md5.ComputeHash(fileStream);
                var sb = new StringBuilder();
                foreach (var t in retVal)
                {
                    sb.Append(t.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private void item_start_once_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                lable_msg.Text = Resources.file_empty;
                return;
            }

            SetStatus(true);
            _thread = new Thread(ExecuteChangeMd5)
            {
                IsBackground = true,
                Name = "ONCE"
            };
            _thread.Start();
        }

        private void SetStatus(bool s)
        {
            lock (Lock)
            {
                _status = s;
            }
        }

        private bool GetStatus()
        {
            lock (Lock)
            {
                return _status;
            }
        }

        private void ExecuteChangeMd5()
        {
            RefreshContextBtm(false);

            while (GetStatus())
            {
                var random = new Random();
                const int newDataLen = 4;
                var newData = new byte[newDataLen];
                for (var j = 0; j < newDataLen; j++)
                {
                    newData[j] = (byte) random.Next(0, 9);
                }

                var totalCount = listView1.Items.Count;
                // bar_process.Maximum = total_count;
                for (var i = 0; i < totalCount; i++)
                {
                    if (!GetStatus())
                    {
                        lable_msg.Text = Resources.stop;
                        return;
                    }

                    listView1.EnsureVisible(i);

                    var item = listView1.Items[i];

                    if (item.SubItems[1].Text == "" || item.SubItems[3].Text == "")
                    {
                        continue;
                    }

                    var backColor = item.BackColor;

                    var position = int.Parse(item.SubItems[3].Text);
                    var fileName = item.Text;
                    lable_msg.Text = $@"Execute : {fileName}";
                    lable_process.Text = $@"{i + 1}/{totalCount}";


                    // 这进度条有延迟...
                    // bar_process.Value = i + 1;
                    item.BackColor = System.Drawing.Color.Blue;

                    try
                    {
                        var writeStream = File.OpenWrite(fileName);
                        writeStream.Seek(position, SeekOrigin.Begin);
                        writeStream.Write(newData, 0, newData.Length);
                        writeStream.Close();

                        item.SubItems[2].Text = GetMd5HashFromFile(fileName);
                        item.SubItems[4].Text = "";
                    }
                    catch (Exception ex)
                    {
                        item.SubItems[2].Text = "";
                        item.SubItems[4].Text = ex.Message;
                    }

                    item.BackColor = backColor;
                }

                lable_total.Text = (int.Parse(lable_total.Text) + 1).ToString();

                if (Thread.CurrentThread.Name == "ONCE")
                {
                    SetStatus(false);
                    RefreshContextBtm(true);
                    lable_msg.Text = Resources.operation_complete;
                    break;
                }

                Thread.Sleep(WaitTime * 1000);
            }
        }


        private void stop_task()
        {
            if (_thread != null)
            {
                while (_thread.IsAlive)
                {
                    contextMenuStrip1.Items[6].Text = Resources.strip_stopping;
                    Thread.Sleep(3000);
                }
            }

            RefreshContextBtm(true);
            contextMenuStrip1.Items[6].Text = Resources.stop;
            contextMenuStrip1.Items[6].Enabled = true;
            lable_msg.Text = Resources.operation_complete;
        }

        private void item_stop_Click(object sender, EventArgs e)
        {
            SetStatus(false);
            contextMenuStrip1.Items[6].Enabled = false;
            var thread = new Thread(stop_task)
            {
                IsBackground = true,
                Name = "STOP"
            };
            thread.Start();
        }

        private void RefreshContextBtm(bool flag)
        {
            contextMenuStrip1.Items[0].Enabled = flag;
            contextMenuStrip1.Items[1].Enabled = flag;
            contextMenuStrip1.Items[2].Enabled = flag;
            contextMenuStrip1.Items[3].Enabled = flag;
            contextMenuStrip1.Items[5].Enabled = flag;
        }


        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            contextMenuStrip1.Show(listView1, e.Location);
        }

        private void item_start_auto_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                lable_msg.Text = Resources.file_empty;
                return;
            }

            SetStatus(true);
            _thread = new Thread(ExecuteChangeMd5)
            {
                IsBackground = true,
                Name = "FUCKIT"
            };
            _thread.Start();
        }

        private void item_remove_Click(object sender, EventArgs e)
        {
            for (var i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                var item = listView1.SelectedItems[i];
                listView1.Items.Remove(item);
            }
        }

        private void item_remove_all_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void item_append_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var files = openFileDialog1.FileNames;
            foreach (var t in files)
            {
                AppendFile(t);
            }
        }

        private bool IsExistsItem(string text)
        {
            return listView1.Items.Cast<ListViewItem>().Any(item => item.Text == text);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var tip = listView1.SelectedItems[0].SubItems[4].Text;
            toolTip1.SetToolTip(listView1, tip);
        }

        private void item_reload_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var itemMsg = "";
            var fileName = listView1.SelectedItems[0].Text;
            var itemMd5Src = this.listView1.SelectedItems[0].SubItems[1];
            try
            {
                itemMd5Src.Text = GetMd5HashFromFile(fileName);
            }
            catch (Exception ex)
            {
                itemMsg = ex.Message;
                itemMd5Src.Text = "";
            }

            var itemLen = listView1.SelectedItems[0].SubItems[3];
            try
            {
                itemLen.Text = GetLenFile(fileName).ToString();
            }
            catch (Exception ex)
            {
                itemMsg = ex.Message;
                itemLen.Text = "";
            }

            if (itemMsg == "")
            {
                listView1.SelectedItems[0].SubItems[2].Text = "";
            }
            listView1.SelectedItems[0].SubItems[4].Text = itemMsg;
        }
    }
}