using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHire.Core;
using NewHire.Data;

namespace NewHire.Pages.Jobs
{
    public class DetailModel : PageModel
    {
        private readonly IJobData jobData;
        
        [TempData]
        public string Message { get; set; }
        public DetailModel(IJobData jobData)
        {
            this.jobData = jobData;
        }
        public Job Job { get; set; }
        public IActionResult OnGet(int jobId)
        {
            Job = jobData.GetById(jobId);
            if(Job == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}