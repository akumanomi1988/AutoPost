using System;
using Tweetinvi;
using Tweetinvi.Models;

public class TwitterApiClient
{
    private readonly TwitterClient _twitterClient;
    public TwitterApiClient(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
    {
        _twitterClient = new TwitterClient(consumerKey, consumerSecret, accessToken, accessTokenSecret);
    }
    public async Task<string> GetUserName()
    {
       var user =  await _twitterClient.Users.GetAuthenticatedUserAsync();

        return  user == null ? "" : user.Name.ToString();
    }
    public async Task GetTrendingTopics()
    {
        var trends = await _twitterClient.Trends.GetPlaceTrendsAtAsync(779063);
        var lstTrends = trends;
       
    }
}

