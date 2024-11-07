using System;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_PBO_test.App.Models;
using Project_PBO_test.App.Core;

namespace Project_PBO_test.App.Context
{
    public static class ProductContext
    {
        // Mendapatkan semua produk dari database
        public static DataTable GetAllProducts()
        {
            string query = "SELECT * FROM produk";
            return DatabaseWrapper.queryExecutor(query); // Memanggil queryExecutor untuk SELECT
        }

        // Mendapatkan produk berdasarkan ID
        public static DataRow? GetById(int productId)
        {
            string query = "SELECT * FROM produk WHERE id_produk = @id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@id", productId) };
            DataTable result = DatabaseWrapper.queryExecutor(query, parameters); // Menggunakan parameterized query
            return result.Rows.Count > 0 ? result.Rows[0] : null;
        }

        // Menambahkan produk baru ke database
        public static void AddProduct(M_Produk produk)
        {
            string query = "INSERT INTO produk (nama_produk, harga_produk, kuantitas_produk) VALUES (@nama, @harga, @kuantitas)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@nama", produk.nama_produk),
                new NpgsqlParameter("@harga", produk.harga_produk),
                new NpgsqlParameter("@kuantitas", produk.kuantitas_produk)
            };
            DatabaseWrapper.commandExecutor(query, parameters); // Menggunakan commandExecutor untuk INSERT
        }

        // Memperbarui data produk
        public static void UpdateProduct(M_Produk produk)
        {
            string query = "UPDATE produk SET nama_produk = @nama, harga_produk = @harga, kuantitas_produk = @kuantitas WHERE id_produk = @id";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@nama", produk.nama_produk),
                new NpgsqlParameter("@harga", produk.harga_produk),
                new NpgsqlParameter("@kuantitas", produk.kuantitas_produk),
                new NpgsqlParameter("@id", produk.id_produk)
            };
            DatabaseWrapper.commandExecutor(query, parameters); // Menggunakan commandExecutor untuk UPDATE
        }

        // Menghapus produk dari database berdasarkan ID
        public static void DeleteProduct(int productId)
        {
            string query = "DELETE FROM produk WHERE id_produk = @id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@id", productId) };
            DatabaseWrapper.commandExecutor(query, parameters); // Menggunakan commandExecutor untuk DELETE
        }

        // Mendapatkan produk yang tersedia (stok > 0)
        public static DataTable GetAvailableProducts()
        {
            string query = "SELECT * FROM produk WHERE kuantitas_produk > 0";
            return DatabaseWrapper.queryExecutor(query); // Memanggil queryExecutor untuk produk yang tersedia
        }
    }
}
