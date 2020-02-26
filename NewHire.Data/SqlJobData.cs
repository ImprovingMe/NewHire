using Microsoft.EntityFrameworkCore;
using NewHire.Core;
using System.Collections.Generic;
using System.Linq;

namespace NewHire.Data
{
    public class SqlJobData : IJobData
    {
        private readonly NewHireDbContext db;

        public SqlJobData(NewHireDbContext db)
        {
            this.db = db;
        }
        public Job Add(Job newJob)
        {
            db.Add(newJob);
            return newJob;
        }

        public int Commit()
        {
            return db.SaveChanges();

        }

        public Job Delete(int id)
        {
            var job = GetById(id);
            if (job != null)
            {
                db.Jobs.Remove(job);
            }
            return job;
        }

        public IEnumerable<Job> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Job GetById(int id)
        {
            return db.Jobs.Find(id);
        }

        public int GetCountOfJobs()
        {
            return db.Jobs.Count();
        }

        public IEnumerable<Job> GetJobByName(string name)
        {
            var query = from j in db.Jobs
                        where j.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby j.Name
                        select j;
            return query;
        }

        public Job Update(Job updatedJob)
        {
            var entity = db.Jobs.Attach(updatedJob);
            entity.State = EntityState.Modified;
            return updatedJob;
        }
    }
}
