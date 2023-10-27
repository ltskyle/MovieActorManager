using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reddit.Things;

namespace Webapp.Models
{
    public class Actor
    {
        public Actor()
        {
            RedditPosts = new List<RedditPost>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string IMDBactor { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Actor Image")]
        public byte[]? MovieImage { get; set; }
        public double? PercentScore { get; set; }
        public string? OverallSentiment { get; set; }
        public List<RedditPost>? RedditPosts { get; set; }

    }

}
