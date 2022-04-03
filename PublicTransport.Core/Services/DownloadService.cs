using Microsoft.EntityFrameworkCore;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Downloads;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Services
{
    public class DownloadService : IDownloadService
    {
        private readonly ApplicationDbContext data;

        public DownloadService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public Guid CreateFile(string fileName, string? description, byte[] FilePdf, string userId)
        {
            var newDownload = new Download
            {
                FileName = fileName,
                Description = description,
                FilePDF = FilePdf,
                UserId = userId,
            };

            this.data.Downloads.Add(newDownload);
            this.data.SaveChanges();

            return newDownload.Id;
        }

        public List<DownloadsListingModel> All()
        {
            return this.data
                 .Downloads
                 .Select(x => new DownloadsListingModel
                 {
                     Id = x.Id,
                     FileName = x.FileName,
                     Description = x.Description,
                     UserId = x.UserId,
                     User = x.User,
                     DownloadUrlFromDatabase = "data:application/pdf;base64," + Convert.ToBase64String(x.FilePDF),
                 })
                 .ToList();
        }

        public async Task<Download> GetFile(Guid Id)
        {
            return await this.data.Downloads
                          .Where(x => x.Id == Id)
                          .Select(x => x)
                          .FirstAsync();
        }
    }
}
