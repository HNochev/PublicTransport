using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Admin;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Infrastructure.Data.Models;
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

        public AdminPendingPhotosPaginationModel AllPendingPhotos(int pageNo, int pageSize)
        {
            AdminPendingPhotosPaginationModel result = new AdminPendingPhotosPaginationModel()
            {
                PageNo = pageNo,
                PageSize = pageSize
            };

            result.TotalRecords = this.data.Photos.Where(x => x.PhotoStatus.ClassColor == "table-warning").Count();
            result.AllPendingPhotos = this.data.Photos
                .Where(x => x.PhotoStatus.ClassColor == "table-warning")
                .Select(x => new AdminAllPendingPhotosModel
                {
                    Id = x.Id,
                    UserMessage = x.UserMessage,
                    UserId = x.UserId,
                    User = x.User,
                    DateOfPicture = x.DateOfPicture,
                    DateUploaded = x.DateUploaded,
                    Location = x.Location,
                    Description = x.Description,
                    IsAuthor = x.IsAuthor,
                    ImgUrlFormDatabase = "data:image/jpg;base64," + Convert.ToBase64String(x.PhotoFile),
                })
                 .OrderBy(x => x.DateUploaded)
                 .Skip(pageNo * pageSize - pageSize)
                 .Take(pageSize)
                 .ToList();

            return result;
        }

        public AdminApproveDisapprovePhotoModel ApproveDisapproveViewData(Guid id)
        {
            return this.data.Photos
                .Where(x => x.Id == id)
                .Select(x => new AdminApproveDisapprovePhotoModel
                {
                    AdminMessage = x.AdminMessage,
                    UploadedOn = x.DateUploaded,
                    UserId = x.UserId,
                    User = x.User,
                    UserMessage = x.UserMessage,
                    ImgUrlFormDatabase = "data:image/jpg;base64," + Convert.ToBase64String(x.PhotoFile),
                })
                .First();
        }

        public bool Approve(Guid id, string? adminMessage)
        {
            var photoData = this.data.Photos.Find(id);

            if (photoData == null)
            {
                return false;
            }

            photoData.AdminMessage = adminMessage;
            photoData.IsApproved = true;
            photoData.PhotoStatusId = this.data.PhotoStatuses.First(x => x.ClassColor == "table-success").Id;
            photoData.PhotoStatus = this.data.PhotoStatuses.First(x => x.ClassColor == "table-success");

            this.data.SaveChanges();

            return true;
        }

        public bool DisApprove(Guid id, string? adminMessage)
        {
            var photoData = this.data.Photos.Find(id);

            if (photoData == null)
            {
                return false;
            }

            photoData.AdminMessage = adminMessage;
            photoData.IsApproved = false;
            photoData.PhotoStatusId = this.data.PhotoStatuses.First(x => x.ClassColor == "table-danger").Id;
            photoData.PhotoStatus = this.data.PhotoStatuses.First(x => x.ClassColor == "table-danger");

            this.data.SaveChanges();

            return true;
        }

        public AdminPendingCardsPaginationModel AllPendingCards(int pageNo, int pageSize)
        {
            AdminPendingCardsPaginationModel result = new AdminPendingCardsPaginationModel()
            {
                PageNo = pageNo,
                PageSize = pageSize
            };

            result.TotalRecords = this.data.WebsiteUsers.Where(x => x.CardIsRequested == true).Count();
            result.AllPendingCards = this.data.WebsiteUsers
                .Where(x => x.CardIsRequested == true)
                .Select(x => new AdminAllPendingCardsModel
                {
                    userId = x.Id,
                    User = x,
                    CardOwnerFirstName = x.CardOwnerFirstName,
                    CardOwnerLastName = x.CardOwnerLastName,
                    CardIsRequested = x.CardIsRequested,
                    CardRequestedOn = x.CardRequestedOn,
                    RequstedCardId = x.RequestedCardId,
                    RequstedCard = x.RequestedCard,
                })
                 .OrderBy(x => x.CardRequestedOn.Value)
                 .Skip(pageNo * pageSize - pageSize)
                 .Take(pageSize)
                 .ToList();

            return result;
        }

        public bool RejectCard(string userId)
        {
            if (userId == null)
            {
                return false;
            }

            var userData = this.data.Users.Find(userId);

            userData.RequestedCardId = null;
            userData.RequestedCard = null;
            userData.CardIsRequested = false;
            userData.CardRequestedOn = null;

            this.data.SaveChanges();

            return true;
        }

        public AdminActivateCardModel CardActivateViewData(string id)
        {
            return this.data.WebsiteUsers
                .Where(x => x.Id == id)
                .Select(x => new AdminActivateCardModel
                {
                    userId = x.Id,
                    User = x,
                    CardIsRequested = x.CardIsRequested,
                    CardRequestedOn = x.CardRequestedOn,
                    RequestedCardId = x.RequestedCardId,
                    RequestedCard = x.RequestedCard,
                    CardOwnerFirstName = x.CardOwnerFirstName,
                    CardOwnerLastName = x.CardOwnerLastName,
                })
                .First();
        }

        public bool ActivateCard(string id, DateTime cardActiveFrom, Card requestedCard)
        {
            var userData = this.data.WebsiteUsers.Find(id);

            if (userData == null || cardActiveFrom < DateTime.Now.AddDays(-1))
            {
                return false;
            }

            userData.PreviousActiveCard = userData.ActiveCard;
            userData.PreviousActiveCardId = userData.ActiveCardId;
            userData.PreviousCardActiveFrom = userData.CardActiveFrom;
            userData.PreviousCardActiveTo = userData.CardActiveTo;
            userData.CardActiveFrom = cardActiveFrom;
            userData.CardIsActive = true;
            userData.CardActiveTo = cardActiveFrom.AddDays(requestedCard.DaysActive);
            userData.ActiveCardId = requestedCard.Id;
            userData.ActiveCard = requestedCard;
            userData.RequestedCardId = null;
            userData.RequestedCard = null;
            userData.CardIsRequested = false;
            userData.CardRequestedOn = null;

            this.data.SaveChanges();

            return true;
        }
    }
}
