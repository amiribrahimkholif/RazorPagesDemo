using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public Category? Category { get; set; }

        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = _context.Categories.SingleOrDefault(c => c.Id == id);
            }
        }
        public IActionResult OnPost()
        {

            var model = _context.Categories.SingleOrDefault(c => c.Id == Category.Id);
            if (model == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(model);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage(nameof(Index));
        }

    }
}
