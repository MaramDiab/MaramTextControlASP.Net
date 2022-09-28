using MaramTX.Models;
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

        public ActionResult UploadFile()
        {
            return View();
        }
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoadingFromView()
        {
            return View();
        }
        public IActionResult DocumentViewer()
        {
            return View();
        }
        public IActionResult CharacterFormatting()
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

        public IActionResult ChooseFile()
        {
            return View();
        }
        //get document after loaded

        public IActionResult LoadingFromController()
        {
            return View();
        }
        public IActionResult LoadingFromJavaScript()
        {
            return View();
        }


        [HttpGet]
        public string LoadDocument(string filename)
        {
            
            string uploads = Path.Combine(_environment.WebRootPath, filename) ;
           
            string sDocument = Convert.ToBase64String(
            System.IO.File.ReadAllBytes(uploads));

            return sDocument;
        }

     
        [HttpGet]
        public IActionResult Export() {
            return View();
        }
       
     



    }
}