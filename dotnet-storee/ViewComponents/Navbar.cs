using dotnet_storee.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_storee.ViewComponents
 
{
    public class Navbar : ViewComponent
    {
        private readonly DataContext _context;

        public Navbar(DataContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Kategori.ToList());
        }
    }

}
