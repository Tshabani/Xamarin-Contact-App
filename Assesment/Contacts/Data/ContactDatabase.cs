using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Contacts.Models;
using Contacts.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContactDatabase))]
namespace Contacts.Data
{
    public class ContactDatabase : IContactDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ContactDatabase()
        {
            _database = new SQLiteAsyncConnection(App.ContactDatabasePath);
            _database.CreateTableAsync<Contact>().Wait();
        }
        public ContactDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contact>().Wait();
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            return _database.Table<Contact>().ToListAsync();
        }

        public Task<Contact> GetContactAsync(int id)
        {
            return _database.Table<Contact>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveContactAsync(Contact Contact)
        {
            if (Contact.ID != 0)
            {
                return _database.UpdateAsync(Contact);
            }
            else
            {
                return _database.InsertAsync(Contact);
            }
        }

        public Task<int> DeleteContactAsync(Contact Contact)
        {
            return _database.DeleteAsync(Contact);
        }
       
    }
}
