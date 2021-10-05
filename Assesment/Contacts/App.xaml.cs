using System;
using System.IO;
using Contacts.Data;
using Xamarin.Forms;

namespace Contacts
{
    public partial class App : Application
    {
        static ContactDatabase database;
        public static string ContactDatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Contact.db3");

        public static ContactDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ContactDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Contact.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ContactPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
