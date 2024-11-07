using System.Data;
using Npgsql;
using Project_PBO_test.App.Core;
using Project_PBO_test.App.Models;

namespace Project_PBO_test.App.Context
{
    public static class TransactionContext
    {
        // Membuat transaksi baru dan mengembalikan ID transaksi yang dihasilkan
        public static int CreateTransaction(M_Transaksi transaksi)
        {
            string query = "INSERT INTO transaksi (id_kasir, tanggal_transaksi, total_transaksi) VALUES (@id_kasir, @tanggal, @total) RETURNING id_transaksi";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@id_kasir", transaksi.id_kasir),
                new NpgsqlParameter("@tanggal", transaksi.tanggal_transaksi),
                new NpgsqlParameter("@total", transaksi.total)
            };

            DataTable result = DatabaseWrapper.queryExecutor(query, parameters);
            if (result.Rows.Count > 0)
            {
                return int.Parse(result.Rows[0]["id_transaksi"].ToString());
            }
            else
            {
                throw new Exception("Failed to create transaction.");
            }
        }

        // Menambahkan detail transaksi untuk produk tertentu
        public static void AddTransactionDetail(M_DetailTransaksi detail)
        {
            string query = "INSERT INTO detail_transaksi (id_transaksi, id_produk, kuantitas, harga) VALUES (@id_transaksi, @id_produk, @kuantitas, @harga)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@id_transaksi", detail.id_transaksi),
                new NpgsqlParameter("@id_produk", detail.id_produk),
                new NpgsqlParameter("@kuantitas", detail.kuantitas),
                new NpgsqlParameter("@harga", detail.harga)
            };

            DatabaseWrapper.commandExecutor(query, parameters);
        }

        // Mendapatkan semua transaksi
        public static DataTable GetAllTransactions()
        {
            string query = "SELECT * FROM transaksi";
            return DatabaseWrapper.queryExecutor(query);
        }

        // Mendapatkan detail transaksi berdasarkan ID transaksi
        public static DataTable GetTransactionDetails(int transactionId)
        {
            string query = "SELECT * FROM detail_transaksi WHERE id_transaksi = @id_transaksi";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@id_transaksi", transactionId) };
            return DatabaseWrapper.queryExecutor(query, parameters);
        }

        // Mendapatkan transaksi berdasarkan ID kasir (opsional jika diperlukan)
        public static DataTable GetTransactionsByKasir(int kasirId)
        {
            string query = "SELECT * FROM transaksi WHERE id_kasir = @id_kasir";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@id_kasir", kasirId) };
            return DatabaseWrapper.queryExecutor(query, parameters);
        }
    }
}
