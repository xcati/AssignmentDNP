namespace Shared.DTOs;

public class PostBasicDto
{
    public int Id { get; }
    
    public int OwnerId { get; set; }
    public string OwnerName { get; set; }
    public string Title { get; set; }
    public string Body { get; set;}

    public PostBasicDto(int id, string userName, string title, string body)
    {
        Id = id;
        OwnerName = userName;
        Title = title;
        Body = body;
    }
}