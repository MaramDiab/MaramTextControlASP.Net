using MaramTX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

namespace MaramTX.Controllers
{
    //Download From server
    public class DownloadController : Controller
    {
        private readonly IFileProvider fileProvider;
      
        public DownloadController(IFileProvider provider)
        {
            fileProvider = provider;
        }

        public IActionResult Index()
        {
            var fileModels = new FilesModels();
            foreach (var item in fileProvider.GetDirectoryContents(""))
            {
                fileModels.files.Add(new FileModel()
                {
                    FileName = item.Name,
                    FilePath = item.PhysicalPath
                });
            }
            return View(fileModels.files);
        }


        public async Task<IActionResult> DownloadFile(string fileName)
        {
      
            if (string.IsNullOrEmpty(fileName) || fileName == null)
            {
                return Content("File Name is Empty...");
            }
            Console.WriteLine("Hello");
            // get the filePath

            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "ServerFiles", fileName);
            Console.WriteLine(" get the filePath");
            // create a memorystream
            var memoryStream = new MemoryStream();

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                Console.WriteLine(" create a memorystream");

                await stream.CopyToAsync(memoryStream);
            }
            // set the position to return the file from
            memoryStream.Position = 0;
            Console.WriteLine("set the position to return the file from");
            // Get the MIMEType for the File
           
            var mimeType = (string file) =>
            {
                var mimeTypes = MimeTypes.GetMimeTypes();
                var extension = Path.GetExtension(file).ToLowerInvariant();
                return mimeTypes[extension];
               
            };

            return File(memoryStream, mimeType(filePath), Path.GetFileName(filePath));
        }
    }
}
