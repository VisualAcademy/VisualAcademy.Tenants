using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.Tenants
{
    public class EditModel : PageModel
    {
        private readonly VisualAcademy.Data.ApplicationDbContext _context;

        public EditModel(VisualAcademy.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            TenantModel = tenantmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TenantModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantModelExists(TenantModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TenantModelExists(long id) => _context.Tenants.Any(e => e.Id == id);
    }
}
