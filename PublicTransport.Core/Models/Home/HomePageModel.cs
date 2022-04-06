using PublicTransport.Core.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Models.Home
{
    public class HomePageModel
    {
        public IEnumerable<NewsListingModel> News { get; set; }
    }
}
