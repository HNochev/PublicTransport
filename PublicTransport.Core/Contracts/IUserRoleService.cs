using PublicTransport.Core.Models.Users;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface IUserRoleService
    {
        public Task<IEnumerable<UserListingModel>> GetUsers();

        public Task<UserEditModel> GetUserForEdit(string id);

        public Task<bool> UpdateUser(UserEditModel model);

        public Task<WebsiteUser> GetUserById(string id);
    }
}
