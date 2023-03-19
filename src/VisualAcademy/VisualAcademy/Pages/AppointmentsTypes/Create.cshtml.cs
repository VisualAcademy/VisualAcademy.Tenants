using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.AppointmentsTypes
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
            ViewData["TenantId"] = new SelectList(_context.Tenants, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public AppointmentTypeModel AppointmentTypeModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.AppointmentsTypes.Add(AppointmentTypeModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
