using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Data;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.AppointmentsTypes
{
    public class DetailsModel : PageModel
    {
        private readonly VisualAcademy.Data.ApplicationDbContext _context;

        public DetailsModel(VisualAcademy.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
