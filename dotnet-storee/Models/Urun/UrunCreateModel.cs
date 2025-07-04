using System.ComponentModel.DataAnnotations;

namespace dotnet_storee.Models
{
    public class UrunCreateModel

    {
        [Display(Name = "Ürün Adı")]
        public string? UrunAdi { get; set; }
        [Display(Name = "Ürün Fiyat")]

        public double? fiyat { get; set; }
        public string? Resim { get; set; }
        public string? Aciklama { get; set; }
        public bool Aktif { get; set; }
        public bool Anasayfa { get; set; }
        public int KategoriId { get; set; }
    }
}
