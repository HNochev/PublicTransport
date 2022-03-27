﻿using PublicTransport.Core.Models.NewsComments;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.News
{
    public class NewsCommentsModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        public string ImgUrl { get; set; }

        public string AuthorId { get; set; }

        public WebsiteUser Author { get; set; }

        public ICollection<CommentsListingModel> NewsComments { get; set; }
    }
}
