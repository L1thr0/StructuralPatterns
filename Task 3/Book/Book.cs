namespace Task3
{
    public class Book
    {
        public string Title { get; }
        public string Content { get; }

        public Book(string title)
        {
            Console.WriteLine($"Загрузка книги: {title}...");
            Thread.Sleep(2000);
            Title = title;
            Content = $"Содержимое книги \"{title}\"...";
        }

        public string Read()
        {
            return Content;
        }
    }
}