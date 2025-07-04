using dotnet_storee.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_storee.ViewComponents

{
    public class Slider : ViewComponent
    {
        private readonly DataContext _context;

        public Slider(DataContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Slider.ToList());
        }
    }

}
