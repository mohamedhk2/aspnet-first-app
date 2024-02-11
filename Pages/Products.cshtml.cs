using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Models;

namespace MyFirstApp.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly MyDbContext dbContext;

        public ProductsModel(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Product> Products { get; set; }
        public IList<Store> Stores { get; set; }

        public void OnGet()
        {
            Products = dbContext.Products
                .Include(product => product.Brand)
                .Include(product => product.Category)
                .Include(product => product.Stocks)
                .Include(product => product.OrderItems)
                .ToList();
            Stores = dbContext.Stores.OrderBy(store => store.StoreName).ToList();
        }
    }
}