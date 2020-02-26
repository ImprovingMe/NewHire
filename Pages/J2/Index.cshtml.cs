using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewHire.Core;
using NewHire.Data;

namespace NewHire
{
    public class IndexModel : PageModel
    {
        private readonly NewHire.Data.NewHireDbContext _context;

        public IndexModel(NewHire.Data.NewHireDbContext context)
        {
            _context = context;
        }

        public IList<Job> Job { get;set; }

        public async Task OnGetAsync()
        {
            Job = await _context.Jobs.ToListAsync();
        }
    }
}
