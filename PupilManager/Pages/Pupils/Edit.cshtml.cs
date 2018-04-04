using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PupilManager.Data;
using PupilManager.Models;

namespace PupilManager.Pages.Pupils
{
    public class EditModel : PageModel
    {
        private readonly PupilManager.Data.ApplicationDbContext _context;

        public EditModel(PupilManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pupil Pupil { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pupil = await _context.Pupils.SingleOrDefaultAsync(m => m.ID == id);

            if (Pupil == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pupil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PupilExists(Pupil.ID))
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

        private bool PupilExists(int id)
        {
            return _context.Pupils.Any(e => e.ID == id);
        }
    }
}
