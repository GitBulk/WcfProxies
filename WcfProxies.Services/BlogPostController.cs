using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfProxies.Contracts.Data;
using WcfProxies.Contracts.Services;
using WcfProxies.Data;
using WcfProxies.Data.Repositories;

namespace WcfProxies.Services
{
    public class BlogPostController : IBlogPostService
    {
        IBlogPostRepository blogPostRepo;
        public BlogPostController(IBlogPostRepository blogPostRepo)
        {
            this.blogPostRepo = blogPostRepo;
        }

        public PostData GetPost(int postId)
        {
            PostData data = null;
            Post post = this.blogPostRepo.GetPost(postId);
            if (post != null)
            {
                Blog blog = this.blogPostRepo.GetBlog(post.BlogId);
                data = new PostData()
                {
                    Author = post.Author,
                    Title = post.Title,
                    URI = post.URI,
                    Blog = blog.Name
                };
            }
            return data;
        }

        public IEnumerable<PostData> GetBlogPosts(int blogId)
        {
            List<PostData> data = null;
            List<Post> posts = this.blogPostRepo.GetBlogPosts(blogId);
            if (posts != null)
            {
                data = new List<PostData>();
                foreach (var item in posts)
                {
                    Blog blog = this.blogPostRepo.GetBlog(blogId);
                    data.Add(new PostData()
                    {
                        Title = item.Title,
                        Author = item.Author,
                        URI = item.URI,
                        Blog = blog.Name
                    });
                }
            }
            return data;
        }
    }
}
