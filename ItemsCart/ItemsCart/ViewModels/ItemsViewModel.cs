using System.Collections.ObjectModel;

namespace ItemsCart.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		ObservableCollection<Models.MenuItem> _cartsList;
		public ObservableCollection<Models.MenuItem> CartsList
		{
			get { return _cartsList; }
			set
			{
				if (_cartsList != value)
					_cartsList = value;
				OnPropertyChanged("CartsList");
			}
		}

		private string totalCartValue;
		public string TotalCartValue
		{
			get => totalCartValue;
			set => SetProperty(ref totalCartValue, value);
		}

		public ItemsViewModel()
		{
			Title = "Cart";
			CartsList = new ObservableCollection<Models.MenuItem>();
		}



		public void OnAppearing()
		{
			var sumOfCost = 0.0;
			if (CartsList != null && CartsList.Count > 0)
			{
				foreach (var item in CartsList)
				{
					sumOfCost += item.Price;
				}
			}
			TotalCartValue = sumOfCost.ToString();
		}
	}
}