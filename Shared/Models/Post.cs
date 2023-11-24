using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; private set; }
    
    public int OwnerId { get; set; }
    public string Title { get; private set; }
    public string Body { get; set; }

    
    public Post(int ownerId, string title, string body)
    {
        OwnerId = ownerId;
        Title = title;
        Body = body;
    }
    private Post(){}
}
