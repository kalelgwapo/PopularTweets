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
        public string EmbedHtml { get; set; }
        public int Score { get; set;          
        }
        public void SetScore()
        {
            this.Score = this.FavouriteCount + (this.RetweetCount * 2);
        }
    }
}