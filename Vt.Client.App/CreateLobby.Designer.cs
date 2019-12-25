namespace Vt.Client.App {
    partial class CreateLobby {
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
            this.tb_lobby_name = new System.Windows.Forms.TextBox();
            this.lobby_name = new System.Windows.Forms.Label();
            this.lb_server = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_create_lobby = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_lobby_name
            // 
            this.tb_lobby_name.Location = new System.Drawing.Point(125, 12);
            this.tb_lobby_name.Name = "tb_lobby_name";
            this.tb_lobby_name.Size = new System.Drawing.Size(499, 28);
            this.tb_lobby_name.TabIndex = 0;
            this.tb_lobby_name.Text = "Lobby";
            this.tb_lobby_name.TextChanged += new System.EventHandler(this.tb_lobby_name_TextChanged);
            // 
            // lobby_name
            // 
            this.lobby_name.AutoSize = true;
            this.lobby_name.Location = new System.Drawing.Point(3, 15);
            this.lobby_name.Name = "lobby_name";
            this.lobby_name.Size = new System.Drawing.Size(116, 18);
            this.lobby_name.TabIndex = 1;
            this.lobby_name.Text = "Lobby Name :";
            // 
            // lb_server
            // 
            this.lb_server.FormattingEnabled = true;
            this.lb_server.ItemHeight = 18;
            this.lb_server.Location = new System.Drawing.Point(125, 46);
            this.lb_server.Name = "lb_server";
            this.lb_server.Size = new System.Drawing.Size(499, 184);
            this.lb_server.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Servers :";
            // 
            // btn_create_lobby
            // 
            this.btn_create_lobby.Location = new System.Drawing.Point(522, 244);
            this.btn_create_lobby.Name = "btn_create_lobby";
            this.btn_create_lobby.Size = new System.Drawing.Size(102, 38);
            this.btn_create_lobby.TabIndex = 4;
            this.btn_create_lobby.Text = "Create";
            this.btn_create_lobby.UseVisualStyleBackColor = true;
            this.btn_create_lobby.Click += new System.EventHandler(this.btn_create_lobby_Click);
            // 
            // CreateLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 294);
            this.Controls.Add(this.btn_create_lobby);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_server);
            this.Controls.Add(this.lobby_name);
            this.Controls.Add(this.tb_lobby_name);
            this.Name = "CreateLobby";
            this.Text = "CreateLobby";
            this.Load += new System.EventHandler(this.CreateLobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_lobby_name;
        private System.Windows.Forms.Label lobby_name;
        private System.Windows.Forms.ListBox lb_server;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_create_lobby;
    }
}