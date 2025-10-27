using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataListing.Domain
{
    public class MockData
    {
        public static List<Product> GetProduct(int count)
        {
            List<Product> product = new List<Product>();
            {
                var fake = new Bogus.Faker<Product>()
                 
    .RuleFor(p => p.Id, f => Guid.NewGuid())
    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
    .RuleFor(p => p.Category, f => f.Commerce.Categories(1).First())
    .RuleFor(p => p.Price, f => f.Random.Decimal(5, 500))
    .RuleFor(p => p.Stock, f => f.Random.Int(0, 100))
    .RuleFor(p => p.CreatedDate, f => f.Date.Past(1));

                for (int i = 0; i < count; i++)
                {
                    product.Add(fake.Generate());
                }

                return product;
            }
        }


    }
}
