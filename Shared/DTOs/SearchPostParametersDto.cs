namespace Shared.DTOs
{
    public class SearchPostParametersDto
    {
        public string? UserName { get; set; }
        public int? UserId { get; set; }
        public string? TitleContains { get; set; }
        public string? BodyContains { get; set; }

        public SearchPostParametersDto(string? username, int? userId, string? titleContains, string? bodyContains)
        {
            UserName = username;
            UserId = userId;
            TitleContains = titleContains;
            BodyContains = bodyContains;
        }
    }
}

