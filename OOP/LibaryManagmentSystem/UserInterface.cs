using LibaryManagmentSystem.Controllers;
using Spectre.Console;

namespace LibaryManagmentSystem;

public class UserInterface
{
	private readonly BookController bookController = new BookController();
	private readonly MagazineController magazineController = new MagazineController();
	private readonly NewspaperController newspaperController = new NewspaperController();

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
			var itemType = AnsiConsole.Prompt(
			    new SelectionPrompt<ItemType>()
				.Title("What type of item do you want to manage?")
				.AddChoices(Enum.GetValues<ItemType>())
			);
			switch (choice)
			{
				case MenuOptions.ViewBooks:
					ViewItems(itemType);
					break;
				case MenuOptions.AddBooks:
					AddItem(itemType);
					break;
				case MenuOptions.DeleteBooks:
					DeleteItem(itemType);
					break;
			}
		}
	}

	private void ViewItems(ItemType itemType)
	{
		switch (itemType)
		{
			case ItemType.Book:
				bookController.ViewItems();
				break;
			case ItemType.Magazine:
				magazineController.ViewItems();
				break;
			case ItemType.Newspaper:
				newspaperController.ViewItems();
				break;
		}
	}

	private void AddItem(ItemType itemType)
	{
		switch (itemType)
		{
			case ItemType.Book:
				bookController.AddItem();
				break;
			case ItemType.Magazine:
				magazineController.AddItem();
				break;
			case ItemType.Newspaper:
				newspaperController.AddItem();
				break;
		}
	}

	private void DeleteItem(ItemType itemType)
	{
		switch (itemType)
		{
			case ItemType.Book:
				bookController.DeleteItem();
				break;
			case ItemType.Magazine:
				magazineController.DeleteItem();
				break;
			case ItemType.Newspaper:
				newspaperController.DeleteItem();
				break;
		}
	}
}
