namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        //the first param should be the class we are extending
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach(Product prod in products)
            {
                total += prod?.Price ?? 0;
            }

            return total;
        }

        public static IEnumerable<Product> FilterByPrice(
            this IEnumerable<Product> productEnum, decimal minPrice)
        {
            foreach(Product prod in productEnum)
            {
                if((prod?.Price ?? 0) >= minPrice)
                {
                    yield return prod;
                }
            }
        }
        
    }
}
