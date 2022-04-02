using PublicTransport.Core.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface IContactService
    {
        public List<ContactsListingModel> All();

        public Guid CreateContact(
            string fullName,
            string email,
            string phoneNumber,
            string position,
            string? usernameInWebsite,
            string addedByUserId,
            bool isDeleted);

        public ContactAddFormModel EditViewData(Guid id);

        public bool Edit(
            Guid id,
            string fullName,
            string email,
            string phoneNumber,
            string position,
            string? usernameInWebsite);

        public ContactDeleteModel DeleteViewData(Guid id);

        public bool Delete(Guid id, bool isDeleted);
    }
}
