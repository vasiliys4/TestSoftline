namespace TestSoftline.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string StatusName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
