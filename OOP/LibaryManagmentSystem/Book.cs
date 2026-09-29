using LibaryManagmentSystem;

public class Book
{
	public string Name { get; set; }
	public int Pages { get; set; }

	public Book(string name, int pages)
	{
		Name = name;
		Pages = pages;
	}
}
