using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.AppointmentsTypes
{
    public class DeleteModel : PageModel
    {
        private readonly VisualAcademy.Data.ApplicationDbContext _context;

        public DeleteModel(VisualAcademy.Data.ApplicationDbContext context) => _context = context;

        [BindProperty]
        public AppointmentTypeModel AppointmentTypeModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmenttypemodel = await _context.AppointmentsTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (appointmenttypemodel == null)
            {
                return NotFound();
            }
            else
            {
                AppointmentTypeModel = appointmenttypemodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmenttypemodel = await _context.AppointmentsTypes.FindAsync(id);
            if (appointmenttypemodel != null)
            {
                AppointmentTypeModel = appointmenttypemodel;
                _context.AppointmentsTypes.Remove(AppointmentTypeModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
