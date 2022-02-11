using ItemsCart.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MenuItem = ItemsCart.Models.MenuItem;

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
				new MenuItem
				{
					Name = "Tea",
					Price = 30
				},
				new MenuItem
				{
					Name = "Coffee",
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
			if (CartsList != null && CartsList.Count > 0)
			{
				await Application.Current.MainPage.Navigation.PushAsync(new ItemsPage(CartsList));
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Alert", "Please Add Item in the Cart by clicking Add button", "OK");
			}
		}
	}
}
