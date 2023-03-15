using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.Tenants
{
    public class CreateModel : PageModel
    {
        private readonly VisualAcademy.Data.ApplicationDbContext _context;

        public CreateModel(VisualAcademy.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TenantModel TenantModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tenants.Add(TenantModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
