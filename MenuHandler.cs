using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskitem;

namespace Taskmanager
{
	public class MenuHandler {
		public static void HandleMenu(List<TaskItem> tasks) {
			while (true)
			{
				Console.WriteLine("1 - Feladatok listázása");
				Console.WriteLine("2 - Feladat létrehozása");
				Console.WriteLine("3 - Feladat törlése");
				Console.WriteLine("4 - Feladat státuszának módosítása");
				Console.WriteLine("5 - Kilépés");
				Console.Write("Válassz egy opciót: \n");

				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						Console.Clear();
						ListTasks(tasks);
						break;
					case "2":
						Console.Clear();
						AddTask(tasks);
						break;
					case "3":
						Console.Clear();
						DeleteTask(tasks);
						break;
					case "4":
						Console.Clear();
						ToggleTaskStatus(tasks);
						break;
					case "5":
						Console.Clear();
						Console.WriteLine("Kilépés folyamatban.");
						return;
					default:
						Console.WriteLine("Ilyen opció nem létezik, válassz újra.");
						break;
				}
			}
		}

		static void ListTasks(List<TaskItem> tasks)
		{
			if (tasks.Count == 0)
			{
				Console.WriteLine("Nincsenek feladatok.");
				return;
			}

			Console.WriteLine(" - - - - - Feladatok - - - - - \n");
			foreach (TaskItem task in tasks)
			{
				task.TaskDisplay();
			}
		}

		static void AddTask(List<TaskItem> tasks)
		{
			Console.WriteLine("Feladat címe: ");
			string title = Console.ReadLine();
			Console.WriteLine("Feladat leírása: ");
			string desc = Console.ReadLine();
			Console.WriteLine("Határidő (Formátum: YYYY-MM-DD): ");
			DateTime dueUntil = DateTime.Parse(Console.ReadLine());
			Console.Clear();
			tasks.Add(new TaskItem(title, desc, dueUntil, false));
			Console.WriteLine($"\n{title} nevű feladat hozzáadva.");
		}

		static void DeleteTask(List<TaskItem> tasks)
		{
			Console.WriteLine("Törlendő feladat száma: ");
			int idx = int.Parse(Console.ReadLine()) - 1;

			if (idx >= 0 && idx < tasks.Count)
			{
				tasks.RemoveAt(idx);
				Console.WriteLine("Feladat törlésre került.");
			}
			else
			{
				Console.WriteLine("Ilyen sorszámú feladat nem létezik.");
			}
		}
		static void ToggleTaskStatus(List<TaskItem> tasks) { 
			Console.Write("Módosítandó feladat sorszáma: \n");
			int idx = int.Parse(Console.ReadLine()) - 1;

			if(idx >= 0 && idx < tasks.Count) { 
				TaskItem task = tasks[idx];
				if(task.IsDone == true) task.IsDone = false; else task.IsDone = true;

				Console.WriteLine($"A(z) '{task.Title}' című feladat státusza mostantól: {(task.IsDone ? "Kész" : "Nincs kész")}");
			} else Console.WriteLine("Ilyen sorszámú feladat nem létezik.");
		}
	}
}
