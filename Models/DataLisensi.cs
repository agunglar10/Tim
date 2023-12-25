using System.ComponentModel.DataAnnotations.Schema;

namespace PekerjaLisensi.Models
{
    public class DataLisensi
    {
        public int Id { get; set; }
        public String Nopek { get; set; }
        public int Lisensi { get; set; }

        //Relational Data
        public DataPekerja DataPekerja { get; set; }
        public Lisensi LisensiAja { get; set; }
        public DataLisensi()
        {

        }
    }
}
