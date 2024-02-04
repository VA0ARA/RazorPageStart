using AbbyWeb.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Dynamic;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
       // [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void  OnGet(int id)
        {
            Category = _db.Category.Find(id);
/*            Category = _db.Category.FirstOrDefault(u=>u.Id==id);
            Category = _db.Category.SingleOrDefault(u=>u.Id==id);
            Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();*/

        }
        public async Task<IActionResult> OnPost()
        {
            // id 0 >> <input hidden asp-for="Category.Id" />
            var categoryForm=_db.Category.Find(Category.Id);
            if(categoryForm!=null) {

                _db.Category.Remove(categoryForm);
                _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
