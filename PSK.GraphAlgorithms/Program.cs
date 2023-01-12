using System.Reflection;
using PSK.GraphAlgorithms;
using PSK.GraphAlgorithms.Menu;

Console.WriteLine("Projekt złożone struktury danych 2022/2023");
Console.WriteLine("Algorytmy grafowe. Algorytm Dijkstry, Floyda-Warshalla");
Console.WriteLine("Grupa: Przemysław Postrach, Piotr Kaczmarczyk");
Console.WriteLine("Program posiada ustawiony domyślny graf. Wystarczy wybrać algorytm aby go rozwiązać.");
Console.WriteLine("");

ProgramState state = new ProgramState();

var menuItems = Assembly.GetExecutingAssembly().GetTypes()
    .Where(x => x.IsClass && x.IsAssignableTo(typeof(IMenuItem)))
    .Select(Activator.CreateInstance)
    .Cast<IMenuItem>()
    .ToList();

foreach (var menuItem in menuItems.Select((x, index) => (x, index)))
{
    Console.WriteLine($"{menuItem.index}. {menuItem.x.Description}");
}

Console.WriteLine("Wybierz liczbę aby wykonać polecenie.");

while (!state.Exit)
{
    Console.Write("> ");
    if (int.TryParse(Console.ReadLine(), out var input) && input >= 0 && input < menuItems.Count)
    { 
        menuItems[input].Run(state);
    }
    else
    {
        Console.WriteLine("Wprowadź poprawną pozycję menu.");
    }
}