<h1> Task Manager by Egyed Dániel </h1> 
<h6>(aka Soviaat)</h6>

<h3>A project where you can `Create`, `Delete`, `Schedule` tasks and mark them as complete.</h3>
#### A magyar dokumentációt [itt](https://github.com/Soviaat/TaskMgr-project/blob/main/docs/readme-hu.md) érheted el.

[Taskitem.cs](#taskitem)
[TaskMgr.cs](#taskmgr)
[MenuHandler.cs](#menuhandler)



<br>
<br>
<br>


Partial walkthrough of the code:

<h2 id="taskitem"> TaskItem <h2>

```cs
public class TaskItem {

// setters and getters
  public string Title { get; set; } // Title of the task
  public string Desc { get; set; }  // Description of the task
  public string DateTime DueUntil {get; set; } // The time which the task set to be completed
  public string bool IsDone { get; set; } // Is the task done? returns a boolean

  public TaskItem(. . .) {
    // constructor
    Title = title;
    . . .
  }

  public void TaskDisplay() {
    // Writes out the task's statuses like this :

    /* Feladat: {Title}
     Feladat leírása: {Desc}
     Elkészítési határidő: {DueUntil}
     Állapot: {(IsDone ? Kész : Nincs kész)} */
  }
}
```

<br>
<br>
<br>

<h2 id="taskmgr">TaskMgr</h2>

```cs
public class TaskMngr {
  public static List<TaskItem> ReadTaskFromFile(string FilePath) {
    List<TaskItem> tasks = new List<TaskItem>(); // creates a List with the TaskItem attribute.

    try {
      string[] lines = File.ReadAllLines(filePath);
      foreach (str ln in lines) {
        // Splits the `ln` with ; then parses the title(str), desc(str), dueUntil(DateTime) and IsDone(bool) into the TaskItem
        // looks like this: title;desc;dueUntil;IsDone 
      } catch (Exception ex) {
        . . .
      }

      return tasks; // returns the tasks read from the file
    }
  }

  public static void SaveTasksToFile(List<TaskItem> tasks, string filePath) {
    try {
      using (StreamWriter w = . . .) {
        foreach(TaskItem tsk in tasks) {
          . . .
          // Writes the attributes into the file (task.Title;task.Desc;task.DueUntil;CompletionStatus)
          // CompletionStatus = task.IsDone
        }
        Console.WriteLine("Feladat sikeresen mentve");
      }
    }
    catch (. . .) {
        // Outputs the exception that has occured during saving.
    }
  }
}
```

<h2 id="menuhandler">MenuHandler</h2> 

```cs
public class MenuHandler {
  public static void HandleMenu(. . .) {
    while(true) {
      // Writes out the menu like this:
      /* 1 - Feladatok listázása
         2 - Feladat létehozása
         3 - Feladat törlése
         4 - Feladat státuszának módosítása
         5 - Kilépés
         Válassz opciót: */
  
      string choice = Console.ReadLine();
      switch(choice) {
        case "1":
          ListTasks(tasks);
          break;
        case "2":
          AddTask(tasks); // Adds a task
          break;
        case "3":
          DeleteTask(tasks); // Deletes a task
          break; 
        case "4":
          ToggleTaskStatus(tasks);
          break; // Toggles the status of a task
        case "5":
          return; // Exits
        default:
          // No such option
          break;
      }
    }
  }
  static void ListTasks(List<TaskItem> tasks) {
    if(tasks.Count == 0) return; // checks if there is no tasks available and informs the user about it

    foreach(TaskItem task in tasks) task.TaskDisplay(); // loops and prints out the tasks listed in the file
  }

  static void AddTask(List<TaskItem> tasks) {
    // gets the user input for the title, description, due date
    string title = Console.WriteLine();
    string desc = . . .;
    string dueUntil = DateTime.parse(. . .);
    tasks.Add(new TaskItem(title, desc, dueUntil, false)); // the false attribute is default since a task can't be done when created (duh)
    // assures the user that the task has been added to the text file
  }

  static void DeleteTask(List<TaskItem> tasks) {
    // gets the user input to which task has to be deleted
    int idx = int.Parse(Console.ReadLine()) - 1; // subtracting 1 so the user doesn't get confused when typing 1 and it deletes the second task or says it doesn't exist XD

    if(idx >= 0 && idx < tasks.Count) {
      tasks.removeAt(idx); // we could've subtracted the 1 here, but naaaahhh
      // confirms the user that the task has been successfully removed
    }
    else {
      // if the index is higher than the number of user created tasks then it displays that there is no tasks with that index
    }
  }

  static void ToggleTaskStatus(List<TaskItem> tasks) {
    // gets the user input to which task has to have its completion status changed
    int idx = int.Parse(Console.ReadLine()) - 1; // subtracting 1 again, yes I could've done it inside the 'if' check but naahhhhhhh, this surely works

    if(idx >= 0 && idx < tasks.Count) {
      TaskItem task = tasks[idx]; // selects the task based on the user input
      if (task.IsDone == true) task.IsDone = false; else task.IsDone = true; // if the task isn't done, changes it to false and v.v.
    } else Console.WriteLine(. . .); // returns that there is no tasks that corresponds to the input index
  }
}
```

<br>
<br>
<br>

<h2>Program.cs</h2>

```cs
string filePath = . . .; // gets the path of the .txt file
List<TaskItem> tasks = TaskMngr.ReadTasksFromFile(filePath); // read the tasks from the file if there's any and puts it into a TaskItem list
MenuHandler.HandleMenu(tasks); // writes out the menu
TaskMngr.SaveTasksToFile(tasks, filePath); // saves the user created tasks to the file

```

<h1>That's it folks.</h1>
