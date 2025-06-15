using System;
using System.Collections.ObjectModel;
using Task_Planner.Models;

namespace Task_Planner.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public void AddTask(TaskItem task)
        {
            if (task != null && !string.IsNullOrWhiteSpace(task.Title))
            {
                Tasks.Add(task);
            }
        }

        public void RemoveTask(TaskItem task)
        {
            if (task != null && Tasks.Contains(task))
            {
                Tasks.Remove(task);
            }
        }
    }
}
