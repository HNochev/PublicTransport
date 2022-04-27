using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Users;
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
                .First();
        }

        public UserDetailsModel UserDetails(string id)
        {
            return this.data.WebsiteUsers
                .Where(x => x.Id == id)
                .Select(x => new UserDetailsModel
                {
                    Id = id,
                    Email = x.Email,
                    Username = x.UserName,
                    Role = this.data.Roles.First(x => x.Id == this.data.UserRoles.First(x => x.UserId == id).RoleId).Name,
                    Photos = x.Photos,
                    PhotoComments = x.PhotoComments,
                    NewsComments = x.NewsComments,
                    RequestedCard = x.RequestedCard,
                    RequestedCardId = x.RequestedCardId,
                    ActiveCard = x.ActiveCard,
                    ActiveCardId = x.ActiveCardId,
                    CardIsActive = x.CardIsActive,
                    CardActiveFrom = x.CardActiveFrom,
                    CardActiveTo = x.CardActiveTo,
                    CardIsRequested = x.CardIsRequested,
                    CardRequestedOn = x.CardRequestedOn,
                    CardOwnerFirstName = x.CardOwnerFirstName,
                    CardOwnerLastName = x.CardOwnerLastName,
                })
                .First();
        }

        public int UserPendingPhotosCount(string id)
        {
            return this.data.Photos
                .Where(x => x.PhotoStatus.ClassColor == "table-warning" && x.UserId == id)
                .Count();
        }
    }
}
