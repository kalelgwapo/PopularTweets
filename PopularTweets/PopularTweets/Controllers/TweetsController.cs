using Newtonsoft.Json.Linq;
using PopularTweets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PopularTweets.Controllers
{
    public class TweetsController : ApiController
    {
        // GET: api/Tweets
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tweets/5
        [HttpGet]
        [Route("api/Tweets/GetTweets")]
        public string GetTweets(string screenName, int numberTweets)
        {
            //string screenName = data["screenName"].ToObject<string>();
            //int numberTweets = data["numberTweets"].ToObject<int>();
            TwitterService service = new TwitterService();
            service.GetTwitterTimelineViaScreenName(screenName, numberTweets);
            return "value";
        }

        // POST: api/Tweets
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tweets/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tweets/5
        public void Delete(int id)
        {
        }
    }
}
