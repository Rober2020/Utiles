using AspFiles.Models;
using AspFiles.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspFiles.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            ViewBag.message = TempData["message"];
            return View();
        }

        public async Task<ActionResult> Upload1(UploadModel upload)
        {
            using ( var db = new SampleContext())
            {
                using(var ms = new System.IO.MemoryStream())
                {
                    var file = new File();
                    await upload.MyFile.CopyToAsync(ms);
                    file.Filedb = ms.ToArray();
                    db.Files.Add(file);
                    await db.SaveChangesAsync();
                }
            }
            TempData["message"] = "Archivo arriba";
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Upload2(UploadModel upload)
        {
            var fileName = System.IO.Path.Combine(_environment.ContentRootPath, "uploads", upload.MyFile.FileName);
            await upload.MyFile.CopyToAsync(new System.IO.FileStream(fileName, System.IO.FileMode.Create));

            TempData["message"] = "Archivo arriba";
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Upload3(UploadModel upload)
        {
            var fileName = System.IO.Path.Combine(_environment.ContentRootPath, "uploads", upload.MyFile.FileName);

            using (var fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                await upload.MyFile.CopyToAsync(fs);
            }

            var minioClient = new MinioClient(server, user, pass).WithSSL();
            byte[] bs = await System.IO.File.ReadAllBytesAsync(fileName);
            var ms = new System.IO.MemoryStream(bs);

            await minioClient.PutObjectAsync(bucket, upload.MyFile.FileName, ms
                , ms.Length, "application/octet-stream", null, null);

            System.IO.File.Delete(fileName);
                TempData["message"] = "Archivo arriba";
            return RedirectToAction("Index");
        }

    }
}
