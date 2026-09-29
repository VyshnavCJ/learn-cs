using Spectre.Console;

namespace LibaryManagmentSystem;

public class BookController
{
	public void ViewBooks()
	{
		AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

		foreach (var book in MockData.Books)
		{
			AnsiConsole.MarkupLine($"- [cyan]{book.Name}[/] - [yellow]{book.Pages} pages[/]");
		}

		AnsiConsole.MarkupLine("Press Any Key to Continue.");
		Console.ReadKey();
	}

	public void AddBooks()
	{
		var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
		var page = AnsiConsole.Ask<int>("Enter the [green]page[/] of the book to add:");

		// checking if the book already exists to avoid duplication.
		if (MockData.Books.Exists(x => x.Name.Contains(title)))
		{
			AnsiConsole.MarkupLine("[red]This book already exists.[/]");
		}
		else
		{
			//if book doesn't exist, add to the list of books.
			MockData.Books.Add(new Book(title, page));
			AnsiConsole.MarkupLine("[green]Book added successfully![/]");
		}

		AnsiConsole.MarkupLine("Press Any Key to Continue.");

		Console.ReadKey();
	}

	public void DeleteBooks()
	{
		if (MockData.Books.Count == 0)
		{
			AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
			Console.ReadKey();
			return;
		}

		/* showing a list of books and letting the user choose with arrows
		 using SelectionPrompt, similarly to what we do with the menu */
		var bookToDelete = AnsiConsole.Prompt(
		    new SelectionPrompt<Book>()
			.Title("Select a [red]book[/] to delete:")
			.UseConverter(x => $"{x.Name}")
			.AddChoices(MockData.Books)
		);

		/* Using the Remove method to delete a book. This method returns a boolean
		  that we can use to present a message in case of success or failure.*/
		if (MockData.Books.Remove(bookToDelete))
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
