namespace PostNamespace;

public class Post
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreationDateTime { get; set; }
    public int LikeCount { get; set; }
    public int ViewCount { get; set; }

    public Post(int id, string content)
    {
        Id = id;
        Content = content;
        CreationDateTime = DateTime.Now;
        LikeCount = 0;
        ViewCount = 0;
    }
}
