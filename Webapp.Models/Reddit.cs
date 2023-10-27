using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class Reddit
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public string Sentiment { get; set; }
    }
}
