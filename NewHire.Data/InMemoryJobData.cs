using NewHire.Core;
using System.Collections.Generic;
using System.Linq;

namespace NewHire.Data
{
    public class InMemoryJobData : IJobData
    {
        readonly List<Job> jobs;
        public InMemoryJobData()
        {
            jobs = new List<Job>()
            {
                new Job { Id = 1, Name = "Personal Assistant", Location="Tampa", Department=DepartmentType.HR },
                new Job { Id = 2, Name = "Lead Generator", Location="Tampa", Department=DepartmentType.Sales },
                new Job { Id = 3, Name = "Director of BI", Location = "Tampa", Department =DepartmentType.BI }
            };
        }

        public Job Add(Job newJob)
        {
            jobs.Add(newJob);
            newJob.Id = jobs.Max(j => j.Id) + 1;
            return newJob;
        }

        public int Commit()
        {
            return 0;
        }

        public Job Delete(int id)
        {
            var job = GetById(id);
            if (job != null)
            {
                jobs.Remove(job);
            }
            return null;
        }

        public IEnumerable<Job> GetAll()
        {
            return from j in jobs
                   orderby j.Name
                   select j;
        }

        public Job GetById(int id)
        {
            return jobs.SingleOrDefault(j => j.Id == id);
        }

        public int GetCountOfJobs()
        {
            return jobs.Count();
        }

        public IEnumerable<Job> GetJobByName(string name = null)
        {
            return from j in jobs
                   where string.IsNullOrEmpty(name) || j.Name.StartsWith(name)
                   orderby j.Name
                   select j;
        }

        public Job Update(Job updatedJob)
        {
            var job = jobs.SingleOrDefault(j => j.Id == updatedJob.Id);
            if (job != null)
            {
                job.Name = updatedJob.Name;
                job.Location = updatedJob.Location;
                job.Department = updatedJob.Department;
            }
            return job;
        }
    }
}
