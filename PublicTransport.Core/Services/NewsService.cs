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
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext data;

        public NewsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public Guid CreateNews(string title, string description, DateTime date, string authorId)
        {
            var newNews = new News
            {
                 Title = title,
                 Description = description,
                 Date = date,
                 AuthorId = authorId
            };

            this.data.News.Add(newNews);
            this.data.SaveChanges();

            return newNews.Id;
        }
    }
}
