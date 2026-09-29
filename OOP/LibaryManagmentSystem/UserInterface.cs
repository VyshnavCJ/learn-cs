using Spectre.Console;

namespace LibaryManagmentSystem;

public class UserInterface
{
	private BookController bookController = new BookController();

	public void MainMenu()
	{
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
					bookController.ViewBooks();
					break;
				case MenuOptions.AddBooks:
					bookController.AddBooks();
					break;
				case MenuOptions.DeleteBooks:
					bookController.DeleteBooks();
					break;
			}
		}
	}
}
