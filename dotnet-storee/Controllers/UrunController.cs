﻿using dotnet_storee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dotnet_storee.Controllers;

public class UrunController : Controller
{

    //Dependency Injection => DI

    private readonly DataContext _context;
    public UrunController(DataContext context)
    {
        _context = context;
    }


    public ActionResult Index()
    {
        //var urunler = _context.Urunler.Include(i => i.Kategori).ToList();

        var urunler = _context.Urunler.Select(i => new UrunGetModel
        {
            Id = i.Id,
            UrunAdi = i.UrunAdi,
            fiyat = i.fiyat,
            Resim = i.Resim,
            Aktif = i.Aktif,
            Anasayfa = i.Anasayfa,
            KategoriAdi = i.Kategori.KategoriAdi

        }).ToList();
        return View(urunler);
    }
    public ActionResult List(string url, string q)
    {

        var query = _context.Urunler.Where(i => i.Aktif);

        if (!string.IsNullOrEmpty(url))
        {
            query = query.Where(i => i.Kategori.Url == url);
        }

        if (!string.IsNullOrEmpty(q))
        {
            query = query.Where(i => i.UrunAdi.ToLower().Contains(q.ToLower()));

            ViewData["q"] = q;
        }

        //var urunler = _context.Urunler.Where(i => i.Kategori.Url==url && i.Aktif).ToList();
        return View(query.ToList());
    }
    public ActionResult Details(int id)
    {
        var urun = _context.Urunler.FirstOrDefault(i => i.Id == id);
        //var urun = _context.Urunler.Find(id);

        if (urun == null)
        {
            return RedirectToAction("Index", "Home");
        }


        ViewData["Benzerurunler"] = _context.Urunler
            .Where(i => i.Aktif && i.KategoriId == urun.KategoriId && i.Id != id).Take(4).ToList();
        return View(urun);
    }

    public ActionResult Create()
    {
        //ViewBag.Kategoriler= _context.Kategori.ToList();
        ViewBag.Kategoriler = new SelectList(_context.Kategori.ToList(), "Id", "KategoriAdi");
        return View();
    }


    [HttpPost]
    public ActionResult Create(UrunCreateModel model)
    {
        var entity = new Urun()
        {
            UrunAdi = model.UrunAdi,
            Aciklama = model.Aciklama,
            fiyat = model.fiyat,
            Aktif = model.Aktif,
            Anasayfa = model.Anasayfa,
            KategoriId = model.KategoriId, //Örnek olarak kategori ID'si 1 olarak ayarlandı
            Resim = "1.jpeg"
        };
        _context.Urunler.Add(entity);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        var entity = _context.Urunler.Select(i => new UrunEditModel
        {
             Id = i.Id,
              Aciklama=i.Aciklama,
               Aktif=i.Aktif,
                Anasayfa=i.Anasayfa,
                 KategoriId = i.KategoriId,
                  fiyat = i.fiyat,
                   Resim =i.Resim,
                   UrunAdi = i.UrunAdi
             

        }).FirstOrDefault(i => i.Id == id);
        ViewBag.Kategoriler = new SelectList(_context.Kategori.ToList(), "Id", "KategoriAdi");
        return View(entity);
    }


    [HttpPost]
    public ActionResult Edit(int id ,UrunEditModel model)
    {
        if (id != model.Id)
        {
            return RedirectToAction("Index");
        }

        var entity= _context.Urunler.FirstOrDefault(i => i.Id == model.Id);

        if(entity != null)
        {
            entity.UrunAdi= model.UrunAdi;
            entity.Aciklama = model.Aciklama;
            entity.Aktif = model.Aktif;
            entity.fiyat = model.fiyat;
            //entity.Resim = model.Resim;
            entity.Anasayfa = model.Anasayfa;
            entity.KategoriId = model.KategoriId;

            _context.SaveChanges();

            TempData["Mesaj"] = $"{entity.UrunAdi} adlı ürün başarıyla güncellendi.";

            return RedirectToAction("Index");

        }
        return View(model);
    }




}




