
namespace App_QLCF
{
    partial class Login
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
            this.user = new System.Windows.Forms.PictureBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btncheckout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.user)).BeginInit();
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.Image = global::App_QLCF.Properties.Resources.simple_user_icon;
            this.user.Location = new System.Drawing.Point(83, 26);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(148, 146);
            this.user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.user.TabIndex = 2;
            this.user.TabStop = false;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(22, 200);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(274, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(22, 235);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(274, 20);
            this.txtPassWord.TabIndex = 4;
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Location = new System.Drawing.Point(49, 281);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(220, 40);
            this.btnlogin.TabIndex = 5;
            this.btnlogin.Text = "ĐĂNG NHẬP";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btncheckout
            // 
            this.btncheckout.BackColor = System.Drawing.Color.MidnightBlue;
            this.btncheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncheckout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btncheckout.Location = new System.Drawing.Point(49, 342);
            this.btncheckout.Name = "btncheckout";
            this.btncheckout.Size = new System.Drawing.Size(220, 40);
            this.btncheckout.TabIndex = 6;
            this.btncheckout.Text = "ĐĂNG XUẤT";
            this.btncheckout.UseVisualStyleBackColor = false;
            this.btncheckout.Click += new System.EventHandler(this.btncheckout_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(331, 450);
            this.Controls.Add(this.btncheckout);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.user);
            this.Name = "Login";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.user)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox user;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btncheckout;
    }
}

