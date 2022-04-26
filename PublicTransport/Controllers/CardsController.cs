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

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Edit(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var contactForm = this.cards.EditViewData(id);

            return View(contactForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Edit(Guid id, CardEditFormModel card)
        {

            var edited = this.cards.Edit(
                id,
                card.Name
                );

            if (!edited)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] =  "Името на абонаментната карта беше успешно редактирано";
            return RedirectToAction("All");
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Delete(Guid id)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var contactForm = this.cards.DeleteViewData(id);

            return View(contactForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Delete(Guid id, CardDeleteModel card)
        {

            var deleted = this.cards.Delete(id, true);

            if (!deleted)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Картата беше успешно изтрита.";
            return RedirectToAction("All");
        }
    }
}
