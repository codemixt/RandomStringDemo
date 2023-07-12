using Microsoft.AspNetCore.Mvc;
using RamdomStringDemo1.Models;
using RamdomStringDemo1.Models.ViewModels;
using RandomStringLibrary;
using System.Diagnostics;

namespace RamdomStringDemo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string Url)
        {
            if(!string.IsNullOrEmpty(Url))
            {
                string ShortLink = "www.srtlnk.com/"+ RandomString.GetString(7);

                var model = new ShortLinkViewModel()
                {
                    Url = Url,
                    ShortLink = ShortLink,
                };

                return View(model);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}