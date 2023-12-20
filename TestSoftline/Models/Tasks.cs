namespace TestSoftline.Models
{
    public class Tasks
    {
        public int TasksId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public int StatusId {  get; set; }
    }
}
