using dotnet_storee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_storee.Controllers
{
    public class KategoriController : Controller
    {

        private readonly DataContext _context;
        public KategoriController(DataContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var kategoriler = _context.Kategori.Select(i => new KategoriGetModel
            {
                Id = i.Id,
                KategoriAdi = i.KategoriAdi,
                Url = i.Url,
                UrunSayisi = i.Uruns.Count()
            }).ToList();
            return View(kategoriler);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KategoriCreateModels model)
        {
            var entity = new Kategori
            {
                KategoriAdi = model.KategoriAdi,
                Url = model.Url
            };
            _context.Kategori.Add(entity);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
            
        }

        public ActionResult Edit(int id)
        {
            var entity = _context.Kategori.Select(i=> new KategoriEditModels
            {
                Id = i.Id,
                KategoriAdi = i.KategoriAdi,
                Url = i.Url

            }).FirstOrDefault(i => i.Id == id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, KategoriEditModels model)
        { 
            if(id != model.Id)
            {
                return NotFound();
            }

            var entity = _context.Kategori.FirstOrDefault(i => i.Id == model.Id);
            if (entity != null)
            {
               entity.KategoriAdi = model.KategoriAdi;
                entity.Url = model.Url;

                _context.SaveChanges();

                TempData["Mesaj"] = $"{entity.KategoriAdi} güncellendi."; 

                return RedirectToAction("Index");
            }
            return View();

        }
    }
    
}
