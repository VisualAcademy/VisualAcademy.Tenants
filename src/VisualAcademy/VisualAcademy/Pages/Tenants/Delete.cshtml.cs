using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.Tenants
{
    public class DeleteModel : PageModel
    {
        private readonly VisualAcademy.Data.ApplicationDbContext _context;

        public DeleteModel(VisualAcademy.Data.ApplicationDbContext context) => _context = context;

        [BindProperty]
        public TenantModel TenantModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantmodel = await _context.Tenants.FirstOrDefaultAsync(m => m.Id == id);

            if (tenantmodel == null)
            {
                return NotFound();
            }
            else
            {
                TenantModel = tenantmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenantmodel = await _context.Tenants.FindAsync(id);
            if (tenantmodel != null)
            {
                TenantModel = tenantmodel;
                _context.Tenants.Remove(TenantModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
