using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO_test.App.Models
{
    // M_DetailTransaksi.cs
    public class M_DetailTransaksi
    {
        [Key]
        public int id_detail_transaksi { get; set; }
        [Required]
        [ForeignKey("Transaksi")]
        public int id_transaksi { get; set; }
        [Required]
        [ForeignKey("Produk")]
        public int id_produk { get; set; }
        [Required]
        public int kuantitas { get; set; }
        [Required]
        public int harga { get; set; }
    }
}
