using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfProxies.Contracts.Data
{
    [DataContract]
    public class PostData
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string URI { get; set; }

        [DataMember]
        public string Blog { get; set; }
    }
}
