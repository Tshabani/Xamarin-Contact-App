using System;
using Contacts.Data;
using Contacts.Helpers;
using Contacts.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactEntry : ContentPage
    {
        public readonly IContactDatabase _contactDatabase;
        public Contact Contact { get; set; }
        public string Name { get; set; }
        public ContactEntry()
        {
            InitializeComponent(); 
            _contactDatabase = DependencyService.Get<IContactDatabase>();
            Contact = new Contact();
        }
        public ContactEntry(Contact contact)
        {
            InitializeComponent(); 
            _contactDatabase = DependencyService.Get<IContactDatabase>();
            Contact = contact;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //TODO: Write the method that will insert a contact into the Contacts database
            Contact.Date = DateTime.Now;
            if (!Validations.IsValidEmail(Contact.Email))
            {
                await DisplayAlert("Validation Error","The Email Entered is not Valid", "Ok");
                return;
            }
            await _contactDatabase.SaveContactAsync(Contact);
            //await DisplayAlert("Implement", "Write the method that will insert a contact into the Contacts database. Keeping separation of concerns in mind", "OK");//Remove
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            //TODO: Write the method that will delete a contact from the Contacts database
            await _contactDatabase.DeleteContactAsync(Contact);
            //await DisplayAlert("Implement", "Write the method that will delete a contact from the Contacts database. Keeping separation of concerns in mind", "OK"); //Remove
        }
    }
}