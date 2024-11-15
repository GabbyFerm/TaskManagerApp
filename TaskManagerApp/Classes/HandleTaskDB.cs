using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TaskManagerApp
{
    public class HandleTaskDB
    {
        private string jsonFilePath = @"Json\UserTasks.json";
        public List<UserTask> AllUserTasks { get; set; } = new List<UserTask>();

        public HandleTaskDB()
        {
            try
            {
                if (File.Exists(jsonFilePath))
                {
                    var json = File.ReadAllText(jsonFilePath);
                    AllUserTasks = JsonConvert.DeserializeObject<List<UserTask>>(json) ?? new List<UserTask>();
                }
                else
                {
                    Console.WriteLine("No existing data file found. A new file will be created.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing the JSON data: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        public void SaveTasksToFile()
        {
            try
            {
                var json = JsonConvert.SerializeObject(AllUserTasks, Formatting.Indented);
                File.WriteAllText(jsonFilePath, json);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to the file: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Permission error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while saving: {ex.Message}");
            }
        }
    }
}