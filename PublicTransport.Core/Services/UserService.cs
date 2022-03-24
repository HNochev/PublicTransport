using PublicTransport.Core.Contracts;
using PublicTransport.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public string IdByUser(string userId)
        {
            return this.data.WebsiteUsers
                .Where(x => x.Id == userId)
                .Select(x => x.Id)
                .FirstOrDefault();
        }
    }
}
