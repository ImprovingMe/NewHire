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
    public class DeleteModel : PageModel
    {
        private readonly IJobData jobData;
        public Job Job { get; set; }

        public DeleteModel(IJobData jobData)
        {
            this.jobData = jobData;
        }
        public IActionResult OnGet(int jobId)
        {
            Job = jobData.GetById(jobId);
            if (Job == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int jobId)
        {
            var job = jobData.Delete(jobId);
            jobData.Commit();

            if (job == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{job.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}