namespace aluguer_de_equipamentos
{
    partial class TecnicoLogin
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
            this.voltar = new System.Windows.Forms.Button();
            this.LoginTitle = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginPassword = new System.Windows.Forms.TextBox();
            this.LoginEmail = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            Password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new System.Drawing.Font("Arial Black", 15F);
            Password.Location = new System.Drawing.Point(76, 229);
            Password.Name = "Password";
            Password.Size = new System.Drawing.Size(116, 28);
            Password.TabIndex = 22;
            Password.Text = "Password";
            // 
            // voltar
            // 
            this.voltar.Font = new System.Drawing.Font("Arial Black", 11F);
            this.voltar.Location = new System.Drawing.Point(81, 361);
            this.voltar.Name = "voltar";
            this.voltar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.voltar.Size = new System.Drawing.Size(201, 46);
            this.voltar.TabIndex = 26;
            this.voltar.Text = "Voltar";
            this.voltar.UseVisualStyleBackColor = true;
            this.voltar.Click += new System.EventHandler(this.voltar_Click);
            // 
            // LoginTitle
            // 
            this.LoginTitle.AutoSize = true;
            this.LoginTitle.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.LoginTitle.Location = new System.Drawing.Point(241, 39);
            this.LoginTitle.Name = "LoginTitle";
            this.LoginTitle.Size = new System.Drawing.Size(215, 38);
            this.LoginTitle.TabIndex = 25;
            this.LoginTitle.Text = "TecnicoLogin";
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Arial Black", 11F);
            this.LoginButton.Location = new System.Drawing.Point(421, 361);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LoginButton.Size = new System.Drawing.Size(129, 46);
            this.LoginButton.TabIndex = 24;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginPassword
            // 
            this.LoginPassword.Location = new System.Drawing.Point(208, 237);
            this.LoginPassword.Name = "LoginPassword";
            this.LoginPassword.PasswordChar = '*';
            this.LoginPassword.Size = new System.Drawing.Size(342, 20);
            this.LoginPassword.TabIndex = 23;
            // 
            // LoginEmail
            // 
            this.LoginEmail.Location = new System.Drawing.Point(208, 168);
            this.LoginEmail.Margin = new System.Windows.Forms.Padding(5);
            this.LoginEmail.Name = "LoginEmail";
            this.LoginEmail.Size = new System.Drawing.Size(342, 20);
            this.LoginEmail.TabIndex = 21;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Arial Black", 15F);
            this.Email.Location = new System.Drawing.Point(76, 160);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(73, 28);
            this.Email.TabIndex = 20;
            this.Email.Text = "Email";
            // 
            // TecnicoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 450);
            this.Controls.Add(this.voltar);
            this.Controls.Add(this.LoginTitle);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.LoginPassword);
            this.Controls.Add(Password);
            this.Controls.Add(this.LoginEmail);
            this.Controls.Add(this.Email);
            this.Name = "TecnicoLogin";
            this.Text = "TecnicoLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button voltar;
        private System.Windows.Forms.Label LoginTitle;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox LoginPassword;
        private System.Windows.Forms.TextBox LoginEmail;
        private System.Windows.Forms.Label Email;
    }
}