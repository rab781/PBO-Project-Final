using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO_test.App.Models
{
    // M_Admin.cs
    public class M_Admin
    {
        [Key]
        public int id_admin { get; set; }
        [Required]
        public string nama_admin { get; set; }
        [Required]
        public string username_admin { get; set; }
        [Required]
        public string password_admin { get; set; }
        public string passkey { get; set; }
        public bool is_first_admin { get; set; }
    }
}
