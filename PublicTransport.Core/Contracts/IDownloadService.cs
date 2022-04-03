using PublicTransport.Core.Models.Downloads;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface IDownloadService
    {
        public Guid CreateFile(string fileName, string? description, byte[] FilePdf, string userId);

        public List<DownloadsListingModel> All();

        public Task<Download> GetFile(Guid Id);
    }
}
