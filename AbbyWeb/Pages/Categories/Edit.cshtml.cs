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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
       // [BindProperty]
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", " can not use the same name ");
            }
            if(ModelState.IsValid) {

                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
