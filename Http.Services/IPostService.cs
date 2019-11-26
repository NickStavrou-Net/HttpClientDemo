using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Http.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetPostAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task<Post> UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
}
