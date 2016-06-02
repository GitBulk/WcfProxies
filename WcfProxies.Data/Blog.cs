using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfProxies.Data
{
    public class Blog : IEntity
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string URI { get; set; }
        public string Owner { get; set; }
        public List<Post> Posts { get; set; }
        public Blog()
        {
            Posts = new List<Post>();
        }
        public int Id
        {
            get
            {
                return BlogId;
            }

            set
            {
                BlogId = value;
            }
        }
    }
}
