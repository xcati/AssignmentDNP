using Shared.Models;
using Shared.DTOs;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    Task UpdateAsync(Post post);
    Task<Post?> GetByIdAsync(int todoId);
    
    Task DeleteAsync(int id);

}