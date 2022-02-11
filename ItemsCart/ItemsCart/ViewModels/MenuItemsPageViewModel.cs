using ItemsCart.Models;
using ItemsCart.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using MenuItem = ItemsCart.Models.MenuItem;
using System.Threading.Tasks;

namespace ItemsCart.ViewModels
{
	public class MenuItemsPageViewModel : BaseViewModel
	{

		public Command<MenuItem> AddToCartCommand { get; set; }
		public Command CartCommand { get; set; }

		ObservableCollection<MenuItem> _cartsList;
		public ObservableCollection<MenuItem> CartsList
		{
			get { return _cartsList; }
			set
			{
				if (_cartsList != value)
					_cartsList = value;
				OnPropertyChanged("CartsList");
			}
		}
		public MenuItemsPageViewModel()
		{
			LoadListItems();
			CartsList = new ObservableCollection<MenuItem>();
			AddToCartCommand = new Command<MenuItem>(OnAddItemClicked);
			CartCommand = new Command(OnCartMenuClickedAsync);
		}

		#region Stub
		private void LoadListItems()
		{
			MenuList = new ObservableCollection<MenuItem>
			{
				new MenuItem
				{
					Name = "Apple",
					Price = 80
				},
				new MenuItem
				{
					Name = "Orange",
					Price = 45
				},
				new MenuItem
				{
					Name = "Idly",
					Price = 30
				},
				new MenuItem
				{
					Name = "Grapes",
					Price = 45
				},
			};
		}
		#endregion Stub

		private void OnAddItemClicked(MenuItem cartItem)
		{
			CartsList.Add(cartItem);
		}

		private async void OnCartMenuClickedAsync(object obj)
		{	
			await Application.Current.MainPage.Navigation.PushAsync(new ItemsPage(CartsList));
		}
	}
}
