using Project_PBO_test.App.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace Project_PBO_test.View
{
    public partial class AdminMainForm : Form
    {
        private Form activeForm = null;

        public AdminMainForm()
        {
            InitializeComponent();
            CustomizeDesign(); // Untuk styling sidebar/menu
            SetupHeader();
        }

        private void CustomizeDesign()
        {
            // Styling untuk panel menu
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);

            // Setup menu buttons
            foreach (Button button in panelMenu.Controls.OfType<Button>())
            {
                button.FlatStyle = FlatStyle.Flat;
                button.ForeColor = Color.Gainsboro;
                button.FlatAppearance.BorderSize = 0;
                button.Height = 60;
                button.Dock = DockStyle.Top;
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Padding = new Padding(10, 0, 0, 0);
            }
        }

        private void SetupHeader()
        {
            labelTitle.Text = "Dashboard Admin";
            labelWelcome.Text = $"Selamat datang, {AdminContext.GetCurrentAdminName()}";
            labelDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm");

            // Timer untuk update waktu
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                labelDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
            };
            timer.Start();
        }

        private void OpenChildForm(Form childForm, string title)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitle.Text = title;
        }

        private void btnManageKasir_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KasirManagementForm(), "Manajemen Kasir");
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductManagementForm(), "Manajemen Produk");
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CategoryManagementForm(), "Manajemen Kategori");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportsForm(), "Laporan Penjualan");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SettingsForm(), "Pengaturan");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                new LoginForm().Show();
            }
        }
    }
}
