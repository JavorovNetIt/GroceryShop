using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Qty { get; set; }

        public decimal Sum 
        {
            get => Price * (decimal)Qty;
        }


        public static List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Краставица",
                    Price = 2.80m,
                    Qty =0
                },
                 new Product()
                {
                    Name = "Домати",
                    Price = 3.90m,
                    Qty =0
                },
                  new Product()
                {
                    Name = "Зелена салата",
                    Price = 1.20m,
                    Qty =0
                },
                   new Product()
                {
                    Name = "Банани",
                    Price = 1.99m,
                    Qty =0
                },
                   new Product()
                {
                    Name = "Ягоди",
                    Price = 4.99m,
                    Qty =0
                },
                   new Product()
                {
                    Name = "Авокадо",
                    Price = 5.99m,
                    Qty =0
                },
                   new Product()
                {
                    Name = "Портокали",
                    Price = 3.99m,
                    Qty =0
                }
            };
        }

    }
}
