namespace PekerjaLisensi.Models
{
    public class SummaryModel
    {
        public int Id { get; set; }
        public String Lisensi { get; set; }
        public String JumlahLisensi { get; set; }
        public String LisensiTerpakai { get; set; }
        public String LisensiTerpakaiNonKPI { get; set; }



        public SummaryModel()
        {

        }
    }
}
