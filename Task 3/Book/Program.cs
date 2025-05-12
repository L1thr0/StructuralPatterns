namespace Task3
{

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var user1 = new User
            {
                Username = "Anatoli",
                IsAuthenticated = true,
                AllowedBooks = new List<string> { "C# 12 in a Nutshell", "CLR via C#" },
            };

            IBookAccess proxy1 = new BookProxy("C# 12 in a Nutshell", user1);
            Console.WriteLine(proxy1.Read());

            IBookAccess proxy2 = new BookProxy("CLR via C#", user1);
            Console.WriteLine(proxy2.Read());

            IBookAccess deniedProxy = new BookProxy("Clean Architecture: A Craftsman's Guide to Software Structure and Design", user1);
            Console.WriteLine(deniedProxy.Read());

            var user2 = new User
            {
                Username = "Jim",
                IsAuthenticated = false,
                AllowedBooks = new List<string> { "Clean Architecture: A Craftsman's Guide to Software Structure and Design" },
            };

            IBookAccess proxy3 = new BookProxy("Clean Architecture: A Craftsman's Guide to Software Structure and Design", user2);
            Console.WriteLine(proxy3.Read());
        }
    }

}