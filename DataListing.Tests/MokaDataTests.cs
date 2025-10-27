using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataListing.Domain;

namespace DataListing.Tests
{
    public class MokaDataTests

    {
        [Fact]
        public void GetProduct_ReturnsRequestedCount()
        {
            var products = MockData.GetProduct(5);
            Assert.Equal(5, products.Count);
        }

        [Fact]
        public void GetProduct_WithZeroOrNegative_ReturnsEmptyList()
        {
            var zero = MockData.GetProduct(0);
            var negative = MockData.GetProduct(-3);

            Assert.Empty(zero);
            Assert.Empty(negative);
        }

        [Fact]
        public void GetProduct_ProductsHaveValidProperties()
        {
            var products = MockData.GetProduct(10);
            var oneYearAgo = DateTime.UtcNow.AddYears(-1);
            var now = DateTime.UtcNow;

            Assert.All(products, p =>
            {
                Assert.NotEqual(Guid.Empty, p.Id);
                Assert.False(string.IsNullOrWhiteSpace(p.Name));
                Assert.False(string.IsNullOrWhiteSpace(p.Category));
                Assert.InRange(p.Price, 5m, 500m);
                Assert.InRange(p.Stock, 0, 100);
                Assert.True(p.CreatedDate >= oneYearAgo && p.CreatedDate <= now);
            });
        }
    }
}