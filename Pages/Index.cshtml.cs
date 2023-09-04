using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using CW.Data; // Replace 'ConflictWeb' with your project's actual namespace


public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<MyDataModel> MyData { get; set; }

    public void OnGet()
    {
        MyData = _context.MyData.ToList();
    }
}
