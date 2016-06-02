using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfProxies.Contracts.Data;

namespace WcfProxies.Contracts.Services
{
    [ServiceContract]
    public interface IBlogPostService
    {
        [OperationContract]
        PostData GetPost(int postId);

        [OperationContract]
        IEnumerable<PostData> GetBlogPosts(int blogId);
    }
}
