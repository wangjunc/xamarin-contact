using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contact.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactList : ContentPage
    {
        public ContactList()
        {
            InitializeComponent();

            var contactItem = new Schema.ContactItem { ID = 1, Name = "asdf", Phone = "a", Note = "A" };

            listView.ItemsSource = new List<Schema.ContactItem>();

            var a = (List<Schema.ContactItem>)(listView.ItemsSource);
            a.Add(contactItem);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.DB.GetAll();
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactItem
            {
                BindingContext = new Schema.ContactItem()
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ContactItem
                {
                    BindingContext = e.SelectedItem as Schema.ContactItem
                });
            }
        }
    }
}
