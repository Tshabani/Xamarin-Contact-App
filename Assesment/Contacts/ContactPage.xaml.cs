using System;
using Contacts.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetContactsAsync();
            //Change this to bind the list from a ViewModel
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactEntry
            {
                BindingContext = new Contact()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                //await Navigation.PushAsync(new ContactEntry
                //{
                //    BindingContext = e.SelectedItem as Contact
                //});

                await Navigation.PushAsync(new ContactEntry(e.SelectedItem as Contact));

            }
        }
    }
}