using System.ComponentModel.DataAnnotations;

namespace PekerjaLisensi.Models
{
    public class Lisensi
    {
        [Key]
        public int Id { get; set; }
        public String NamaLisensi { get; set; }
        public String JenisLisensi { get; set; }
       
    }
}
