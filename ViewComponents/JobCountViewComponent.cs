using Microsoft.AspNetCore.Mvc;
using NewHire.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewHire.ViewComponents
{
    public class JobCountViewComponent : ViewComponent
    {
        private readonly IJobData jobData;

        public JobCountViewComponent(IJobData jobData)
        {
            this.jobData = jobData;
        }

        public IViewComponentResult Invoke()
        {
            var count = jobData.GetCountOfJobs();
            return View(count);
        }
    }
}
