using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.Tenants
{
    public class IndexModel : PageModel
    {
        private readonly VisualAcademy.Data.ApplicationDbContext _context;

        public IndexModel(VisualAcademy.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TenantModel> TenantModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            TenantModel = await _context.Tenants.ToListAsync();
        }
    }
}
