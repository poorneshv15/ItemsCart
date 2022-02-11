using ItemsCart.Models;
using ItemsCart.ViewModels;
using ItemsCart.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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