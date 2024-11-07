using System.Data;
using NgopiSek.App.Context;
using Npgsql;
using Project_PBO_test.App.Context;
using Project_PBO_test.App.Core;
using Project_PBO_test.View;

namespace Project_PBO_test
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            SetupForm();
            CheckFirstTimeUser();
        }
        private void SetupForm()
        {
            // Setup ComboBox Role
            comboBoxRole.Items.Add("Admin");
            comboBoxRole.Items.Add("Kasir");
            comboBoxRole.SelectedIndex = 0;
        }
        private void CheckFirstTimeUser()
        {
            if (AdminContext.IsFirstUser())
            {
                MessageBox.Show("Selamat datang! Silakan registrasi admin pertama.",
                    "First Time Setup");
                RegisterFirstAdminForm registerForm = new RegisterFirstAdminForm();
                this.Hide();
                registerForm.ShowDialog();
                this.Show();
            }
        }
        private void buttonLogin_Click_1(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    DataTable result;
                    if (comboBoxRole.SelectedItem.ToString() == "Admin")
                    {
                        result = AdminContext.Login(textBoxUsername.Text, textBoxPassword.Text);
                    }
                    else
                    {
                        result = KasirContext.Login(textBoxUsername.Text, textBoxPassword.Text);
                    }

                    if (result.Rows.Count > 0)
                    {
                        // Login berhasil
                        if (comboBoxRole.SelectedItem.ToString() == "Admin")
                        {
                            AdminMainForm mainForm = new AdminMainForm();
                            this.Hide();
                            mainForm.ShowDialog();
                        }
                        else
                        {
                            KasirMainForm mainForm = new KasirMainForm();
                            this.Hide();
                            mainForm.ShowDialog();
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("Username harus diisi!", "Error");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Password harus diisi!", "Error");
                return false;
            }
            return true;
        }
        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBoxRole.SelectedItem.ToString() == "Kasir")
            {
                RegisterKasirForm registerForm = new RegisterKasirForm();
                this.Hide();
                registerForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Hanya kasir yang dapat melakukan registrasi.",
                    "Information");
            }
        }
    }
}
