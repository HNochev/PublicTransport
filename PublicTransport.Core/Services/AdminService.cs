﻿using PublicTransport.Core.Contracts;
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

        public IEnumerable<AdminAllPendingPhotosModel> AllPendingPhotos()
        {
            return this.data.Photos
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
                .ToList();
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
    }
}