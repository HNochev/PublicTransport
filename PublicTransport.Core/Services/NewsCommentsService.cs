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
    public class NewsCommentsService : INewsCommentsService
    {
        private readonly ApplicationDbContext data;

        public NewsCommentsService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public Guid CreateNewsComment(string content, DateTime date, string userId, Guid newsId)
        {
            var newComment = new NewsComment
            {
                Content = content,
                Date = date,
                UserId = userId,
                NewsId = newsId
            };

            this.data.NewsComments.Add(newComment);
            this.data.SaveChanges();

            return newComment.Id;
        }
    }
}
