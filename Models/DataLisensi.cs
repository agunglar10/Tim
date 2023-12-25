using System.ComponentModel.DataAnnotations.Schema;

namespace PekerjaLisensi.Models
{
    public class DataLisensi
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Nopek))]
        public String Nopek { get; set; }
        public String Lisensi { get; set; }


        public DataLisensi()
        {

        }
    }
}
