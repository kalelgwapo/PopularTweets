using Newtonsoft.Json.Linq;
using PopularTweets.Helpers;
using PopularTweets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace PopularTweets.Services
{
    public class TwitterService
    {
        const int TWEET_LIMIT = 3200;
        public List<TweetModel> tweets;

        public TwitterService()
        {
            tweets = new List<TweetModel>();
        }

        public List<TweetModel> GetTwitterTimelineViaScreenName(string screenName, int numberTweets) {
            if (string.IsNullOrEmpty(TwitterSingleton.Instance.accessToken) || string.IsNullOrEmpty(TwitterSingleton.Instance.tokenType))
                TwitterSingleton.Instance.Authenticate();

            string timelineUrl = string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&count={1}", screenName, TWEET_LIMIT);
            HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create(timelineUrl);
            var timelineHeaderFormat = "{0} {1}";
            timeLineRequest.Headers.Add("Authorization", string.Format(timelineHeaderFormat, TwitterSingleton.Instance.tokenType, TwitterSingleton.Instance.accessToken));
            timeLineRequest.Method = "Get";
            WebResponse timeLineResponse = timeLineRequest.GetResponse();
            var timeLineJson = string.Empty;
            using (timeLineResponse)
            {
                using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                {
                    timeLineJson = reader.ReadToEnd();
                    dynamic data = JArray.Parse(timeLineJson);
                    foreach (var tweet in data)
                    {
                        TweetModel temp = new TweetModel();
                        temp.TweetID = tweet.id_str;
                        temp.TweetURL = string.Format("https://twitter.com/{0}/status/{1}", screenName, temp.TweetID);
                        temp = GetFavouriteRetweetCount(temp);
                        tweets.Add(temp);
                    }
                }
            }
            tweets = tweets.OrderByDescending(o => o.Score).Take(numberTweets).ToList();
            GetOembed();
            return tweets;
        }

        public void GetOembed() {
            foreach (TweetModel tweet in tweets)
            {
                string tempUrl = string.Format("https://publish.twitter.com/oembed?url={0}",tweet.TweetURL);
                HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create(tempUrl);
                timeLineRequest.Method = "Get";
                WebResponse timeLineResponse = timeLineRequest.GetResponse();
                var timeLineJson = string.Empty;
                using (timeLineResponse)
                {
                    using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                    {
                        timeLineJson = reader.ReadToEnd();
                        dynamic data = JObject.Parse(timeLineJson);
                        tweet.EmbedHtml = data.html;
                    }
                }

            }
            
        }

        public TweetModel GetFavouriteRetweetCount(TweetModel tweet)
        {
                string tempUrl = string.Format("https://api.twitter.com/1.1/statuses/show/{0}.json", tweet.TweetID);
                HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create(tempUrl);
                var timelineHeaderFormat = "{0} {1}";
                timeLineRequest.Headers.Add("Authorization", string.Format(timelineHeaderFormat, TwitterSingleton.Instance.tokenType, TwitterSingleton.Instance.accessToken));
                timeLineRequest.Method = "Get";
            WebResponse timeLineResponse = timeLineRequest.GetResponse();
                var timeLineJson = string.Empty;
                using (timeLineResponse)
                {
                    using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                    {
                        timeLineJson = reader.ReadToEnd();
                        dynamic data = JObject.Parse(timeLineJson);
                        tweet.RetweetCount = data.retweet_count;
                        tweet.FavouriteCount = data.favorite_count;
                        tweet.SetScore();
                    }
                }

            return tweet;
                
        }

    }
}