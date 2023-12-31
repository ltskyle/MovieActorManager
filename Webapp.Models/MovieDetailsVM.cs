﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class MovieDetailsVM
    {
        public Movie movie { get; set; }
        public List<Actor> actors { get; set; }
        public List<RedditPost> RedditPosts { get; set; }
        public double PercentScore { get; set; }
        public string OverallSentiment { get; set; }
    }
}
