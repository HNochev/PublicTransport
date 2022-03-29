using PublicTransport.Core.Models.News;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface INewsService
    {
        Guid CreateNews(
            string title,
            string description,
            DateTime date,
            string authorId,
            string imgUrl,
            bool isDeleted);

        Task<News> GetNewsByIdAsync(Guid id);

        public NewsCommentsModel Details(Guid id);

        public List<NewsListingModel> All();

        public bool Edit(
           Guid id,
           string title,
           string description,
           string imgUrl);

        public bool Delete(Guid id, bool isDeleted);

        public Guid GetNewsId(Guid newsId);

        public NewsAddFormModel EditViewData(Guid id);

        public NewsDeleteModel DeleteViewData(Guid id);
    }
}
