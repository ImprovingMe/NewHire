using NewHire.Core;
using System.Collections.Generic;

namespace NewHire.Data
{
    public interface IJobData
    {
        IEnumerable<Job> GetAll();
        IEnumerable<Job> GetJobByName(string name);
        Job GetById(int id);
        Job Update(Job updatedJob);
        Job Add(Job newJob);
        Job Delete(int id);
        int GetCountOfJobs();
        int Commit();

    }
}
