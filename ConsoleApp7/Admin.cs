namespace AdminNamespace;
using PostNamespace;
using NotificationNamespace;
public class Admin
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Post> Posts { get; set; }
    public List<Notification> Notifications { get; set; }

    public Admin(int id, string username, string email, string password)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        Posts = new List<Post>();
        Notifications = new List<Notification>();
    }
}
