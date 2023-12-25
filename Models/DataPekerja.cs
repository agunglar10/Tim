using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PekerjaLisensi.Models
{
    
public class DataPekerja
{
    public int Id { get; set; }
    [Key]
    public String Nama { get; set; }
    public String Nopek { get; set; }
    public String Email { get; set; }
    public String Posisi { get; set; }
        public String StatusKaryawan { get; set; }

        public DataPekerja()
    {

    }


}
}


