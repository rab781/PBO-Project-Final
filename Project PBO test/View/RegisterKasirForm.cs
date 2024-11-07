using Project_PBO_test.App.Context;
using Project_PBO_test.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NgopiSek.App.Context;

namespace Project_PBO_test.View
{
    public partial class RegisterKasirForm : Form
    {
        public RegisterKasirForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click_1(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    string correctPasskey = AdminContext.GetPasskey();
                    if (textBoxPasskey.Text != correctPasskey)
                    {
                        MessageBox.Show("Passkey tidak valid!", "Error");
                        return;
                    }

                    M_Kasir kasir = new M_Kasir
                    {
                        nama_kasir = textBoxNama.Text,
                        username_kasir = textBoxUsername.Text,
                        password_kasir = textBoxPassword.Text
                    };

                    KasirContext.AddKasir(kasir);
                    MessageBox.Show("Registrasi kasir berhasil!", "Success");
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
            if (string.IsNullOrWhiteSpace(textBoxPasskey.Text))
            {
                MessageBox.Show("Passkey harus diisi!");
                return false;
            }
            return true;
        }
    }
}
