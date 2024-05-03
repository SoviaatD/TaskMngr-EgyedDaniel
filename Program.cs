using System;
using System.IO;
using System.Collections.Generic;
using Taskitem;
using Taskmanager;

namespace Taskmanager
{
	public class Program
	{
		static void Main(string[] args)
		{
			string filePath = "feladatok.txt";
			List<TaskItem> tasks = TaskMngr.ReadTasksFromFile(filePath);
			MenuHandler.HandleMenu(tasks);
			TaskMngr.SaveTasksToFile(tasks, filePath);
		}
	}
}
