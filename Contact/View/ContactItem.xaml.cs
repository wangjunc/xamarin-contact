using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contact.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactItem : ContentPage
	{
		public ContactItem ()
		{
			InitializeComponent ();
		}

        async void OnSave(object sender, EventArgs e)
        {
            await App.ContactDB.Save(BindingContext as Schema.ContactItem);
            await Navigation.PopAsync();
        }

        async void OnDelete(object sender, EventArgs e)
        {
            await App.ContactDB.Delete(BindingContext as Schema.ContactItem);
            await Navigation.PopAsync();
        }
	}
}