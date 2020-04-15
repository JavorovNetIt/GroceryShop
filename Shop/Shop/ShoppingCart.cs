using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class ShoppingCart
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public string SumOfAllProductsText
        {   get => string.Format("{0:C}", Products.Sum(p=>p.Sum)); }

        public decimal SumOfAllProducts { get => Products.Sum(p => p.Sum); }

    }
}
