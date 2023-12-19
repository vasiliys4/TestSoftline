using System.ComponentModel.DataAnnotations;

namespace TestSoftline.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
