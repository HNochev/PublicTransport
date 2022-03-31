using Microsoft.AspNetCore.Http;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Users;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly ApplicationDbContext data;

        public PhotoService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public Guid CreatePhoto(string? description, DateTime dateOfPicture, DateTime dateUploaded, string? location, bool isAuthor, string? userMessage, byte[] photoFile, Guid photoStatusId, string userId, Guid vehicleId, bool isApproved)
        {
            var newPhoto = new Photo
            {
                Description = description,
                DateOfPicture = dateOfPicture,
                DateUploaded = dateUploaded,
                Location = location,
                PhotoFile = photoFile,
                PhotoStatusId = photoStatusId,
                UserId = userId,
                VehicleId = vehicleId,
                IsApproved = isApproved,
                IsAuthor = isAuthor,
                UserMessage = userMessage,
            };

            this.data.Photos.Add(newPhoto);
            this.data.SaveChanges();

            return newPhoto.Id;
        }

        public Guid GetPendingStatusId()
        {
            return this.data.PhotoStatuses
                .Where(x => x.ClassColor == "table-warning")
                .Select(x => x.Id)
                .First();
        }

        public IEnumerable<UserMyPhotosModel> AllPhotosByUser(string id)
        {
            return this.data.Photos
                .Where(x => x.UserId == id)
                .Select(x => new UserMyPhotosModel
                {
                    Id = x.Id,
                    AdminMessage = x.AdminMessage,
                    UserMessage = x.UserMessage,
                    UserId = id,
                    User = x.User,
                    DateOfPicture = x.DateOfPicture,
                    DateUploaded = x.DateUploaded,
                    Location = x.Location,
                    PhotoStatusId = x.PhotoStatusId,
                    PhotoStatus = x.PhotoStatus,
                    ImgUrlFormDatabase = "data:image/jpg;base64," + Convert.ToBase64String(x.PhotoFile),
                })
                .OrderByDescending(x => x.DateUploaded)
                .ToList();
        }
    }
}
