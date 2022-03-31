using PublicTransport.Core.Models.Photos;
using PublicTransport.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface IPhotoService
    {
        public Guid CreatePhoto(
            string? description,
            DateTime dateOfPicture,
            DateTime dateUploaded,
            string? location,
            bool isAuthor,
            string? userMessage,
            byte[] photoFile,
            Guid photoStatusId,
            string userId,
            Guid vehicleId,
            bool isApproved);

        public Guid GetPendingStatusId();

        public IEnumerable<UserMyPhotosModel> AllPhotosByUser(string id);

        public bool IsByUser(Guid photoId, string userId);


        public PhotoEditFormModel EditViewData(Guid id);

        public bool Edit(
            Guid id,
            string? Description,
            DateTime DateOfPicture,
            bool IsAuthor,
            string? Location,
            string? UserMessage);

        public PhotoDetailsModel Details(Guid id);
    }
}
