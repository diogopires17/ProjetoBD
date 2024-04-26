namespace aluguer_de_equipamentos
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
            System.Windows.Forms.Label Password;
            this.LoginEmail = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            this.LoginPassword = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginTitle = new System.Windows.Forms.Label();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            Password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new System.Drawing.Font("Arial Black", 15F);
            Password.Location = new System.Drawing.Point(42, 248);
            Password.Name = "Password";
            Password.Size = new System.Drawing.Size(116, 28);
            Password.TabIndex = 8;
            Password.Text = "Password";
            // 
            // LoginEmail
            // 
            this.LoginEmail.Location = new System.Drawing.Point(174, 187);
            this.LoginEmail.Margin = new System.Windows.Forms.Padding(5);
            this.LoginEmail.Name = "LoginEmail";
            this.LoginEmail.Size = new System.Drawing.Size(342, 20);
            this.LoginEmail.TabIndex = 7;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Arial Black", 15F);
            this.Email.Location = new System.Drawing.Point(42, 179);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(73, 28);
            this.Email.TabIndex = 6;
            this.Email.Text = "Email";
            // 
            // LoginPassword
            // 
            this.LoginPassword.Location = new System.Drawing.Point(174, 256);
            this.LoginPassword.Name = "LoginPassword";
            this.LoginPassword.PasswordChar = '*';
            this.LoginPassword.Size = new System.Drawing.Size(342, 20);
            this.LoginPassword.TabIndex = 9;
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Arial Black", 11F);
            this.LoginButton.Location = new System.Drawing.Point(387, 380);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LoginButton.Size = new System.Drawing.Size(129, 46);
            this.LoginButton.TabIndex = 10;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginTitle
            // 
            this.LoginTitle.AutoSize = true;
            this.LoginTitle.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.LoginTitle.Location = new System.Drawing.Point(249, 56);
            this.LoginTitle.Name = "LoginTitle";
            this.LoginTitle.Size = new System.Drawing.Size(98, 38);
            this.LoginTitle.TabIndex = 11;
            this.LoginTitle.Text = "Login";
            // 
            // createAccountButton
            // 
            this.createAccountButton.Font = new System.Drawing.Font("Arial Black", 11F);
            this.createAccountButton.Location = new System.Drawing.Point(47, 380);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.createAccountButton.Size = new System.Drawing.Size(201, 46);
            this.createAccountButton.TabIndex = 12;
            this.createAccountButton.Text = "Não tenho conta";
            this.createAccountButton.UseVisualStyleBackColor = true;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Black", 11F);
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(163, 42);
            this.button1.TabIndex = 13;
            this.button1.Text = "Sou um admin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Black", 11F);
            this.button2.Location = new System.Drawing.Point(423, 12);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(163, 42);
            this.button2.TabIndex = 14;
            this.button2.Text = "Sou um Técnico";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createAccountButton);
            this.Controls.Add(this.LoginTitle);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.LoginPassword);
            this.Controls.Add(Password);
            this.Controls.Add(this.LoginEmail);
            this.Controls.Add(this.Email);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginEmail;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox LoginPassword;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label LoginTitle;
        private System.Windows.Forms.Button createAccountButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}