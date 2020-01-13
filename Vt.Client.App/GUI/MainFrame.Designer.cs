namespace Vt.Client.App {
    partial class MainFrame {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createLobbyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_nick_name = new System.Windows.Forms.TextBox();
            this.btn_save_name = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lb_lobs = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.serversToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(711, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createLobbyToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.newToolStripMenuItem.Text = "New";
            // 
            // createLobbyToolStripMenuItem
            // 
            this.createLobbyToolStripMenuItem.Name = "createLobbyToolStripMenuItem";
            this.createLobbyToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.createLobbyToolStripMenuItem.Text = "Create_Lobby";
            this.createLobbyToolStripMenuItem.Click += new System.EventHandler(this.createLobbyToolStripMenuItem_Click);
            // 
            // serversToolStripMenuItem
            // 
            this.serversToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverConfigToolStripMenuItem});
            this.serversToolStripMenuItem.Name = "serversToolStripMenuItem";
            this.serversToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.serversToolStripMenuItem.Text = "Settings";
            // 
            // serverConfigToolStripMenuItem
            // 
            this.serverConfigToolStripMenuItem.Name = "serverConfigToolStripMenuItem";
            this.serverConfigToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.serverConfigToolStripMenuItem.Text = "Server Config";
            this.serverConfigToolStripMenuItem.Click += new System.EventHandler(this.serverConfigToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // tb_nick_name
            // 
            this.tb_nick_name.Location = new System.Drawing.Point(349, 4);
            this.tb_nick_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_nick_name.Name = "tb_nick_name";
            this.tb_nick_name.Size = new System.Drawing.Size(228, 25);
            this.tb_nick_name.TabIndex = 2;
            this.tb_nick_name.TextChanged += new System.EventHandler(this.tb_nickName_TextChanged_1);
            // 
            // btn_save_name
            // 
            this.btn_save_name.Location = new System.Drawing.Point(582, 4);
            this.btn_save_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_save_name.Name = "btn_save_name";
            this.btn_save_name.Size = new System.Drawing.Size(118, 25);
            this.btn_save_name.TabIndex = 3;
            this.btn_save_name.Text = "Save Name";
            this.btn_save_name.UseVisualStyleBackColor = true;
            this.btn_save_name.Click += new System.EventHandler(this.btn_save_name_Click);
            // 
            // backgroundWorker1
            // 
            // 
            // lb_lobs
            // 
            this.lb_lobs.Font = new System.Drawing.Font("宋体", 14F);
            this.lb_lobs.FormattingEnabled = true;
            this.lb_lobs.ItemHeight = 23;
            this.lb_lobs.Location = new System.Drawing.Point(12, 31);
            this.lb_lobs.Name = "lb_lobs";
            this.lb_lobs.Size = new System.Drawing.Size(687, 326);
            this.lb_lobs.TabIndex = 4;
            this.lb_lobs.SelectedIndexChanged += new System.EventHandler(this.lb_lobs_SelectedIndexChanged);
            this.lb_lobs.DoubleClick += new System.EventHandler(this.lb_lobs_DoubleClick);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 375);
            this.Controls.Add(this.lb_lobs);
            this.Controls.Add(this.btn_save_name);
            this.Controls.Add(this.tb_nick_name);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createLobbyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serversToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_nick_name;
        private System.Windows.Forms.Button btn_save_name;
        private System.Windows.Forms.ToolStripMenuItem serverConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox lb_lobs;
    }
}

