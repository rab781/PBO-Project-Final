using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO_test.App.Models
{
    // M_Produk.cs
    public class M_Produk
    {
        [Key]
        public int id_produk { get; set; }
        [Required]
        public string nama_produk { get; set; }
        [Required]
        public decimal harga_produk { get; set; }
        [Required]
        public int kuantitas_produk { get; set; }
        [Required]
        [ForeignKey("Kategori")]
        public int id_category { get; set; }
    }
}
