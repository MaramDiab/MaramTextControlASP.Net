using MaramTX.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using TXTextControl;
using TXTextControl.DocumentServer;

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

        public IActionResult Hub()
        {
            return View();

        }
        public IActionResult Commints() { return View(); }
        public IActionResult FormViewer() { return View(); }
        public IActionResult TableOfContent() { return View(); }
        public IActionResult ExportForm() { return View(); }


        [HttpPost]
        public string ExportProtectedPDF(string document, bool isProtected)
        {
            byte[] bPDF;

            // create temporary ServerTextControl
            using (TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl())
            {
               tx.Create();

                // load the document
                tx.Load(Convert.FromBase64String(document), TXTextControl.BinaryStreamType.InternalUnicodeFormat);

                TXTextControl.SaveSettings saveSettings = new TXTextControl.SaveSettings()
                {
                    CreatorApplication = "TX Text Control Sample Application",
                };

                if (isProtected == true)
                {
                    saveSettings.DocumentAccessPermissions = DocumentAccessPermissions.None;
                    saveSettings.MasterPassword = "123";
                }

                // save the document as PDF
                tx.Save(out bPDF, TXTextControl.BinaryStreamType.AdobePDF, saveSettings);
            }

            // return as Base64 encoded string
            return Convert.ToBase64String(bPDF);
        }


        public IActionResult ErrorH() { return View(); }
        public IActionResult EXcelFarmula() { return View(); }

        public IActionResult MailMerge() { return View(); }
        [HttpPost]
        public string MergeFormula(string document)
        {
            byte[] bDocument;

            // create temporary ServerTextControl
            using (TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl())
            {
                tx.Create();

                // load the document
                tx.Load(Convert.FromBase64String(document), TXTextControl.BinaryStreamType.InternalUnicodeFormat);

                // create a MailMerge object
                using (MailMerge mailMerge = new MailMerge())
                {
                    // connect to Text Control
                    mailMerge.TextComponent = tx;

                    // load data
                    DataSet ds = new DataSet();
                    ds.ReadXml("C:/Users/user/source/repos/MaramTX/MaramTX/wwwroot/Test.xml", XmlReadMode.Auto);

                    // merge template with DataSet
                    mailMerge.Merge(ds.Tables[0]);
                }

                // save the document as InternalUnicodeFormat
                tx.Save(out bDocument, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
            }

            // return as Base64 encoded string
            return Convert.ToBase64String(bDocument);
        }

        public IActionResult  Replace()
        { 
        return View();
        
        }
        public IActionResult Spell()
        {
            return View();
        }






    }
}