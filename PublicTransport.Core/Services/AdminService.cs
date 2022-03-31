using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Admin;
using PublicTransport.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext data;

        public AdminService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int PendingPhotosCount()
        {
            return this.data.Photos.Where(x => x.PhotoStatus.ClassColor == "table-warning").Count();
        }
    }
}
