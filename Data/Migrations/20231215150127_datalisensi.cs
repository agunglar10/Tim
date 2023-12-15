using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PekerjaLisensi.Data.Migrations
{
    /// <inheritdoc />
    public partial class datalisensi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataLisensi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nopek = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    Lisensi = table.Column<string>(type: "nvarchar(max)", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLisensi", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
