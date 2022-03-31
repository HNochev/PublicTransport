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
    }
}
