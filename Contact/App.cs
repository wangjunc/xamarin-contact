using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Contact
{
    public class App : Application
    {
        static ContactDatabase db; 

        public App()
        {
            var nav = new NavigationPage(new View.ContactList());
            MainPage = nav;
        }

        public static ContactDatabase DB
        {
            get
            {
                if (db == null)
                {
                    db = new ContactDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ContactSQLite.db3"));
                }

                return db;
            }
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
