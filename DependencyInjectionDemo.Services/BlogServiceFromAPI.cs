using DependencyInjectionDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Services
{
    public class BlogServiceFromAPI : IBlogService
    {
        private readonly HttpClient _httpClient;
        private List<Post> _posts;

        private Post _post;

        public BlogServiceFromAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _posts = new List<Post>();
            _post = new Post();


        }
        public List<Post> GetAllPosts()
        {
            Task.Run(() => GetPostAsync()).Wait();
            return _posts;
        }

        public Post GetPost(int id)
        {
            Task.Run(() => GetPostAsync(id)).Wait();
            return _post;
        }

        //Private Method

        private async Task GetPostAsync()
        {
            var response = await _httpClient.GetAsync("/posts");
            var content = await response.Content.ReadAsStringAsync();

            _posts = JsonConvert.DeserializeObject<List<Post>>(content);
        }

        private async Task GetPostAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/posts/{id}");
            var content = await response.Content.ReadAsStringAsync();

            _post = JsonConvert.DeserializeObject<Post>(content);
        }
    }
}
