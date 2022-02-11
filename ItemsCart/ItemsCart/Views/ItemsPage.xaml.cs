using ItemsCart.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ItemsCart.Views
{
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel _viewModel;

		public ItemsPage(ObservableCollection<Models.MenuItem> CartList)
		{
			InitializeComponent();

			BindingContext = _viewModel = new ItemsViewModel();
			_viewModel.CartsList = CartList;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.OnAppearing();
		}
	}
}