using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {

        public static List<Contact> contacts = new List<Contact>()
            {

            new Contact {ContactId = 1,  Name = "John Doe", Email = "JohnDoe@gmail.com" },
            new Contact {ContactId = 2, Name = "Jane Doe", Email = "JaneDoe@gmail.com" },
            new Contact {ContactId = 3, Name = "Tom Hanks", Email = "TomHanks@gmail.com"},
            new Contact {ContactId = 4, Name = "Frank Liu", Email = "frankliu@gmail.com"},
        };

        public static List<Contact> GetContacts() => contacts;

        public static Contact GetContactById(int contactId)
        { 
            var contact = contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contact != null)
            {
                return new Contact
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address
                };
            }else
            {
                return null;
            }
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            
            if (contactId != contact.ContactId) return;

            var contactToUpdate = contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contactToUpdate != null) { 
                

                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;

            }


        }


        public static void AddContact(Contact contact)
        {
            var maxId = contacts.Max(c => c.ContactId);
            contact.ContactId = maxId + 1;
            contacts.Add(contact);
        }

        public static void DeleteContact(int contactId)
        {
            var contactToDelete = contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
            }
        }

        public static List<Contact> SearchContacts(string filterText)
        {
            var filteredContacts = contacts.Where(c =>
                !string.IsNullOrWhiteSpace(c.Name) && c.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) ||
                !string.IsNullOrWhiteSpace(c.Email) && c.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) ||
                !string.IsNullOrWhiteSpace(c.Phone) && c.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) ||
                !string.IsNullOrWhiteSpace(c.Address) && c.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return filteredContacts;
        }



    }
}
