using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PekerjaLisensi.Data.Migrations
{
    /// <inheritdoc />
    public partial class lisensitable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                           name: "Lisensitable",
                           columns: table => new
                           {
                               Id = table.Column<int>(type: "int", nullable: false)
                                   .Annotation("SqlServer:Identity", "1, 1"),
                               NamaLisensi = table.Column<string>(type: "nvarchar(max)", nullable: false),

                               JenisLisensi = table.Column<string>(type: "nvarchar(max)", nullable: false),

                           },
                           constraints: table =>
                           {
                               table.PrimaryKey("Lisensi", x => x.Id);
                           });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
