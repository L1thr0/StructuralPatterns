
namespace Task3
{
    public class User
    {
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<string> AllowedBooks { get; set; } = new();
    }
} 