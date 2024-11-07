using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO_test.App.Models
{
    public class M_MetodePembayaran
    {
        [Key]
        public int id_metode_pembayaran { get; set; }
        [Required]
        public string nama_metode_pembayaran { get; set; }
    }
}
