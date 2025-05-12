namespace Task3
{
    public class BookProxy : IBookAccess
    {
        private readonly string _bookTitle;
        private readonly User _user;
        private Book? _realBook;

        public BookProxy(string bookTitle, User user)
        {
            _bookTitle = bookTitle;
            _user = user;
        }

        public string Read()
        {
            if (!_user.IsAuthenticated)
                return $"Ошибка: пользователь {_user.Username} не авторизован.";

            if (!_user.AllowedBooks.Contains(_bookTitle))
                return $"Ошибка: доступ к книге {_bookTitle} запрещен.";

            if (_realBook == null)
            {
                _realBook = new Book(_bookTitle);
            }

            return _realBook.Read();
        }
    }
}
