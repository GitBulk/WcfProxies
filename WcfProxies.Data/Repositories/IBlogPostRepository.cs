using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfProxies.Data.Repositories
{
    public interface IBlogPostRepository
    {
        Post GetPost(int postId);
        Blog GetBlog(int blogId);
        List<Post> GetBlogPosts(int blogId);
    }
}
