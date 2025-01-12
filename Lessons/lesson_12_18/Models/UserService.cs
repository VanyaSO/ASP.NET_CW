namespace lesson_12_18.Models;

public class UserService
{
    public List<User> _users;

    public UserService()
    {
        _users = new List<User>()
        {
            new User()
            {
                Email = "admin@gmail.com",
                Password = "123"
            }
        };
    }

    public User? GetUser(string email) => _users.FirstOrDefault(u => u.Email == email);
}