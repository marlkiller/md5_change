
namespace md5_change
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.src_md5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.new_md5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.len = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lable_msg = new System.Windows.Forms.ToolStripStatusLabel();
            this.lable_process = new System.Windows.Forms.ToolStripStatusLabel();
            this.bar_process = new System.Windows.Forms.ToolStripProgressBar();
            this.lable_total = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.item_append = new System.Windows.Forms.ToolStripMenuItem();
            this.item_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.item_remove_all = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.item_start = new System.Windows.Forms.ToolStripMenuItem();
            this.item_start_once = new System.Windows.Forms.ToolStripMenuItem();
            this.item_start_auto = new System.Windows.Forms.ToolStripMenuItem();
            this.item_stop = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.file,
            this.src_md5,
            this.new_md5,
            this.len,
            this.msg});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(801, 233);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // file
            // 
            this.file.Text = "file";
            this.file.Width = 237;
            // 
            // src_md5
            // 
            this.src_md5.Text = "src_md5";
            this.src_md5.Width = 225;
            // 
            // new_md5
            // 
            this.new_md5.Text = "new_md5";
            this.new_md5.Width = 215;
            // 
            // len
            // 
            this.len.Text = "len";
            // 
            // msg
            // 
            this.msg.Text = "msg";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lable_msg,
            this.lable_process,
            this.bar_process,
            this.lable_total});
            this.statusStrip1.Location = new System.Drawing.Point(0, 282);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lable_msg
            // 
            this.lable_msg.Name = "lable_msg";
            this.lable_msg.Size = new System.Drawing.Size(66, 17);
            this.lable_msg.Text = "lable_msg";
            this.lable_msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lable_process
            // 
            this.lable_process.Name = "lable_process";
            this.lable_process.Size = new System.Drawing.Size(321, 17);
            this.lable_process.Spring = true;
            this.lable_process.Text = "lable_process";
            this.lable_process.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bar_process
            // 
            this.bar_process.Name = "bar_process";
            this.bar_process.Size = new System.Drawing.Size(100, 16);
            // 
            // lable_total
            // 
            this.lable_total.Name = "lable_total";
            this.lable_total.Size = new System.Drawing.Size(321, 17);
            this.lable_total.Spring = true;
            this.lable_total.Text = "0";
            this.lable_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_append,
            this.item_remove,
            this.item_remove_all,
            this.toolStripSeparator1,
            this.item_start,
            this.item_stop});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 120);
            // 
            // item_append
            // 
            this.item_append.Name = "item_append";
            this.item_append.Size = new System.Drawing.Size(148, 22);
            this.item_append.Text = "添加文件";
            this.item_append.Click += new System.EventHandler(this.item_append_Click);
            // 
            // item_remove
            // 
            this.item_remove.Name = "item_remove";
            this.item_remove.Size = new System.Drawing.Size(148, 22);
            this.item_remove.Text = "刪除当前文件";
            this.item_remove.Click += new System.EventHandler(this.item_remove_Click);
            // 
            // item_remove_all
            // 
            this.item_remove_all.Name = "item_remove_all";
            this.item_remove_all.Size = new System.Drawing.Size(148, 22);
            this.item_remove_all.Text = "刪除所有文件";
            this.item_remove_all.Click += new System.EventHandler(this.item_remove_all_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // item_start
            // 
            this.item_start.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_start_once,
            this.item_start_auto});
            this.item_start.Name = "item_start";
            this.item_start.Size = new System.Drawing.Size(148, 22);
            this.item_start.Text = "开始";
            // 
            // item_start_once
            // 
            this.item_start_once.Name = "item_start_once";
            this.item_start_once.Size = new System.Drawing.Size(136, 22);
            this.item_start_once.Text = "一次";
            this.item_start_once.Click += new System.EventHandler(this.item_start_once_Click);
            // 
            // item_start_auto
            // 
            this.item_start_auto.Name = "item_start_auto";
            this.item_start_auto.Size = new System.Drawing.Size(136, 22);
            this.item_start_auto.Text = "循环无限次";
            this.item_start_auto.Click += new System.EventHandler(this.item_start_auto_Click);
            // 
            // item_stop
            // 
            this.item_stop.Name = "item_stop";
            this.item_stop.Size = new System.Drawing.Size(148, 22);
            this.item_stop.Text = "停止";
            this.item_stop.Click += new System.EventHandler(this.item_stop_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "MSI文件(*.MSI)|*.msi";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 304);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader file;
        private System.Windows.Forms.ColumnHeader src_md5;
        private System.Windows.Forms.ColumnHeader new_md5;
        private System.Windows.Forms.ColumnHeader len;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lable_msg;
        private System.Windows.Forms.ToolStripStatusLabel lable_process;
        private System.Windows.Forms.ToolStripProgressBar bar_process;
        private System.Windows.Forms.ToolStripStatusLabel lable_total;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem item_append;
        private System.Windows.Forms.ToolStripMenuItem item_remove;
        private System.Windows.Forms.ColumnHeader msg;
        private System.Windows.Forms.ToolStripMenuItem item_remove_all;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem item_start;
        private System.Windows.Forms.ToolStripMenuItem item_start_once;
        private System.Windows.Forms.ToolStripMenuItem item_start_auto;
        private System.Windows.Forms.ToolStripMenuItem item_stop;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

