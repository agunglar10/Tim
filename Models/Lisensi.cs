using System.ComponentModel.DataAnnotations;

namespace PekerjaLisensi.Models
{
    public class Lisensi
    {
        public int Id { get; set; }
        public String NamaLisensi { get; set; }
        public String JenisLisensi { get; set; }

        //Relational Data
        public ICollection<DataLisensi> DataLisensis { get; set; }

    }
}
