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
        const int TWEET_LIMIT = 2;
        public List<TweetModel> tweets;

        public TwitterService()
        {
            tweets = new List<TweetModel>();
        }

        public bool GetTwitterTimelineViaScreenName(string screenName, int numberTweets) {
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
                        tweets.Add(temp);
                    }
                }
            }
            GetOembed();
            return true;
        }

        public bool GetOembed() {
            HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create("https://publish.twitter.com/oembed?url=https%3A%2F%2Ftwitter.com%2FInterior%2Fstatus%2F507185938620219395");
            timeLineRequest.Method = "Get";
            WebResponse timeLineResponse = timeLineRequest.GetResponse();
            var timeLineJson = string.Empty;
            using (timeLineResponse)
            {
                using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                {
                    timeLineJson = reader.ReadToEnd();
                }
            }

            return true;
        }
    }
}