namespace LanguageFeatures.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            InStock = stock;
        }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public string Category { get; set; } = "Watersports";

        public bool InStock { get; }
        public static Product[] GetProducts()
        {
            Product kayak = new Product()
            {
                Name = "Kayak",
                Price = 275M,
                Category = "Water Craft"
            };

            Product lifeJacket = new Product(false)
            {
                Name = "LifeJacket",
                Price = 48.9M
            };

            kayak.Related = lifeJacket;

            return new Product[] { kayak, lifeJacket, null };
        }
    }
}
