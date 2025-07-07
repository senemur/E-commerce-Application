using System.ComponentModel.DataAnnotations;

namespace dotnet_storee.Models
{
    public class KategoriEditModels
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı")]
        public string KategoriAdi { get; set; } = null;
        [Display(Name = "URL")]
        public string Url { get; set; } = null;
    }
}
