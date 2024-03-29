List<string> TaskList = new List<string>();

int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((menuOptions)menuSelected == menuOptions.Add)
    {
        ShowMenuAdd();
    }
    else if ((menuOptions)menuSelected == menuOptions.Remove)
    {
        ShowMenuRemove();
    }
    else if ((menuOptions)menuSelected == menuOptions.List)
    {
        ShowMenuTaskList();
    }
} while ((menuOptions)menuSelected != menuOptions.Exit);


int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string userOptionMenu = Console.ReadLine();
    return Convert.ToInt32(userOptionMenu);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        showTaskList();

        string userOptionRemove = Console.ReadLine();
        int indexTaskToRemove = Convert.ToInt32(userOptionRemove) - 1;
        if (indexTaskToRemove <= (TaskList.Count - 1) && indexTaskToRemove >= 0)
        {
            string deletedTask = TaskList[indexTaskToRemove];
            TaskList.RemoveAt(indexTaskToRemove);
            Console.WriteLine($"Tarea {deletedTask} eliminada");
        }
        else
        {
            Console.WriteLine("El valor que ha ingresado es invalido");
            ShowMenuRemove();
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string nameTask = Console.ReadLine();
        TaskList.Add(nameTask);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al registrar la tarea");
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        Console.WriteLine("----------------------------------------");
        showTaskList();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

void showTaskList()
{
    var indexTask = 1;
    TaskList.ForEach(p => Console.WriteLine($"{indexTask++} . {p}"));
    Console.WriteLine("----------------------------------------");
}


public enum menuOptions
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}

