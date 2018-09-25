using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authentication : ContentPage
    {
        public Authentication()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitUser();
        }

        async void OnSubmit(object sender, EventArgs e)
        {
            if (password.Text == null) return;

            var hashedPassword = GetHashedPassword(password.Text);

            var user = await App.UserDB.Get(1);

            if (user.HashedPassword == hashedPassword)
            {
                var contactList = new ContactList();
                //NavigationPage.SetHasNavigationBar(contactList, false);
                await Navigation.PopAsync();
                await Navigation.PushAsync(contactList);
            }
            else
            {
                await DisplayAlert("wrong password", "please retry", "ok");
                password.Text = "";
            }
        }

        private async void InitUser()
        {
            var user = await App.UserDB.Get(1);
            if (user == null)
            {
                user = new Schema.UserItem { };
                user.HashedPassword = GetHashedPassword("admin");
                await App.UserDB.Save(user);
            }
        }

        private string GetHashedPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] source = Encoding.Default.GetBytes(password);
            byte[] target = md5.ComputeHash(source);
            string hashedPassword = "";

            for (int i = 0; i < target.Length; i++)
            {
                hashedPassword += target[i].ToString("x");
            }

            return hashedPassword;
        }
    }
}