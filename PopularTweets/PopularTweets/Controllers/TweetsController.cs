using Newtonsoft.Json.Linq;
using PopularTweets.Models;
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
        public HttpResponseMessage GetTweets(string screenName, int numberTweets)
        {
            TwitterService service = new TwitterService();
            List<TweetModel> results = service.GetTwitterTimelineViaScreenName(screenName, numberTweets);
            if (results == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, results);
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
