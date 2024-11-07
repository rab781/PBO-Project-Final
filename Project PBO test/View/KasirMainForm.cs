using Project_PBO_test.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace Project_PBO_test.View
{
    public partial class KasirMainForm : Form
    {
        private Form activeForm = null;
        private M_Kasir currentKasir;

        public KasirMainForm()
        {
            InitializeComponent();
            CustomizeDesign();
            SetupHeader();
            LoadInitialData();
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
            labelTitle.Text = "Dashboard Kasir";
            labelWelcome.Text = $"Selamat datang, kasir";

            // Set culture ke Indonesia
            CultureInfo culture = new CultureInfo("id-ID");

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                labelDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm", culture);
            };
            timer.Start();
        }

        private void LoadInitialData()
        {
            // Load data produk ke combobox atau listview
            LoadProducts();
            // Setup cart/keranjang belanja
            InitializeCart();
        }

        private void LoadProducts()
        {
            try
            {
                DataTable products = ProductContext.GetAvailableProducts();
                // Tampilkan produk ke dalam listview atau grid
                listViewProducts.Items.Clear();

                foreach (DataRow row in products.Rows)
                {
                    ListViewItem item = new ListViewItem(row["id_produk"].ToString());
                    item.SubItems.Add(row["nama_produk"].ToString());
                    item.SubItems.Add(row["harga_produk"].ToString("N0"));
                    item.SubItems.Add(row["kuantitas_produk"].ToString());
                    listViewProducts.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error");
            }
        }

        private void InitializeCart()
        {
            // Setup listview untuk keranjang belanja
            listViewCart.Columns.Add("Nama Produk", 200);
            listViewCart.Columns.Add("Harga", 100);
            listViewCart.Columns.Add("Jumlah", 70);
            listViewCart.Columns.Add("Subtotal", 120);
        }

        //private void btnNewTransaction_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new TransactionForm(currentKasir), "Transaksi Baru");
        //}

        //private void btnViewTransactions_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new TransactionHistoryForm(currentKasir), "Riwayat Transaksi");
        //}

        //private void btnProfile_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new KasirProfileForm(currentKasir), "Profil Kasir");
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

        // Method untuk menangani transaksi
        private void AddToCart(string productId, int quantity)
        {
            try
            {
                DataTable product = ProductContext.GetById(int.Parse(productId));
                if (product.Rows.Count > 0)
                {
                    DataRow row = product.Rows[0];
                    int available = Convert.ToInt32(row["kuantitas_produk"]);

                    if (quantity <= available)
                    {
                        decimal price = Convert.ToDecimal(row["harga_produk"]);
                        decimal subtotal = price * quantity;

                        ListViewItem item = new ListViewItem(row["nama_produk"].ToString());
                        item.SubItems.Add(price.ToString("N0"));
                        item.SubItems.Add(quantity.ToString());
                        item.SubItems.Add(subtotal.ToString("N0"));
                        item.Tag = productId; // Simpan ID produk

                        listViewCart.Items.Add(item);
                        UpdateTotal();
                    }
                    else
                    {
                        MessageBox.Show("Stok tidak mencukupi!", "Warning");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to cart: {ex.Message}", "Error");
            }
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (ListViewItem item in listViewCart.Items)
            {
                total += decimal.Parse(item.SubItems[3].Text,
                    System.Globalization.NumberStyles.Currency);
            }
            labelTotal.Text = $"Total: Rp {total:N0}";
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (listViewCart.Items.Count == 0)
            {
                MessageBox.Show("Keranjang masih kosong!", "Warning");
                return;
            }

            try
            {
                // Buat transaksi baru
                M_Transaksi transaksi = new M_Transaksi
                {
                    tanggal_transaksi = DateTime.Now,
                    id_kasir = currentKasir.id_kasir,
                    customer_name = textBoxCustomer.Text,
                    id_metode_pembayaran = (int)comboBoxPaymentMethod.SelectedValue
                };

                // Simpan transaksi dan dapat id transaksi
                int transactionId = await TransactionContext.CreateTransaction(transaksi);

                // Simpan detail transaksi
                foreach (ListViewItem item in listViewCart.Items)
                {
                    M_DetailTransaksi detail = new M_DetailTransaksi
                    {
                        id_transaksi = transactionId,
                        id_produk = int.Parse(item.Tag.ToString()),
                        kuantitas = int.Parse(item.SubItems[2].Text)
                    };

                    await TransactionContext.AddTransactionDetail(detail);
                }

                MessageBox.Show("Transaksi berhasil!", "Success");
                PrintReceipt(transactionId);
                ClearCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing transaction: {ex.Message}", "Error");
            }
        }

        private void ClearCart()
        {
            listViewCart.Items.Clear();
            UpdateTotal();
            textBoxCustomer.Clear();
            comboBoxPaymentMethod.SelectedIndex = -1;
        }

        private void PrintReceipt(int transactionId)
        {
            // Implementasi cetak struk
            // ...
        }
    }
}
