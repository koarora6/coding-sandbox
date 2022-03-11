using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
       public ViewResult Index()
        {

            Product[] productArray =
            {
                new Product {Name = "kayak", Price = 275M},
                new Product{ Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();

            ShoppingCart cart = new ShoppingCart()
            {
                Products = Product.GetProducts()
            };

            //extension method called as any other normal method
            decimal cartTotal = cart.TotalPrices();

            List<string> results = new List<string> ();
            foreach(Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price;
                string relatedName = p?.Related?.Name ?? "<None>";
                results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
            }

            return View(results);
        }
    }
}