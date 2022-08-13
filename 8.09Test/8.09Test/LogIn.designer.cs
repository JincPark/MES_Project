
namespace _8._09Test
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.btnPWChange = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPWChange
            // 
            this.btnPWChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(202)))), ((int)(((byte)(186)))));
            this.btnPWChange.FlatAppearance.BorderSize = 0;
            this.btnPWChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPWChange.Font = new System.Drawing.Font("한컴 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnPWChange.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPWChange.Location = new System.Drawing.Point(204, 270);
            this.btnPWChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPWChange.Name = "btnPWChange";
            this.btnPWChange.Size = new System.Drawing.Size(126, 31);
            this.btnPWChange.TabIndex = 11;
            this.btnPWChange.Text = "비밀번호 변경";
            this.btnPWChange.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(202)))), ((int)(((byte)(186)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("한컴 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Location = new System.Drawing.Point(204, 207);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(126, 31);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPw
            // 
            this.txtPw.BackColor = System.Drawing.SystemColors.Window;
            this.txtPw.Location = new System.Drawing.Point(12, 273);
            this.txtPw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(174, 25);
            this.txtPw.TabIndex = 9;
            this.txtPw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPw_KeyDown);
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserId.Location = new System.Drawing.Point(12, 208);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(174, 25);
            this.txtUserId.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.label2.Font = new System.Drawing.Font("한컴 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(10, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "PW";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.label1.Font = new System.Drawing.Font("한컴 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(10, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Image = global::_8._09Test.Properties.Resources.KakaoTalk_20220813_172452273;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(323, 161);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(344, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPWChange);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogIn";
            this.Text = "LOG IN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPWChange;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}