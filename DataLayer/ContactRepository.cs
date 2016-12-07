using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class ContactRepository : IContactRepository
    {
        public void Delete(Contact contact)
        {
            using (var ctx  =new ContactManagementEntities())
            {
                ctx.Contacts.Remove(contact);
                ctx.SaveChanges();
            }
        }

        public List<Contact> GetAll()
        {
            using (var ctx = new ContactManagementEntities())
            {
                return ctx.Contacts.ToList();
            }
        }

        public Contact GetById(int id)
        {
            using (var ctx = new ContactManagementEntities())
            {
                return ctx.Contacts.Find(id);
            }
        }

        public void Insert(Contact contact)
        {
            using (var ctx = new ContactManagementEntities())
            {
                ctx.Contacts.Add(contact);
                ctx.SaveChanges();
            }
        }

        public void Update(Contact contact)
        {
            using (var ctx = new ContactManagementEntities())
            {
                ctx.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
