using MaramTX.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using TXTextControl;

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
        public IActionResult LoadImages()
        {
            return View();
        }
        public IActionResult ChooseFile()
        {
            return View();
        }
        //get document after loaded
        public IActionResult ExportPdf()
        {
            return View();
        }
        public IActionResult LoadingFromController()
        {
            return View();
        }
        public IActionResult LoadingFromJavaScript()
        {
            return View();
        }

        public IActionResult SignPFX()
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

        [HttpPost]
        public string PDFSignSignatureFields(string document)
        {
            byte[] bDocument;

            // create temporary ServerTextControl
            using (TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl())
            {
                string uploads = Path.Combine(_environment.WebRootPath, "textcontrolself.pfx");

                string sDocument = Convert.ToBase64String(
                System.IO.File.ReadAllBytes(uploads));

             ;
                tx.Create();
                tx.Load(Convert.FromBase64String(document), BinaryStreamType.InternalUnicodeFormat);

              

                List<DigitalSignature> digitalSignatures = new List<DigitalSignature>();

                foreach (SignatureField field in tx.SignatureFields)
                {
                    field.Name = Guid.NewGuid().ToString();
                    digitalSignatures.Add(new DigitalSignature(null, field.Name));
                    field.Image = new SignatureImage(("~/UploadedFiles/A.svg"), 4);
                    field.SignerData = new SignerData("Tim Typer", "Developer", "", "", "Online Demo");
                }

                TXTextControl.SaveSettings saveSettings = new TXTextControl.SaveSettings()
                {
                    CreatorApplication = "TX Text Control Sample Application",
                    SignatureFields = digitalSignatures.ToArray()
                };

                // export to PDF
                tx.Save(out bDocument, BinaryStreamType.AdobePDF, saveSettings);
            }

            // return as Base64 encoded string
            return Convert.ToBase64String(bDocument);

        }



    }
}