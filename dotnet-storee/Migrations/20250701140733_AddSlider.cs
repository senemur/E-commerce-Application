using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_storee.Migrations
{
    /// <inheritdoc />
    public partial class AddSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KategoriAdi = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Baslik = table.Column<string>(type: "TEXT", nullable: true),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: true),
                    Resim = table.Column<string>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UrunAdi = table.Column<string>(type: "TEXT", nullable: true),
                    fiyat = table.Column<double>(type: "REAL", nullable: true),
                    Resim = table.Column<string>(type: "TEXT", nullable: true),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: true),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false),
                    Anasayfa = table.Column<bool>(type: "INTEGER", nullable: false),
                    KategoriId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategori",
                columns: new[] { "Id", "KategoriAdi", "Url" },
                values: new object[,]
                {
                    { 1, "Telefon", "telefon" },
                    { 2, "Giyim", "giyim" },
                    { 3, "Beyaz Eşya", "beyaz-esya" },
                    { 4, "Kozmetik", "kozmetik" },
                    { 5, "Elektronik", "elektronik" },
                    { 6, "Elektronik", "elektronik" },
                    { 7, "Elektronik", "elektronik" },
                    { 8, "Elektronik", "elektronik" },
                    { 9, "Elektronik", "elektronik" },
                    { 10, "Elektronik", "elektronik" }
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "Aciklama", "Aktif", "Baslik", "Index", "Resim" },
                values: new object[,]
                {
                    { 1, "Slider 1 Açıklama", true, "Slider 1 Başlık", 0, "slider-1.jpeg" },
                    { 2, "Slider 2 Açıklama", true, "Slider 2 Başlık", 1, "slider-2.jpeg" },
                    { 3, "Slider 3 Açıklama", true, "Slider 3 Başlık", 2, "slider-3.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "Id", "Aciklama", "Aktif", "Anasayfa", "KategoriId", "Resim", "UrunAdi", "fiyat" },
                values: new object[,]
                {
                    { 1, "Senemsssssss", false, true, 1, "1.jpeg", "Apple Watch 8", 10000.0 },
                    { 2, "Senemsssssss", true, true, 1, "2.jpeg", "Apple Watch 9", 20000.0 },
                    { 3, "Senemsssssss", true, true, 2, "3.jpeg", "Apple Watch 10", 30000.0 },
                    { 4, "Senemsssssss", false, true, 2, "4.jpeg", "Apple Watch 11", 40000.0 },
                    { 5, "Senemsssssss", true, true, 2, "5.jpeg", "Apple Watch 12", 50000.0 },
                    { 6, "Senemsssssss", true, false, 3, "6.jpeg", "Apple Watch 13", 60000.0 },
                    { 7, "Senemsssssss", true, false, 3, "7.jpeg", "Apple Watch 14", 70000.0 },
                    { 8, "Senemsssssss", true, true, 4, "8.jpeg", "Apple Watch 15", 80000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
