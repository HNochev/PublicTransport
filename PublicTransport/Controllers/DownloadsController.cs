using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.Downloads;

namespace PublicTransport.Controllers
{
    public class DownloadsController : Controller
    {
        private readonly IDownloadService downloads;
        private readonly IUserService users;

        public DownloadsController(IDownloadService downloads, IUserService users)
        {
            this.downloads = downloads;
            this.users = users;
        }

        public IActionResult All()
        {
            var downloads = this.downloads.All();

            return View(downloads);
        }

        [Authorize]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult AddPDF()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public async Task<IActionResult> AddPDFAsync(Guid id, DownloadAddFormModel download)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            byte[] fileArray = null;

            using (var memoryStream = new MemoryStream())
            {
                await download.FileUpload.FilePDF.CopyToAsync(memoryStream);

                string fileExt = Path.GetExtension(download.FileUpload.FilePDF.FileName.ToLower());

                if (fileExt == ".pdf" || fileExt == ".PDF")
                {
                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        fileArray = memoryStream.ToArray();
                    }
                    else
                    {
                        TempData[MessageConstants.ErrorMessage] = "Размерът на PDF файлът е твърде голям! Ограничението за размер е до 2MB!";
                        return Redirect(Request.Path);
                    }
                }
                else
                {
                    TempData[MessageConstants.ErrorMessage] = "Само .PDF/.pdf файлове са разрешени!";
                    return Redirect(Request.Path);
                }
            }

            var downloadId = this.downloads.CreateFile(
                download.FileName,
                download.Description,
                fileArray,
                userId
                );

            TempData[MessageConstants.SuccessMessage] = "Успешно добавихте PDF файл.";
            return Redirect($"../../Downloads/All");
        }

        public async Task<FileResult> Download(Guid id)
        {
            var file = await downloads.GetFile(id);
            return File(file.FilePDF, "application/pdf");
        }
    }
}
