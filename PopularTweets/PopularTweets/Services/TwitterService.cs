using PopularTweets.Helpers;
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
        public bool GetTwitterTimelineViaScreenName(string screenName) {
            if (string.IsNullOrEmpty(TwitterSingleton.Instance.accessToken) || string.IsNullOrEmpty(TwitterSingleton.Instance.tokenType))
                TwitterSingleton.Instance.Authenticate();

            HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=twitterapi&count=2");
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
                }
            }
                
            return true;
        }
    }
}