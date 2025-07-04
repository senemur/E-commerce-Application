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
    }
}
