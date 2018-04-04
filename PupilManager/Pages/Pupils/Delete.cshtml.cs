using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PupilManager.Data;
using PupilManager.Models;

namespace PupilManager.Pages.Pupils
{
    public class DeleteModel : PageModel
    {
        private readonly PupilManager.Data.ApplicationDbContext _context;

        public DeleteModel(PupilManager.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pupil = await _context.Pupils.FindAsync(id);

            if (Pupil != null)
            {
                _context.Pupils.Remove(Pupil);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
