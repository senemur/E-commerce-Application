using Microsoft.AspNetCore.Mvc;

namespace dotnet_storee.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
