using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages.Categories
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Category>? CategoryList { get; set; }

        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            CategoryList = _context.Categories.ToList();
        }
    }
}
