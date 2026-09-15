using LibaryManagmentSystem;
using Spectre.Console;

while (true)
{
    Console.Clear();
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
            .Title("What do you want to do?")
            .AddChoices(Enum.GetValues<MenuOptions>())
    );
    switch (choice)
    {
        case MenuOptions.ViewBooks:
            BookController.ViewBooks();
            break;
        case MenuOptions.AddBooks:
            BookController.AddBooks();
            break;
        case MenuOptions.DeleteBooks:
            BookController.DeleteBooks();
            break;
    }
}
