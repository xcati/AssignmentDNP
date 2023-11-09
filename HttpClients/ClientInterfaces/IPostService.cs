using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(string? userName, int? userId,string? titleContains , string? bodyContains );

    Task UpdateAsync(PostUpdateDto dto);

    Task<PostCreationDto> GetByIdAsync(int id);

    Task DeleteAsync(int id);
}
