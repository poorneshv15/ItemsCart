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
	public class MenuItemsPageViewModel : ViewModelBase
	{
		ObservableCollection<MenuItem> _menuList;
		public ObservableCollection<MenuItem> MenuList
		{
			get { return _menuList; }
			set
			{
				if (_menuList != value)
					_menuList = value;
				OnPropertyChanged("MenuList");
			}
		}

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
		public Command<MenuItem> AddToCartCommand { get; set; }
		public Command CartCommand { get; set; }

		public MenuItemsPageViewModel()
		{
			LoadListItems();
			AddToCartCommand = new Command<MenuItem>(OnAddItemClicked);
			CartCommand = new Command(OnCartMenuClickedAsync);
		}

		private void LoadListItems()
		{
			CartsList = new ObservableCollection<MenuItem>();
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



		private void OnAddItemClicked(MenuItem cartIten)
		{
			CartsList.Add(cartIten);
		}


		private async void OnCartMenuClickedAsync(object obj)
		{
			await Shell.Current.GoToAsync(nameof(ItemsPage));
		}
	}
}
