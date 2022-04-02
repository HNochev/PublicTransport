﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Core.Constants;
using PublicTransport.Core.Contracts;
using PublicTransport.Core.Extensions;
using PublicTransport.Core.Models.Contacts;

namespace PublicTransport.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService contacts;
        private readonly IUserService users;

        public ContactsController(IContactService contacts, IUserService users)
        {
            this.contacts = contacts;
            this.users = users;
        }

        public IActionResult All()
        {
            var news = this.contacts.All();

            return View(news);
        }

        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Add(ContactAddFormModel contact)
        {
            var userId = this.users.IdByUser(this.User.Id());

            if (userId == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Възникна грешка!";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var contactId = this.contacts.CreateContact(
                contact.FullName,
                contact.Email,
                contact.PhoneNumber,
                contact.Position,
                contact.UsernameInWebsite,
                userId,
                false
                );

            TempData[MessageConstants.SuccessMessage] = "Контактът беше успешно добавен.";
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

            var contactForm = this.contacts.EditViewData(id);

            return View(contactForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Edit(Guid id, ContactAddFormModel contact)
        {

            var edited = this.contacts.Edit(
                id,
                contact.FullName,
                contact.Email,
                contact.PhoneNumber,
                contact.Position,
                contact.UsernameInWebsite
                );

            if (!edited)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Контактът беше успешно редактиран.";
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

            var contactForm = this.contacts.DeleteViewData(id);

            return View(contactForm);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Administrator)]
        public IActionResult Delete(Guid id, ContactDeleteModel contact)
        {

            var deleted = this.contacts.Delete(id, true);

            if (!deleted)
            {
                return BadRequest();
            }

            TempData[MessageConstants.SuccessMessage] = "Контактът беше успешно изтрит.";
            return RedirectToAction("All");
        }
    }
}