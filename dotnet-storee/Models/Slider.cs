﻿namespace dotnet_storee.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string? Baslik { get; set; }
        public string? Aciklama { get; set; }
        public string Resim { get; set; } = null!;
        public int Index { get; set; }
        public bool Aktif { get; set; }

    }
}
