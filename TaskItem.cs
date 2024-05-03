using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskitem
{
	public class TaskItem
	{
		public string Title { get; set; }
		public string Desc { get; set; }
		public DateTime DueUntil { get; set; }
		public bool IsDone { get; set; }

		public TaskItem(string title, string desc, DateTime dueUntil, bool isDone)
		{
			Title = title;
			Desc = desc;
			DueUntil = dueUntil;
			IsDone = isDone;
		}

		public void TaskDisplay()
		{
			Console.WriteLine($"Feladat: {Title}");
			Console.WriteLine($"Feladat leírása: {Desc}");
			Console.WriteLine($"Elkészítési határidő: {DueUntil}");
			Console.WriteLine($"Állapot: {(IsDone ? "Kész" : "Nincs kész")}");
			Console.WriteLine();
		}
	}
}
