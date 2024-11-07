using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Project_PBO_test.App.Core;
using Project_PBO_test.App.Models;

namespace Project_PBO_test.App.Context
{
    // AdminContext.cs
    internal class AdminContext : DatabaseWrapper
    {
        private static string table = "admin";

        public static bool IsFirstUser()
        {
            string query = $"SELECT COUNT(*) FROM {table}";
            DataTable result = queryExecutor(query);
            return Convert.ToInt32(result.Rows[0][0]) == 0;
        }

        public static string GeneratePasskey()
        {
            // Generate random passkey (6 karakter)
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void RegisterFirstAdmin(M_Admin admin)
        {
            string passkey = GeneratePasskey();
            string query = @"
            INSERT INTO admin (
                nama_admin, 
                username_admin, 
                password_admin, 
                passkey, 
                is_first_admin
            ) VALUES (
                @nama, 
                @username, 
                @password, 
                @passkey, 
                true
            )";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@nama", admin.nama_admin),
                new NpgsqlParameter("@username", admin.username_admin),
                new NpgsqlParameter("@password", admin.password_admin),
                new NpgsqlParameter("@passkey", passkey)
            };

            commandExecutor(query, parameters);
        }

        public static string GetPasskey()
        {
            string query = "SELECT passkey FROM admin WHERE is_first_admin = true LIMIT 1";
            DataTable result = queryExecutor(query);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["passkey"].ToString();
            }
            return null;
        }

        public static DataTable Login(string text, string s)
        {
            throw new NotImplementedException();
        }
    }
}
