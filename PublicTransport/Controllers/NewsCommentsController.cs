using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.NewsComments;

namespace PublicTransport.Controllers
{
    public class NewsCommentsController : Controller
    {
        private readonly INewsCommentsService comments;
        private readonly INewsService news;
        private readonly IUserService users;

        public NewsCommentsController(INewsCommentsService comments, INewsService news, IUserService users)
        {
            this.comments = comments;
            this.news = news;
            this.users = users;
        }
    }
}
