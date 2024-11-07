namespace Project_PBO_test.View
{
    partial class RegisterFirstAdminForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonRegister = new Button();
            textBoxNama = new TextBox();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            label5 = new Label();
            textBoxConfirmPassword = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(157, 36);
            label1.Name = "label1";
            label1.Size = new Size(599, 39);
            label1.TabIndex = 0;
            label1.Text = "Selamat Datang Anda adalah Admin Pertama";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 132);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 1;
            label2.Text = "Nama";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(266, 202);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 2;
            label3.Text = "Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(266, 258);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 3;
            label4.Text = "Password";
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(266, 366);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(247, 42);
            buttonRegister.TabIndex = 4;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click_1;
            // 
            // textBoxNama
            // 
            textBoxNama.Location = new Point(383, 132);
            textBoxNama.Name = "textBoxNama";
            textBoxNama.Size = new Size(150, 31);
            textBoxNama.TabIndex = 5;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(383, 199);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(150, 31);
            textBoxUsername.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(383, 255);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(150, 31);
            textBoxPassword.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(197, 305);
            label5.Name = "label5";
            label5.Size = new Size(156, 25);
            label5.TabIndex = 8;
            label5.Text = "Confirm Password";
            label5.Click += label5_Click;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Location = new Point(383, 302);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(150, 31);
            textBoxConfirmPassword.TabIndex = 9;
            // 
            // RegisterFirstAdminForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(label5);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxNama);
            Controls.Add(buttonRegister);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterFirstAdminForm";
            Text = "RegisterFirstAdminForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonRegister;
        private TextBox textBoxNama;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label label5;
        private TextBox textBoxConfirmPassword;
    }
}