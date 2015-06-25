using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Model
{
    public class ShoppingCart
    {
	    public int Id { get; set; }
	    public DateTime Date { get; set; }
	    public IEnumerable<Product> Products { get; set; }

	    public decimal TotalPrice
	    {
		    get { return Products.Sum(x => x.Price); }
	    }
    }
}
