﻿namespace dotnet_storee.Models
{
    public class UrunGetModel
    {
        public int Id { get; set; }
        public string? UrunAdi { get; set; }
        public double? fiyat { get; set; }
        public string? Resim { get; set; }
        public bool Aktif { get; set; }
        public bool Anasayfa { get; set; }
        public string KategoriAdi { get; set; } = null!;
    }
}
