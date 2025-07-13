namespace Jobhunt.Models
{
    public class JobCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Job>Jobs { get; set; }

    }
}
