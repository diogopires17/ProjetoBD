namespace aluguer_de_equipamentos
{
    partial class UserHomePage
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
            this.UserEquipmentList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserEquipmentList
            // 
            this.UserEquipmentList.FormattingEnabled = true;
            this.UserEquipmentList.Location = new System.Drawing.Point(1, 0);
            this.UserEquipmentList.Name = "UserEquipmentList";
            this.UserEquipmentList.Size = new System.Drawing.Size(383, 563);
            this.UserEquipmentList.TabIndex = 0;
            this.UserEquipmentList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Black", 15F);
            this.button1.Location = new System.Drawing.Point(845, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 79);
            this.button1.TabIndex = 1;
            this.button1.Text = "Alugar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // UserHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 568);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UserEquipmentList);
            this.Name = "UserHomePage";
            this.Text = "UserHomePage";
            this.Load += new System.EventHandler(this.UserHomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox UserEquipmentList;
        private System.Windows.Forms.Button button1;
    }
}