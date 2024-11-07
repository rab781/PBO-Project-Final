namespace Project_PBO_test.View
{
    partial class RegisterKasirForm
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
            label5 = new Label();
            label6 = new Label();
            textBoxNama = new TextBox();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            textBoxConfirmPassword = new TextBox();
            textBoxPasskey = new TextBox();
            buttonRegister = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(176, 20);
            label1.Name = "label1";
            label1.Size = new Size(477, 48);
            label1.TabIndex = 0;
            label1.Text = "Silahkan Isi Form Registrasi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 79);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 1;
            label2.Text = "Nama";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(176, 148);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 2;
            label3.Text = "Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(176, 225);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 3;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(176, 284);
            label5.Name = "label5";
            label5.Size = new Size(156, 25);
            label5.TabIndex = 4;
            label5.Text = "Confirm Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(176, 353);
            label6.Name = "label6";
            label6.Size = new Size(73, 25);
            label6.TabIndex = 5;
            label6.Text = "Passkey";
            // 
            // textBoxNama
            // 
            textBoxNama.Location = new Point(176, 107);
            textBoxNama.Name = "textBoxNama";
            textBoxNama.Size = new Size(248, 31);
            textBoxNama.TabIndex = 6;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(176, 191);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(248, 31);
            textBoxUsername.TabIndex = 7;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(176, 253);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(248, 31);
            textBoxPassword.TabIndex = 8;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Location = new Point(176, 319);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(248, 31);
            textBoxConfirmPassword.TabIndex = 9;
            // 
            // textBoxPasskey
            // 
            textBoxPasskey.Location = new Point(176, 381);
            textBoxPasskey.Name = "textBoxPasskey";
            textBoxPasskey.Size = new Size(248, 31);
            textBoxPasskey.TabIndex = 10;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(508, 241);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(112, 34);
            buttonRegister.TabIndex = 11;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click_1;
            // 
            // RegisterKasirForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonRegister);
            Controls.Add(textBoxPasskey);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxNama);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterKasirForm";
            Text = "RegisterKasirForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxNama;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private TextBox textBoxConfirmPassword;
        private TextBox textBoxPasskey;
        private Button buttonRegister;
    }
}