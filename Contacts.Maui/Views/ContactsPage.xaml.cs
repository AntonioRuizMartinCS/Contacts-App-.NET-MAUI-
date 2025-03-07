using Android.Views;
using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
        

		
	}

	override protected void OnAppearing() { 
	
		base.OnAppearing();

        searchBar.Text = string.Empty;

        LoadContacts();

       


    }




    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null) {
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
		}
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {

        var menuItem = (MenuItem)sender;
        var contact = (Contact)menuItem.CommandParameter;
        ContactRepository.DeleteContact(contact.ContactId);
        LoadContacts();

    }


    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;

    }

}