﻿namespace dotnet_storee.Models
{
    public class UrunEditModel
    {
        public int Id { get; set; }
        public string? UrunAdi { get; set; }
        public double? fiyat { get; set; }
        public string? Resim { get; set; }
        public string? Aciklama { get; set; }
        public bool Aktif { get; set; }
        public bool Anasayfa { get; set; }
        public int KategoriId { get; set; }
        

    }
}
