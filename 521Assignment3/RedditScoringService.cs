using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VaderSharp2;
using Webapp.Models;

public class RedditScoringService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly SentimentIntensityAnalyzer _sentimentAnalyzer;

    public RedditScoringService(IHttpClientFactory httpClientFactory, SentimentIntensityAnalyzer sentimentAnalyzer)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _sentimentAnalyzer = sentimentAnalyzer ?? throw new ArgumentNullException(nameof(sentimentAnalyzer));
    }

    public async Task<(double Score, string PosNegNeu, List<RedditPost> RedditPosts)> GetRedditScoreAsync(string queryText)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

        var response = await httpClient.GetStringAsync($"https://www.reddit.com/search.json?limit=100&q={Uri.EscapeDataString(queryText)}");
        var posts = ParseRedditResponse(response);

        double postsTotal = 0;
        int nonZeroCount = 0;
        List<RedditPost> redditPosts = new List<RedditPost>();

        foreach (var post in posts)
        {
            var results = _sentimentAnalyzer.PolarityScores(post.Content);
            postsTotal += results.Compound;
            if (results.Compound != 0) nonZeroCount++;
            post.Sentiment = results.Compound switch
            {
                > 0 => "Positive",
                < 0 => "Negative",
                _ => "Neutral"
            };
            redditPosts.Add(post);
        }

        if (nonZeroCount == 0) return (0, "Neutral", redditPosts);

        var score = postsTotal / nonZeroCount;
        var percentScore = Math.Round(score * 100);
        var PosNegNeu = "Neutral";
        if (score < 0) PosNegNeu = "Negative";
        else if (score > 0) PosNegNeu = "Positive";

        return (percentScore, PosNegNeu, redditPosts);
    }

    private List<RedditPost> ParseRedditResponse(string response)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var redditResponse = JsonSerializer.Deserialize<RedditResponse>(response, options);
        var posts = new List<RedditPost>();

        if (redditResponse?.Data.Children != null)
        {
            foreach (var child in redditResponse.Data.Children)
            {
                if (!string.IsNullOrEmpty(child.Data.SelfText))
                {
                    posts.Add(new RedditPost { Content = child.Data.SelfText });
                }
                else if (!string.IsNullOrEmpty(child.Data.Title))
                {
                    posts.Add(new RedditPost { Content = child.Data.Title });
                }
            }
        }

        return posts;
    }
}

public class RedditResponse
{
    public RedditData Data { get; set; }
}

public class RedditData
{
    public List<RedditChild> Children { get; set; }
}

public class RedditChild
{
    public RedditPostData Data { get; set; }
}

public class RedditPostData
{
    public string Title { get; set; }
    public string SelfText { get; set; }
}
