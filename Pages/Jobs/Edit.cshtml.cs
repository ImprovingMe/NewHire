using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewHire.Data;
using NewHire.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NewHire.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly IJobData jobData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty(SupportsGet = false)]
        public Job Job { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }




        public EditModel(IJobData jobData, IHtmlHelper htmlHelper)
        {
            this.jobData = jobData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? jobId)
        {

            Departments = htmlHelper.GetEnumSelectList<DepartmentType>();

            if (jobId.HasValue)
            {
                Job = jobData.GetById(jobId.Value);
            }
            else
            {
                Job = new Job();

            }

            if (Job == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Departments = htmlHelper.GetEnumSelectList<DepartmentType>();
                return Page();
            }

            if (Job.Id > 0)
            {
                jobData.Update(Job);
            }
            else
            {
                jobData.Add(Job);
            }


            jobData.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Detail", new { jobId = Job.Id });

        }
    }
}