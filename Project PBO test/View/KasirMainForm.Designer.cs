namespace Project_PBO_test.View
{
    partial class KasirMainForm
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
            panelMenu = new Panel();
            labelTitle = new Label();
            labelWelcome = new Label();
            labelDateTime = new Label();
            listViewProducts = new ListView();
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(listViewProducts);
            panelMenu.Location = new Point(87, 95);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(672, 162);
            panelMenu.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(87, 32);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(142, 25);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Dashboard Kasir";
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Location = new Point(252, 32);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(138, 25);
            labelWelcome.TabIndex = 1;
            labelWelcome.Text = "Selamat Datang";
            // 
            // labelDateTime
            // 
            labelDateTime.AutoSize = true;
            labelDateTime.Location = new Point(418, 32);
            labelDateTime.Name = "labelDateTime";
            labelDateTime.Size = new Size(138, 25);
            labelDateTime.TabIndex = 2;
            labelDateTime.Text = "Selamat Datang";
            // 
            // listViewProducts
            // 
            listViewProducts.Location = new Point(22, 15);
            listViewProducts.Name = "listViewProducts";
            listViewProducts.Size = new Size(170, 125);
            listViewProducts.TabIndex = 0;
            listViewProducts.UseCompatibleStateImageBehavior = false;
            // 
            // KasirMainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelDateTime);
            Controls.Add(labelWelcome);
            Controls.Add(labelTitle);
            Controls.Add(panelMenu);
            Name = "KasirMainForm";
            Text = "KasirMainForm";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelMenu;
        private Label labelTitle;
        private Label labelWelcome;
        private Label labelDateTime;
        private ListView listViewProducts;
    }
}