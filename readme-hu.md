# Feladatkezelő, készítette: Soviaat

### Egy feladatkezelő projekt, melyben a felhasználó hozzáadhat, eltávolíthat, határidőt állíthatsz be és beállíthatod a készenléti állapotát.

1. [TaskItem.cs](#taskitem)
2. [TaskMngr.cs](#taskmgr)
3. [MenuHandler.cs](#menuhandler)

<br>
<br>
<br>


A kód részleges áttekintése

## TaskItem
```cs
public class TaskItem {

// setterek és getterek
  public string Title { get; set; } // A feladat Címe
  public string Desc { get; set; }  // A feladat Leírása
  public string DateTime DueUntil {get; set; } // Az Időpont, ameddig a feladatot be kell fejezni
  public string bool IsDone { get; set; } // Egy logikai érték, ami visszaadja hogy kész van-e a feladat

  public TaskItem(. . .) {
    // constructor
    Title = title;
    . . .
  }

  public void TaskDisplay() {
    // Kiírja a feladat státuszait az alábbi módon:

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

## TaskMgr
```cs
public class TaskMngr {
  public static List<TaskItem> ReadTaskFromFile(string FilePath) {
    List<TaskItem> tasks = new List<TaskItem>(); // Új TaskItem típusú listát hoz létre 

    try {
      string[] lines = File.ReadAllLines(filePath);
      foreach (str ln in lines) {
        // Elválasztja az `ln`-t egy ;-tal majd integrálja a title(str)-t, desc(str)-t, dueUntil(str)-t and IsDone(bool)-t a TaskItem-be
        // Így néz ki: title;desc;dueUntil;IsDone 
      } catch (Exception ex) {
        . . .
      }

      return tasks; // visszaadja a feladatokat
    }
  }

  public static void SaveTasksToFile(List<TaskItem> tasks, string filePath) {
    try {
      using (StreamWriter w = . . .) {
        foreach(TaskItem tsk in tasks) {
          . . .
          // Beleírja az attribútumokat a fájlba (task.Title;task.Desc;task.DueUntil;CompletionStatus)
          // Itt a CompletionStatus = task.IsDone
        }
        Console.WriteLine("Feladat sikeresen mentve");
      }
    }
    catch (. . .) {
        // Kiírja az exception-t ha történt valami mentés közben.
    }
  }
}
```

## MenuHandler

```cs
public class MenuHandler {
  public static void HandleMenu(. . .) {
    while(true) {
      // A menüt az alábbi módon írja ki:
 
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
          AddTask(tasks); // Lehívja a hozzáadás funkciót 
          break;
        case "3":
          DeleteTask(tasks); // Lehívja a eltávolítás funkciót
          break; 
        case "4":
          ToggleTaskStatus(tasks); // Átváltja a feladat készenléti státuszát
          break; 
        case "5":
          return; // Kilépés
        default:
          // ha nem létezik opció a menüt törli és újra kiírja.
          break;
      }
    }
  }
  static void ListTasks(List<TaskItem> tasks) {
    if(tasks.Count == 0) return; // ellenőrzi, hogy nincs-e elérhető feladat, majd erről informálja a felhasználót

    foreach(TaskItem task in tasks) task.TaskDisplay(); // foreach-el loopol és kiírja a feladatokat a fájlból
  }

  static void AddTask(List<TaskItem> tasks) {
    // bekéri a felhasználótól a feladat címét, leírását, határidejét
    string title = Console.WriteLine();
    string desc = . . .;
    string dueUntil = DateTime.parse(. . .);
    tasks.Add(new TaskItem(title, desc, dueUntil, false)); // a hamis logikai érték alapértelmezett, mert nem lehet kész a feladat a létrehozáskor (nyilván)
    // biztosítja a felhasználót arról, hogy a feladat létre lett hozva és el lett mentve a .txt fájlba
  }

  static void DeleteTask(List<TaskItem> tasks) {
    // bekéri a felhasználótól, hogy melyik feladat legyen törölve
    int idx = int.Parse(Console.ReadLine()) - 1; // kivonunk egyet hogy a felhasználó ne zavarodjon össze amikor 1-es sorszámot ír be és a második kerül törlésre xddd

    if(idx >= 0 && idx < tasks.Count) {
      tasks.removeAt(idx);
      // megerősíti a felhasználót, hogy a feladat sikeresen törlésre került
    }
    else {
      // ha a felhasználó által megadott index magasabb mint a feladatok száma, akkor kiírja, hogy nem létezik feladat azzal az index-szel.
    }
  }

  static void ToggleTaskStatus(List<TaskItem> tasks) {
    // bekéri a felhasználótól, hogy melyik feladat készenléti állapotát változtassa meg
    int idx = int.Parse(Console.ReadLine()) - 1; // megint kivonunk 1-et, igen tudom hogy az 'if' checkben implementálhattam volna de naaahhh, ez tuti működik

    if(idx >= 0 && idx < tasks.Count) {
      TaskItem task = tasks[idx]; // selects the task based on the user input // kiválasztja a feladatot a felhasználói bevitel alapján
      if (task.IsDone == true) task.IsDone = false; else task.IsDone = true; // ha a feladat nincs kész, hamis az érték és fordítva
    } else Console.WriteLine(. . .); // visszaadja hogy nincs olyan feladat ami ehhez az indexhez tartozik
  }
}
```

<br>
<br>
<br>

## Program.cs

```cs
string filePath = . . .; // a .txt fájl elérési útja
List<TaskItem> tasks = TaskMngr.ReadTasksFromFile(filePath); // kiolvassa a fájlból a feladatokat, ha persze vannak, és egy TaskItem típusú listába rakja
MenuHandler.HandleMenu(tasks); // kiírja a menüt
TaskMngr.SaveTasksToFile(tasks, filePath); // elmenti a felhasználó által létrehozott feladatokat a fájlba

```

# Szis
