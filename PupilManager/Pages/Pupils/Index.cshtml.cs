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
    public class IndexModel : PageModel
    {
        private readonly PupilManager.Data.ApplicationDbContext _context;

        public IndexModel(PupilManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Pupil> Pupil { get;set; }

        public async Task OnGetAsync()
        {
            Pupil = await _context.Pupils.ToListAsync();
        }
    }
}
