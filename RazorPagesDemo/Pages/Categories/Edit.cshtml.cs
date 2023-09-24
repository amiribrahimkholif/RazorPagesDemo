using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public Category? Category { get; set; }

        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
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
            if (!ModelState.IsValid)
                return Page();

            _context.Categories.Update(Category);
            _context.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToPage(nameof(Index));
        }

    }
}
