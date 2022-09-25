using MaramTX.Models;
using MaramTX.Views.Home;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace MaramTX.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //to get any files within the root 
        private IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
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

       
        //get document after loaded

          


        [HttpGet]
        public string LoadDocument()
        {
            string uploads = Path.Combine(_environment.WebRootPath, "MaramTest.docx") ;
           
            string sDocument = Convert.ToBase64String(
            System.IO.File.ReadAllBytes(uploads));

            return sDocument;
        }

       
     





    }
}