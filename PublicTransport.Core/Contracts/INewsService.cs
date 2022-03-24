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
    }
}
