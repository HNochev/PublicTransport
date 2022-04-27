using PublicTransport.Core.Models.Cards;
using PublicTransport.Infrastructure.Data.Models;
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

        public CardEditFormModel EditViewData(Guid id);

        public bool Edit(Guid id, string name);

        public CardDeleteModel DeleteViewData(Guid id);

        public bool Delete(Guid id, bool isDeleted);

        public Card GetCard(Guid id);

        public bool Order(Guid id, string userId, string firstName, string lastName, Card card);

        public bool RejectCard(string userId);
    }
}
