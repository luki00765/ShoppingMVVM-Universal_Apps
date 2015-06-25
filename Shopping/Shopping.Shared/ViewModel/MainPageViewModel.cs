using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Shopping.Command;
using Shopping.View;

namespace Shopping.ViewModel
{
    public class MainPageViewModel
    {
	    public string ContentProducts { get; private set; }
		public ICommand ProductsCommand { get; set; }

	    public string ContentShoppingCarts { get; private set; }
		public ICommand ShoppingCommand { get; set; }

	    public MainPageViewModel()
	    {
		    ContentProducts = "Products";
			ProductsCommand = new DelegateCommand(ProductsAction, ProductsCanExecute);

		    ContentShoppingCarts = "Shopping Carts";
			ShoppingCommand = new DelegateCommand(ShoppingCartsAction, ShoppingCartsCanExecute);
	    }

		private bool ShoppingCartsCanExecute(object obj)
		{
			return true;
		}

		private void ShoppingCartsAction(object obj)
		{
			((Frame)Window.Current.Content).Navigate(typeof(ShoppingCartPage));
		}

		private bool ProductsCanExecute(object obj)
		{
			return true;
		}

		private void ProductsAction(object obj)
		{
			((Frame) Window.Current.Content).Navigate(typeof (ProductsListPage));
		}
    }
}
