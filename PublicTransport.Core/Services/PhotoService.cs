using Microsoft.AspNetCore.Http;
using PublicTransport.Core.Contracts;
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
    }
}
