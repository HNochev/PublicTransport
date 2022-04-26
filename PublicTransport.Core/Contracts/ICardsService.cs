using PublicTransport.Core.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface ICardsService
    {
        public List<CardsListingModel> All();

        public Guid CreateCard(string name, int daysActive, decimal price, bool isDeleted);
    }
}
