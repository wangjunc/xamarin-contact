using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;

namespace Contact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authentication : ContentPage
    {
        public Authentication()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            InitUser();

            weather.Text = await GetWeather();
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

        private async Task<string> GetWeather()
        {
            var client = new HttpClient();
            var uri = new Uri("https://free-api.heweather.com/s6/weather/now?location=shanghai&key=a1364d81c26e485bbdc24ac459191841");
            var response = await client.GetAsync(uri);
            string content = "";
            
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
                var w = JsonConvert.DeserializeObject<Schema.Weather>(content);
                content = w.HeWeather6[0].now.tmp;
            }
            return content;
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