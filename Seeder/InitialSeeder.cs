using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using PekerjaLisensi.Data;
using PekerjaLisensi.Models;

public static class DataSeeder
{
    public static void SeedData(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            // Cek apakah data sudah ada di database
            if (context.data_pekerja.Any())
            {
                return; // Seeder sudah dijalankan sebelumnya
            }

            // Tambahkan data awal
            context.data_pekerja.AddRange(
                new DataPekerja { Nama = "John Doe", Nopek = "23424234", Email = "john.doe@example.com", Posisi = "Developer", StatusKaryawan = "Aktif" },
                new DataPekerja { Nama = "Jane Doe", Nopek = "24242", Email = "jane.doe@example.com", Posisi = "Designer", StatusKaryawan = "Aktif" }
            );

            context.SaveChanges();
        }
    }
}
