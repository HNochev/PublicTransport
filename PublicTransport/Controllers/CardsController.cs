using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.Cards;

namespace PublicTransport.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cards;
        private readonly IUserService users;

        public CardsController(ICardsService cards, IUserService users)
        {
            this.cards = cards;
            this.users = users;
        }

        public IActionResult All()
        {
            var cards = this.cards.All();

            return View(cards);
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Add(CardAddFormModel card)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var contactId = this.cards.CreateCard(
                card.Name,
                card.DaysActive,
                card.Price,
                false
                );

            TempData[MessageConstants.SuccessMessage] = "Картата беше успешно добавена.";
            return RedirectToAction("All");
        }
    }
}
