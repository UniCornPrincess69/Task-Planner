using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using Task_Planner.Models;
using System;

namespace Task_Planner.Services
{
    public class Data_Manager
    {
        private static readonly string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static readonly string filePath = Path.Combine(folderPath, "tasks.json");

        public static void Save(List<TaskItem> tasks)
        {
           if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            var jsonString = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);

        }

        public static List<TaskItem> Load()
        {
            if (!File.Exists(filePath))
            {
                return new List<TaskItem>();
            }
            var jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<TaskItem>>(jsonString) ?? new List<TaskItem>();
        }
    }
}
