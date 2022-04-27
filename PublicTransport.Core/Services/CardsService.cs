using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Cards;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext data;

        public CardsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public List<CardsListingModel> All()
        {
            return this.data
                 .Cards
                 .Where(x => !x.IsDeleted)
                 .Select(x => new CardsListingModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     DaysActive = x.DaysActive,
                     Price = x.Price,
                 })
                 .ToList();
        }

        public Guid CreateCard(string name, int daysActive, decimal price, bool isDeleted)
        {
            var newCard = new Card
            {
                Name = name,
                DaysActive = daysActive,
                IsDeleted = isDeleted,
                Price = price,
            };

            this.data.Cards.Add(newCard);
            this.data.SaveChanges();

            return newCard.Id;
        }

        public CardEditFormModel EditViewData(Guid id)
        {
            return this.data.Cards
                .Where(x => x.Id == id)
                .Select(x => new CardEditFormModel
                {
                    Name = x.Name,
                })
                .First();
        }

        public bool Edit(Guid id, string name)
        {
            var cardData = this.data.Cards.Find(id);

            if (cardData == null)
            {
                return false;
            }

            cardData.Name = name;

            this.data.SaveChanges();

            return true;
        }

        public CardDeleteModel DeleteViewData(Guid id)
        {
            return this.data.Cards
                .Where(x => x.Id == id)
                .Select(x => new CardDeleteModel
                {
                    Name = x.Name,
                    DaysActive = x.DaysActive,
                    Price = x.Price,
                })
                .First();
        }

        public bool Delete(Guid id, bool isDeleted)
        {
            var cardData = this.data.Cards.Find(id);

            if (cardData == null)
            {
                return false;
            }

            cardData.IsDeleted = isDeleted;

            this.data.SaveChanges();

            return true;
        }

        public Card GetCard(Guid id)
        {
            return this.data.Cards
                .Where(x => x.Id == id)
                .First();
        }

        public bool Order(Guid id, string userId, string firstName, string lastName, Card card)
        {
            var userData = this.data.Users.Find(userId);

            if (userData == null || userData.CardIsRequested == true)
            {
                return false;
            }

            userData.RequestedCardId = id;
            userData.RequestedCard = card;
            userData.CardOwnerFirstName = firstName;
            userData.CardOwnerLastName = lastName;
            userData.CardIsRequested = true;
            userData.CardRequestedOn = DateTime.Now;

            this.data.SaveChanges();

            return true;
        }

        public bool RejectCard(string userId)
        {
            if (userId == null)
            {
                return false;
            }

            var userData = this.data.Users.Find(userId);

            userData.RequestedCardId = null;
            userData.RequestedCard = null;
            userData.CardOwnerFirstName = null;
            userData.CardOwnerLastName = null;
            userData.CardIsRequested = false;
            userData.CardRequestedOn = null;

            this.data.SaveChanges();

            return true;
        }
    }
}
