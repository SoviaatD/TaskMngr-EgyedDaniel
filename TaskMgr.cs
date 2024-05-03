using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskitem;

namespace Taskmanager
{
	public class TaskMngr
	{
		public static List<TaskItem> ReadTasksFromFile(string filePath)
		{
			List<TaskItem> tasks = new List<TaskItem>();

			try
			{
				string[] lines = File.ReadAllLines(filePath);
				foreach (string line in lines)
				{
					string[] data = line.Split(';');
					string title = data[0];
					string desc = data[1];
					DateTime dueUntil = DateTime.Parse(data[2]);
					bool IsDone = bool.Parse(data[3]);
					tasks.Add(new TaskItem(title, desc, dueUntil, IsDone));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Az adatok beolvasása sikertelen: {ex.Message}");
			}

			return tasks;
		}

		public static void SaveTasksToFile(List<TaskItem> tasks, string filePath)
		{
			try
			{

				using (StreamWriter w = new StreamWriter(filePath))
				{
					foreach (TaskItem task in tasks)
					{
						bool CompletionStatus = task.IsDone;
						w.WriteLine($"{task.Title};{task.Desc};{task.DueUntil};{CompletionStatus}");
					}
				}
				Console.WriteLine("Feladat sikeresen mentve.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Hiba történt mentés közben: {ex.Message}");
			}
		}
	}
}
