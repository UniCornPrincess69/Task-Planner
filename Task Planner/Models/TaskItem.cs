using System;


namespace Task_Planner.Models
{
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold
    }


    public class TaskItem
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Priority { get; set; } 
        public TaskStatus Status { get; set; } = TaskStatus.NotStarted;
    }
}
