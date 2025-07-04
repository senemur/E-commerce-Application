using dotnet_storee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dotnet_storee.Controllers
{
    public class HomeController : Controller
    {

        //Dependency Injection => DI

        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var urunler = _context.Urunler.Where(urun => urun.Aktif && urun.Anasayfa).ToList();
            ViewData["Kategori"] = _context.Kategori.ToList();
            return View(urunler);
        }
    }

}
