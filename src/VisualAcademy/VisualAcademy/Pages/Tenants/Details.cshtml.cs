using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.Tenants;

public class DetailsModel : PageModel
{
    private readonly VisualAcademy.Data.ApplicationDbContext _context;

    public DetailsModel(VisualAcademy.Data.ApplicationDbContext context) => _context = context;

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
}
