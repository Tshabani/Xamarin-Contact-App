using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data
{
    public interface IContactDatabase 
    {
        Task<List<Contact>> GetContactsAsync();

        Task<Contact> GetContactAsync(int id);

        Task<int> SaveContactAsync(Contact Contact);

        Task<int> DeleteContactAsync(Contact Contact);
    }
}
