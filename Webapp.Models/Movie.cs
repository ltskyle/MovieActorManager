using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Reddit.Things;

namespace Webapp.Models
{
    public class Movie
    {
        public Movie()
        {
            RedditPosts = new List<RedditPost>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string IMDBmovie { get; set; }
        public string Genre { get; set; }
        public string YearReleased { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Movie Image")]
        public byte[]? MovieImage { get; set; }
        public double? PercentScore { get; set; }
        public string? OverallSentiment { get; set; }
        public List<RedditPost>? RedditPosts { get; set; }
    }
}