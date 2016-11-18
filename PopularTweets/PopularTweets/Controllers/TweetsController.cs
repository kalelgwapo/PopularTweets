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

            TwitterService service = new TwitterService();
            service.GetTwitterTimelineViaScreenName("test");
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tweets/5
        public string Get(int id)
        {
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
