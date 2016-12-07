using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Model;

namespace BusinessLayer
{
    public static class ContactService
    {
        static IContactRepository _contactRepository;

        static ContactService()
        {
            _contactRepository = new ContactRepository();
        }

        public static List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public static void Insert(Contact contact)
        {
            _contactRepository.Insert(contact);
        }

        public static void Update(Contact contact)
        {
            _contactRepository.Update(contact);
        }

        public static void Delete(Contact contact)
        {
            _contactRepository.Delete(contact);
        }

    }
}
