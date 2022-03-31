﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Photos;
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
                    IsApproved = x.IsApproved,
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

        public bool IsByUser(Guid photoId, string userId)
            => this.data
                .Photos
                .Any(c => c.Id == photoId && c.UserId == userId);


        public PhotoEditFormModel EditViewData(Guid id)
        {
            return this.data.Photos
                    .Where(x => x.Id == id)
                    .Select(x => new PhotoEditFormModel
                    {
                        DateOfPicture = x.DateOfPicture,
                        Description = x.Description,
                        IsAuthor = x.IsAuthor,
                        Location = x.Location,
                        UserMessage = x.UserMessage,
                        Id = id,
                        IsApproved = x.IsApproved,
                        ImgUrlFormDatabase = "data:image/jpg;base64," + Convert.ToBase64String(x.PhotoFile),
                    })
                    .First();
        }

        public bool Edit(Guid id, string? Description, DateTime DateOfPicture, bool IsAuthor, string? Location, string? UserMessage)
        {
            var photoData = this.data.Photos.Find(id);

            if (photoData == null)
            {
                return false;
            }

            if (photoData.IsApproved == true)
            {
                return false;
            }

            photoData.DateOfPicture = DateOfPicture;
            photoData.Location = Location;
            photoData.UserMessage = UserMessage;
            photoData.Description = Description;
            photoData.IsAuthor = IsAuthor;

            this.data.SaveChanges();

            return true;
        }

        public PhotoDetailsModel Details(Guid id)
        {
            return this.data.Photos
                .Where(x => x.Id == id)
                .Include(x => x.Vehicle.VehicleCondition)
                .Select(x => new PhotoDetailsModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    DateOfPicture = x.DateOfPicture,
                    DateUploaded = x.DateUploaded,
                    IsApproved = x.IsApproved,
                    IsAuthor = x.IsAuthor,
                    Location = x.Location,
                    ImgUrlFromDatabase = "data:image/jpg;base64," + Convert.ToBase64String(x.PhotoFile),
                    PhotoStatus = x.PhotoStatus,
                    PhotoStatusId = x.PhotoStatusId,
                    User = x.User,
                    UserId = x.UserId,
                    Vehicle = x.Vehicle,
                    VehicleId = x.VehicleId,
                })
                .First();
        }
    }
}
