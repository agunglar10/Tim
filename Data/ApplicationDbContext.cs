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
        public DbSet<DataLisensi> data_lisensi { get; set; }
        public DbSet<DataPekerja> data_pekerja { get; set; }
        public DbSet<Lisensi> lisensi { get; set; }

        //KEY
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mengabaikan EF Key Harus Integer
            base.OnModelCreating(modelBuilder);

            //DataLisensi
            modelBuilder.Entity<DataLisensi>().HasKey(dl => new { dl.Id });

            //DataPekerja
            modelBuilder.Entity<DataPekerja>().HasKey(dp => new { dp.Nopek });

            //Lisensi
            modelBuilder.Entity<Lisensi>().HasKey(l => new { l.Id });

            //One To One Relation To Nopek DataPekerja
            modelBuilder.Entity<DataLisensi>()
                        .HasOne(dp => dp.DataPekerja)
                        .WithMany(dl => dl.DataLisensis)
                        .HasForeignKey(dl => dl.Nopek);
            //One To Many Relation To Id Lisensi
            modelBuilder.Entity<DataLisensi>()
                        .HasOne<Lisensi>(l => l.LisensiAja)
                        .WithMany(dl => dl.DataLisensis)
                        .HasForeignKey(dl => dl.Lisensi);
        }
    }
}
