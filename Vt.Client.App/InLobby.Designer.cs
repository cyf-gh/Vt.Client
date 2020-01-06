namespace Vt.Client.App {
    partial class InLobby {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_video_url = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_viewerList = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tb_video_url
            // 
            this.tb_video_url.Location = new System.Drawing.Point(147, 10);
            this.tb_video_url.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_video_url.Name = "tb_video_url";
            this.tb_video_url.Size = new System.Drawing.Size(554, 25);
            this.tb_video_url.TabIndex = 0;
            this.tb_video_url.TextChanged += new System.EventHandler(this.tb_video_url_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(601, 317);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lb_viewerList
            // 
            this.lb_viewerList.FormattingEnabled = true;
            this.lb_viewerList.ItemHeight = 15;
            this.lb_viewerList.Location = new System.Drawing.Point(11, 38);
            this.lb_viewerList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lb_viewerList.Name = "lb_viewerList";
            this.lb_viewerList.Size = new System.Drawing.Size(690, 274);
            this.lb_viewerList.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(11, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Share Cookie";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // InLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 361);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lb_viewerList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_video_url);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InLobby";
            this.Text = "InLobby";
            this.Load += new System.EventHandler(this.InLobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_video_url;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lb_viewerList;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}