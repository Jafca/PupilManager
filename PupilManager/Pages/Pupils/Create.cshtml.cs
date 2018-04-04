using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PupilManager.Data;
using PupilManager.Models;

namespace PupilManager.Pages.Pupils
{
    public class CreateModel : PageModel
    {
        private readonly PupilManager.Data.ApplicationDbContext _context;

        public CreateModel(PupilManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pupil Pupil { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pupils.Add(Pupil);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}