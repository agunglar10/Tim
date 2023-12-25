using System.ComponentModel.DataAnnotations;

namespace PekerjaLisensi.Models
{
    public class Summary
    {
        [Key]
        public int Id { get; set; }
        public String Lisensi { get; set; }
        public String JumlahLisensi { get; set; }
        public String LisensiTerpakai { get; set; }
        public String LisensiTerpakaiNonKPI { get; set; }

    }
}
