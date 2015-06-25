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
    public class ProductsListPageViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

	    private ObservableCollection<Product> _products;

	    public ObservableCollection<Product> Products
	    {
			get { return _products; }
		    set
		    {
			    if (_products != value)
			    {
				    _products = value;
				    OnPropertyChanged( () => Products );
			    }
		    }
	    }

		// funkcja pobiera nazwę propercji, nie trzeba jej podawać w stringu. Ma to na celu uniknięcie literówek w propertyName
		// następnie wywołuje event PropertyChanged
		private void OnPropertyChanged<T>(Expression<Func<T>> propertySelector)
		{
			MemberExpression memberExpression = (MemberExpression)propertySelector.Body;
			string propertyName = memberExpression.Member.Name;

			if(PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

	    public ProductsListPageViewModel()
	    {
		    var products = Repository.GetProducts();
			Products = new ObservableCollection<Product>(products);
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
