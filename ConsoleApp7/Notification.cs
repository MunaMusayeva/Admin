namespace NotificationNamespace;
using UserNamespace;
public class Notification
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime DateTime { get; set; }
    public User FromUser { get; set; }

    public Notification(int id, string text, DateTime dateTime, User fromUser)
    {
        Id = id;
        Text = text;
        DateTime = dateTime;
        FromUser = fromUser;
    }
}
