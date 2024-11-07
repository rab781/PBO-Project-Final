using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO_test.App.Models
{
    public class M_Transaksi
    {
        [Key]
        public int id_transaksi { get; set; }
        [Required]
        public DateTime tanggal_transaksi { get; set; }
        [Required]
        [ForeignKey("Kasir")]
        public int id_kasir { get; set; }
        public string customer_name { get; set; }
        [Required]
        [ForeignKey("MetodePembayaran")]
        public int id_metode_pembayaran { get; set; }
        [Required]
        public int total { get; set; }
    }
}
