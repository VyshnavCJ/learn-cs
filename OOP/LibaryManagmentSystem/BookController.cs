using Spectre.Console;

namespace LibaryManagmentSystem;

public static class BookController
{
	static List<string> books = new List<string>()
    {
	"The Great Gatsby",
	"1984",
	"To Kill a Mockingbird",
	"Pride and Prejudice",
	"The Catcher in the Rye",
    };

	public static void ViewBooks()
	{
		AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

		foreach (var book in books)
		{
			AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
		}

		AnsiConsole.MarkupLine("Press Any Key to Continue.");
		Console.ReadKey();
	}

	public static void AddBooks()
	{
		var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

		// checking if the book already exists to avoid duplication.
		if (books.Contains(title))
		{
			AnsiConsole.MarkupLine("[red]This book already exists.[/]");
		}
		else
		{
			//if book doesn't exist, add to the list of books.
			books.Add(title);
			AnsiConsole.MarkupLine("[green]Book added successfully![/]");
		}

		AnsiConsole.MarkupLine("Press Any Key to Continue.");

		Console.ReadKey();
	}

	public static void DeleteBooks()
	{
		if (books.Count == 0)
		{
			AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
			Console.ReadKey();
			return;
		}

		/* showing a list of books and letting the user choose with arrows
		 using SelectionPrompt, similarly to what we do with the menu */
		var bookToDelete = AnsiConsole.Prompt(
		    new SelectionPrompt<string>()
			.Title("Select a [red]book[/] to delete:")
			.AddChoices(books)
		);

		/* Using the Remove method to delete a book. This method returns a boolean
		  that we can use to present a message in case of success or failure.*/
		if (books.Remove(bookToDelete))
		{
			AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
		}
		else
		{
			AnsiConsole.MarkupLine("[red]Book not found.[/]");
		}

		AnsiConsole.MarkupLine("Press Any Key to Continue.");
		Console.ReadKey();
	}
}
