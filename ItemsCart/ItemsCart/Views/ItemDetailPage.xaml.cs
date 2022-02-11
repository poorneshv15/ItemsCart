using ItemsCart.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ItemsCart.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}