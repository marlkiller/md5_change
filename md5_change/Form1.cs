using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace md5_change
{
    public partial class Form1 : Form
    {
        public bool statu = false;
        private static object _lock = new object();

        // 循环等待时间:单位秒
        private static int waitTime = 1;

        Thread thread;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //AppendFile("C:\\Users\\voidm\\Desktop\\dev\\tmp\\Jar2Exe_src.msi");
            lable_msg.Text = "请添加文件!";


        }

        private void AppendFile(string file)
        {
            if (IsExistsItem(file))
            {
                return;
            }
                
            ListViewItem item = new ListViewItem(file);
            ListViewItem.ListViewSubItem itemMd5Src = new ListViewItem.ListViewSubItem();
            itemMd5Src.Text = GetMD5HashFromFile(file);
            item.SubItems.Add(itemMd5Src);

            ListViewItem.ListViewSubItem itemMd5New = new ListViewItem.ListViewSubItem();
            itemMd5New.Text = "";
            item.SubItems.Add(itemMd5New);

            ListViewItem.ListViewSubItem itemLen = new ListViewItem.ListViewSubItem();
            itemLen.Text = GetLenFile(file).ToString();
            item.SubItems.Add(itemLen);


            ListViewItem.ListViewSubItem itemCount = new ListViewItem.ListViewSubItem();
            // TODO 暂未定义
            itemCount.Text = "TBD_msg";
            item.SubItems.Add(itemCount);

            listView1.Items.Add(item);
        }

        public static long GetLenFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                return fileStream.Length;
            }
        }

        /// <summary>
        /// 获取文件MD5值
        /// </summary>
        /// <param name="fileName">文件绝对路径</param>
        /// <returns>MD5值</returns>
        public static string GetMD5HashFromFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(fileStream);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void item_start_once_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                lable_msg.Text = "当前文件列表为空,请添加!";
                return;
            }
            SetStatu(true);
            thread = new Thread(ExecuteChangeMd5);
            thread.IsBackground = true;
            thread.Name = "ONCE";
            thread.Start();

        }

        private void SetStatu(bool s)
        {
            lock (_lock)
            {
                statu = s;
            }
        }

        private bool GetStatu()
        {
            lock (_lock)
            {
                return statu;
            }
        }

        private void ExecuteChangeMd5()
        {
            RefreshContextBtm(false);

            while (GetStatu())
            {
                Random random = new Random();
                int newDataLen = 4;
                byte[] newData = new byte[newDataLen];
                for (int j = 0; j < newDataLen; j++)
                {
                    newData[j] = (byte)random.Next(0, 9);
                }

                int total_count = listView1.Items.Count;
                // bar_process.Maximum = total_count;
                for (int i = 0; i < total_count; i++)
                {
                    if (!GetStatu())
                    {
                        lable_msg.Text = "已停止!!";
                        return;
                    }
                    
                    listView1.EnsureVisible(i);
                    
                    ListViewItem item = listView1.Items[i];
                    System.Drawing.Color backColor = item.BackColor;
                    item.BackColor = System.Drawing.Color.Blue;
                    int position = int.Parse(item.SubItems[3].Text);
                    string fileName = item.Text;
                    lable_msg.Text = $"Execute : {fileName}";
                    lable_process.Text = $"{i + 1}/{total_count}";
                    // bar_process.Value = i + 1;

                    FileStream writeStream = File.OpenWrite(fileName);
                    writeStream.Seek(position, SeekOrigin.Begin);
                    writeStream.Write(newData, 0, newData.Length);
                    writeStream.Close();

                    item.SubItems[2].Text = GetMD5HashFromFile(fileName);
                    item.BackColor = backColor;

                }
                lable_total.Text = (int.Parse(lable_total.Text) + 1).ToString();

                if (Thread.CurrentThread.Name == "ONCE")
                {
                    SetStatu(false);
                    RefreshContextBtm(true);
                    lable_msg.Text = "执行完毕";
                    break;
                }

                Thread.Sleep(waitTime*1000);

            }

        }


        private void stop_task()
        {
            if (thread != null)
            {
                while (thread.IsAlive)
                {
                    contextMenuStrip1.Items[5].Text = "停止中..";
                    Thread.Sleep(3000);
                }
            }
            
            RefreshContextBtm(true);
            contextMenuStrip1.Items[5].Text = "停止";
            contextMenuStrip1.Items[5].Enabled = true;
            lable_msg.Text = "执行完毕";
        }
        private void item_stop_Click(object sender, EventArgs e)
        {
            SetStatu(false);
            contextMenuStrip1.Items[5].Enabled = false;
            Thread thread = new Thread(stop_task);
            thread.IsBackground = true;
            thread.Name = "STOP";
            thread.Start();
        }

        private void RefreshContextBtm(bool flag)
        {
            contextMenuStrip1.Items[0].Enabled = flag;
            contextMenuStrip1.Items[1].Enabled = flag;
            contextMenuStrip1.Items[2].Enabled = flag;
            contextMenuStrip1.Items[4].Enabled = flag;
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
                lable_msg.Text = "当前文件列表为空,请添加!";
                return;
            }
                
            SetStatu(true);
            thread = new Thread(ExecuteChangeMd5);
            thread.IsBackground = true;
            thread.Name = "FUCKIT";
            thread.Start();
        }

        private void item_remove_Click(object sender, EventArgs e)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem item = listView1.SelectedItems[i];
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
            string[] files = openFileDialog1.FileNames;
            for (int i = 0; i < files.Length; i++)
            {
                AppendFile(files[i]);
            }
        }

        private bool IsExistsItem(string text)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text == text)
                    return true;
            }
            return false;
        }

       
    }
}
