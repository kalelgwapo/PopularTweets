using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopularTweets.Models
{
    public class TweetModel
    {
        public string TweetID { get; set; }
        public string TweetURL { get; set; }
        public int RetweetCount { get; set; }
        public int FavouriteCount { get; set; }
    }
}