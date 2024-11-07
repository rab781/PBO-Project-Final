using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using NpgsqlTypes;
using Project_PBO_test.App.Core;
using Project_PBO_test.App.Models;

namespace NgopiSek.App.Context
{
    internal class KasirContext : DatabaseWrapper
    {
        private static string table = "kasir";

        // Get semua data kasir
        public static DataTable All()
        {
            string query = @"
                SELECT * FROM kasir 
                ORDER BY id_kasir";
            return queryExecutor(query);
        }

        // Get kasir by ID
        public static DataTable GetById(int id)
        {
            string query = @"
                SELECT * FROM kasir 
                WHERE id_kasir = @id";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@id", NpgsqlDbType.Integer) { Value = id }
            };

            return queryExecutor(query, parameters);
        }

        // Login kasir
        public static DataTable Login(string username, string password)
        {
            string query = @"
                SELECT * FROM kasir 
                WHERE username_kasir = @username 
                AND password_kasir = @password";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@username", username),
                new NpgsqlParameter("@password", password)
            };

            return queryExecutor(query, parameters);
        }

        // Tambah kasir baru
        public static void AddKasir(M_Kasir kasir)
        {
            string query = @"
                INSERT INTO kasir (
                    nama_kasir, 
                    username_kasir, 
                    password_kasir
                ) VALUES (
                    @nama, 
                    @username, 
                    @password
                )";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@nama", kasir.nama_kasir),
                new NpgsqlParameter("@username", kasir.username_kasir),
                new NpgsqlParameter("@password", kasir.password_kasir)
            };

            commandExecutor(query, parameters);
        }

        // Update data kasir
        public static void UpdateKasir(M_Kasir kasir)
        {
            string query = @"
                UPDATE kasir 
                SET nama_kasir = @nama,
                    username_kasir = @username,
                    password_kasir = @password
                WHERE id_kasir = @id";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@nama", kasir.nama_kasir),
                new NpgsqlParameter("@username", kasir.username_kasir),
                new NpgsqlParameter("@password", kasir.password_kasir),
                new NpgsqlParameter("@id", kasir.id_kasir)
            };

            commandExecutor(query, parameters);
        }

        // Hapus kasir
        public static void DeleteKasir(int id)
        {
            // Cek apakah kasir memiliki transaksi
            string checkQuery = @"
                SELECT COUNT(*) 
                FROM transaksi 
                WHERE id_kasir = @id";

            NpgsqlParameter[] checkParameters = {
                new NpgsqlParameter("@id", id)
            };

            DataTable result = queryExecutor(checkQuery, checkParameters);
            if (Convert.ToInt32(result.Rows[0][0]) > 0)
            {
                throw new Exception("Tidak dapat menghapus kasir yang memiliki transaksi!");
            }

            // Jika tidak ada transaksi, hapus kasir
            string query = "DELETE FROM kasir WHERE id_kasir = @id";
            commandExecutor(query, checkParameters);
        }

        // Cek username tersedia
        public static bool IsUsernameAvailable(string username, int? currentId = null)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM kasir 
                WHERE username_kasir = @username";

            if (currentId.HasValue)
            {
                query += " AND id_kasir != @id";
            }

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@username", username)
            };

            if (currentId.HasValue)
            {
                parameters.Add(new NpgsqlParameter("@id", currentId.Value));
            }

            DataTable result = queryExecutor(query, parameters.ToArray());
            return Convert.ToInt32(result.Rows[0][0]) == 0;
        }

        // Validasi login dengan passkey
        public static bool ValidatePasskey(string passkey)
        {
            string query = @"
                SELECT passkey 
                FROM admin 
                WHERE is_first_admin = true 
                AND passkey = @passkey";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@passkey", passkey)
            };

            DataTable result = queryExecutor(query, parameters);
            return result.Rows.Count > 0;
        }

        // Get jumlah kasir
        public static int GetKasirCount()
        {
            string query = "SELECT COUNT(*) FROM kasir";
            DataTable result = queryExecutor(query);
            return Convert.ToInt32(result.Rows[0][0]);
        }

        // Cari kasir berdasarkan nama atau username
        public static DataTable SearchKasir(string keyword)
        {
            string query = @"
                SELECT * 
                FROM kasir 
                WHERE 
                    LOWER(nama_kasir) LIKE LOWER(@keyword) OR 
                    LOWER(username_kasir) LIKE LOWER(@keyword)
                ORDER BY id_kasir";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@keyword", $"%{keyword}%")
            };

            return queryExecutor(query, parameters);
        }

        // Get kasir dengan transaksi
        public static DataTable GetKasirWithTransactionCount()
        {
            string query = @"
                SELECT 
                    k.*, 
                    COUNT(t.id_transaksi) as total_transaksi
                FROM kasir k
                LEFT JOIN transaksi t ON k.id_kasir = t.id_kasir
                GROUP BY k.id_kasir
                ORDER BY k.id_kasir";

            return queryExecutor(query);
        }

        // Update password kasir
        public static void UpdatePassword(int id, string newPassword)
        {
            string query = @"
                UPDATE kasir 
                SET password_kasir = @password 
                WHERE id_kasir = @id";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@password", newPassword),
                new NpgsqlParameter("@id", id)
            };

            commandExecutor(query, parameters);
        }

        // Cek apakah kasir memiliki transaksi
        public static bool HasTransactions(int id)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM transaksi 
                WHERE id_kasir = @id";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@id", id)
            };

            DataTable result = queryExecutor(query, parameters);
            return Convert.ToInt32(result.Rows[0][0]) > 0;
        }
    }
}