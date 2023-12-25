using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PekerjaLisensi.Models;

namespace PekerjaLisensi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PekerjaLisensi.Models.DataPekerja> DataPekerja { get; set; } = default!;


        //dibawah contoh aja. kalo gk ada hubungannya hapus
        public DbSet<PekerjaLisensi.Models.DataLisensi> DataLisensi { get; set; } = default!;
        public DbSet<PekerjaLisensi.Models.Lisensi> Lisensitable { get; set; } = default!;
        public DbSet<PekerjaLisensi.Models.Summary> Tabelsummary { get; set; } = default!;
    }
}
