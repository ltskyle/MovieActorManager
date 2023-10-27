using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class RedditPost
    {
            public int Id { get; set; }
            public string Content { get; set; }
            public string Sentiment { get; set; }
    }
}
