using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Photos
{
    public class PhotoDetailsModel
    {
        public Guid Id { get; set; }

        public string? Description { get; set; }

        public DateTime DateUploaded { get; set; }

        public DateTime DateOfPicture { get; set; }

        public string? Location { get; set; }

        public bool IsAuthor { get; set; }

        public string? UserMessage { get; set; }

        public string? AdminMessage { get; set; }

        public Guid PhotoStatusId { get; set; }

        public PhotoStatus PhotoStatus { get; set; }

        public string UserId { get; set; }

        public WebsiteUser User { get; set; }

        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public bool IsApproved { get; set; }

        public string ImgUrlFromDatabase { get; set; }
    }
}
