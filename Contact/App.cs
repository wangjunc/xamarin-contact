using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Contact
{
    public class App : Application
    {
        static ContactDatabase contactDB;

        static UserDatabase userDB;

        public App()
        {
            var auth = new View.Authentication();
            var nav = new NavigationPage();
            NavigationPage.SetHasNavigationBar(auth, false);
            nav.PushAsync(auth);
            MainPage = nav;
        }

        public static ContactDatabase ContactDB
        {
            get
            {
                if (contactDB == null)
                {
                    contactDB = new ContactDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ContactSQLite.db3"));
                }

                return contactDB;
            }
        }

        public static UserDatabase UserDB
        {
            get
            {
                if (userDB == null)
                {
                    userDB = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserSQLite.db3"));
                }

                return userDB;
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
