using System.ComponentModel.DataAnnotations;


namespace NewHire.Core
{
    public class Job
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        public DepartmentType Department { get; set; }
    }
}
