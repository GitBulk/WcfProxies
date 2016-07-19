using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using WcfProxies.Contracts.Data;
using WcfProxies.Contracts.Services;

namespace WcfProxies.Proxies.Shared
{
    public class BlogPostClient : ClientBase<IBlogPostService>, IBlogPostService
    {
        public BlogPostClient(string endpoint)
            : base(endpoint)
        { }

        public BlogPostClient(Binding binding, EndpointAddress address)
            : base(binding, address)
        { }

        public IEnumerable<PostData> GetBlogPosts(int blogId)
        {
            return this.Channel.GetBlogPosts(blogId); ;
        }

        public PostData GetPost(int postId)
        {
            return this.Channel.GetPost(postId);
        }
    }
}
