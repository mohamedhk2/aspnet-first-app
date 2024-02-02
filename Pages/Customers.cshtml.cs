using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Models;

namespace MyFirstApp.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly MyDbContext dbContext;

        public CustomersModel(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Customer> Customers { get; set; }

        public void OnGet()
        {
            Customers = dbContext.Customers
                .Include(c => c.Orders)
                //.ThenInclude(o => o.OrderStatus)
                .ToList();
        }
    }
}