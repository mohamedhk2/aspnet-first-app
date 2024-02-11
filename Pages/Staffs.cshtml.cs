using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Models;

namespace MyFirstApp.Pages;

public class StaffsModel : PageModel
{
    private readonly MyDbContext dbContext;
    public IList<Staff> staffs { get; set; }

    public StaffsModel(MyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void OnGet()
    {
        staffs = dbContext.Staffs
            .Include(staff => staff.Store)
            .Include(staff => staff.Manager)
            .Include(staff => staff.InverseManager)
            .ToList();
    }
}