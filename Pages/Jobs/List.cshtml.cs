using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NewHire.Data;
using NewHire.Core;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace NewHire.Pages.Jobs
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IJobData jobData;

        public string Message { get; set; }
        public IEnumerable<Core.Job> Jobs { get; set; }
        
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, Data.IJobData jobData)
        {
            this.config = config;
            this.jobData = jobData;
        }
        public void OnGet()
        {

            
            Message = config["Message"];
            //Jobs = jobData.GetAll();
            Jobs = jobData.GetJobByName(SearchTerm);
        }
    }
}
