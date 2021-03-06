﻿using System;
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

            listView.ItemsSource = new List<Schema.ContactItem>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.ContactDB.GetAll();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        async void OnItemTapped(object sender, ItemTappedEventArgs e)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (e.Item == null)
                return;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

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
                var contactItem = new ContactItem
                {
                    BindingContext = e.SelectedItem as Schema.ContactItem
                };
                //NavigationPage.SetHasNavigationBar(contactItem, false);
                await Navigation.PushAsync(contactItem);
            }
        }
    }
}
