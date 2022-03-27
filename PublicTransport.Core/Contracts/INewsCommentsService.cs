using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface INewsCommentsService
    {
        Guid CreateNewsComment(
            string content,
            DateTime date,
            string userId,
            Guid newsId);
    }
}
