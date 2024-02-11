using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Models;

namespace MyFirstApp.Pages;

public class ProductSearchModel : PageModel
{
    public Product product { get; set; }
    private readonly MyDbContext dbContext;
    public IList<Store> Stores { get; set; }

    public ProductSearchModel(MyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        try
        {
            int productId = int.Parse(Request.Form["productId"]);
            product = dbContext.Products
                .Include(product => product.OrderItems)
                .Include(product => product.Stocks)
                .FirstOrDefault(product => product.ProductId == productId);
            Stores = dbContext.Stores.OrderBy(store => store.StoreName).ToList();
        }
        catch (Exception e)
        {
        }
    }
}