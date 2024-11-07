using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_PBO_test.App.Context;
using Project_PBO_test.App.Models;

namespace Project_PBO_test.View
{
    public partial class RegisterFirstAdminForm : Form
    {
        public RegisterFirstAdminForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click_1(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    M_Admin admin = new M_Admin
                    {
                        nama_admin = textBoxNama.Text,
                        username_admin = textBoxUsername.Text,
                        password_admin = textBoxPassword.Text
                    };

                    AdminContext.RegisterFirstAdmin(admin);

                    string passkey = AdminContext.GetPasskey();
                    MessageBox.Show($"Registrasi berhasil!\n\nPasskey untuk registrasi kasir: {passkey}\n" +
                                    "Simpan passkey ini dengan aman, kasir membutuhkannya untuk registrasi.",
                        "Registration Success");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error");
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxNama.Text))
            {
                MessageBox.Show("Nama harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("Username harus diisi!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Password harus diisi!");
                return false;
            }
            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Password dan konfirmasi password tidak cocok!");
                return false;
            }
            return true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
