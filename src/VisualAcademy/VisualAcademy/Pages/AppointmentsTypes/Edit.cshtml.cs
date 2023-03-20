using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Data;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.AppointmentsTypes
{
    public class EditModel : PageModel
    {
        private readonly VisualAcademy.Data.ApplicationDbContext _context;

        public EditModel(VisualAcademy.Data.ApplicationDbContext context) => _context = context;

        [BindProperty]
        public AppointmentTypeModel AppointmentTypeModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmenttypemodel =  await _context.AppointmentsTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (appointmenttypemodel == null)
            {
                return NotFound();
            }
            AppointmentTypeModel = appointmenttypemodel;
           ViewData["TenantId"] = new SelectList(_context.Tenants, "Id", "Id");
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

            _context.Attach(AppointmentTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentTypeModelExists(AppointmentTypeModel.Id))
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

        private bool AppointmentTypeModelExists(long id) => _context.AppointmentsTypes.Any(e => e.Id == id);
    }
}
