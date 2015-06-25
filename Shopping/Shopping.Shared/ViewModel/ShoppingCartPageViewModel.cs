using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Shopping.Command;
using Shopping.Model;

namespace Shopping.ViewModel
{
	public class ShoppingCartPageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private ObservableCollection<ShoppingCart> _shoppingCarts;

		public ObservableCollection<ShoppingCart> ShoppingCarts
		{
			get { return _shoppingCarts; }
			set
			{
				if (_shoppingCarts != value)
				{
					_shoppingCarts = value;
					OnPropertyChanged(() => ShoppingCarts);
				}
			}
		}

		private void OnPropertyChanged<T>(Expression<Func<T>> propertySelector)
		{
			MemberExpression memberExpression = (MemberExpression)propertySelector.Body;
			string propertyName = memberExpression.Member.Name;

			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public ShoppingCartPageViewModel()
		{
			var shoppingCarts = Repository.GetShoppingCarts();
			ShoppingCarts = new ObservableCollection<ShoppingCart>(shoppingCarts);
			BackCommand = new DelegateCommand(BackAction, BackCanExecute);
		}

		public ICommand BackCommand { get; set; }

		private bool BackCanExecute(object obj)
		{
			return true;
		}

		private void BackAction(object obj)
		{
			((Frame)Window.Current.Content).GoBack();
		}
	}
}
