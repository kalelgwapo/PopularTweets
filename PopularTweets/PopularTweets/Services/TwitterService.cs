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
            if(string.IsNullOrEmpty(TwitterSingleton.Instance.accessToken) && string.IsNullOrEmpty(TwitterSingleton.Instance.tokenType))
                TwitterSingleton.Instance.Authenticate();
            return true;
        }
    }
}