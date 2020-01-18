namespace Vt.Client.App
{
    partial class ServerConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_server = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lb_server
            // 
            this.lb_server.FormattingEnabled = true;
            this.lb_server.ItemHeight = 15;
            this.lb_server.Location = new System.Drawing.Point(12, 12);
            this.lb_server.Name = "lb_server";
            this.lb_server.Size = new System.Drawing.Size(317, 334);
            this.lb_server.TabIndex = 0;
            this.lb_server.SelectedIndexChanged += new System.EventHandler(this.lb_server_SelectedIndexChanged);
            this.lb_server.DoubleClick += new System.EventHandler(this.lb_server_DoubleClick);
            // 
            // ServerConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 365);
            this.Controls.Add(this.lb_server);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ServerConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务器列表";
            this.Load += new System.EventHandler(this.ServerConfig_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_server;
    }
}