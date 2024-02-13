using DependencyInjectionDemo.Models;
using System.Collections.Generic;

namespace DependencyInjectionDemo.Services
{
    public interface IBlogService
    {
        public List<Post> GetAllPosts();

        public Post GetPost(int id);
    }
}