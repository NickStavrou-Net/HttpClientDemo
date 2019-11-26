using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Http.Services
{
    public class PostService : IPostService
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/posts";
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            var httpResponse = await _httpClient.GetAsync(BaseUrl);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<IEnumerable<Post>>(content);

            return tasks;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            var httpResponse = await _httpClient.GetAsync($"{BaseUrl}/{id}");

            if (!httpResponse.IsSuccessStatusCode)
                throw new Exception("Can not retrieve task");

            var content = await httpResponse.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<Post>(content);

            return post;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            var content = JsonConvert.SerializeObject(post);
            var httpResponse = await _httpClient.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
                throw new Exception("Can not create task");

            var createdPost = JsonConvert.DeserializeObject<Post>(await httpResponse.Content.ReadAsStringAsync());

            return createdPost;
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            var content = JsonConvert.SerializeObject(post);
            var httpResponse = await _httpClient.PutAsync($"{BaseUrl}/{post.Id}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
                throw new Exception("Can not update task");

            var updatedPost = JsonConvert.DeserializeObject<Post>(content);

            return updatedPost;
        }

        public async Task DeletePostAsync(int id)
        {
            var httpResponse = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");

            if (!httpResponse.IsSuccessStatusCode)
                throw new Exception("Can not delete this task");

        }
    }
}
