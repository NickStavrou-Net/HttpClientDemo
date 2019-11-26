using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Http.Services.Tests
{
    public class PostServiceTests
    {
        [Fact]
        public async Task CreatePost()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IPostService>();

            var createdTask = await service.CreatePostAsync(new Post
            {
                Id = 101,
                UserId = 1,
                Title = "something",
                Body = "anything"
            });

            Assert.Equal(101, createdTask.Id);
        }

        [Fact]
        public async Task DeletePost()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IPostService>();

            await service.DeletePostAsync(1);
        }

        [Fact]
        public async Task GetAllPosts()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IPostService>();

            var tasks = await service.GetAllAsync();

            Assert.NotEmpty(tasks);
        }

        [Fact]
        public async Task GetExistingPost()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IPostService>();

            var task = await service.GetPostAsync(1);

            Assert.NotNull(task);
        }

        [Fact]
        public async Task UpdatePost()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IPostService>();

            var updatedTask = await service.UpdatePostAsync(new Post
            {
                Id = 1,
                UserId = 1,
                Title = "something",
                Body = "anything"
            });

            Assert.NotNull(updatedTask.Body);
        }
    }
}
