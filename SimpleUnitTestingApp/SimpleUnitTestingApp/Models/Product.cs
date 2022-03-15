namespace SimpleUnitTestingApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }

    public class ProductDataSource : IDataSource
    {
        public IEnumerable<Product> Products
            => new Product[]
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "LifeJacket", Price = 48.95M}
            };
    }
}
