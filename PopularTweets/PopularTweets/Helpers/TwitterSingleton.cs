using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PopularTweets.Helpers
{
    public class TwitterSingleton
    {
        private static TwitterSingleton instance;
        string consumerKey = "8qMnJ3ZEKnetN2uxm4pDpQeyl";
        string consumerKeySecret = "48D0E17qDELzcKd39dGFWzedRoDOi63y6Qd3W46lbmpJphLUVS";
        string oAuthUrl = "https://api.twitter.com/oauth2/token";
        public string tokenType = null;
        public string accessToken = null;

        private TwitterSingleton() { }

        public static TwitterSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TwitterSingleton();
                }
                return instance;
            }
        }

        public void Authenticate() {
            var authHeaderFormat = "Basic {0}";

            var authHeader = string.Format(authHeaderFormat,
                Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(consumerKey) + ":" +
                Uri.EscapeDataString((consumerKeySecret)))
            ));

            var postBody = "grant_type=client_credentials";

            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);
            authRequest.Headers.Add("Authorization", authHeader);
            authRequest.Method = "POST";
            authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (Stream stream = authRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }

            authRequest.Headers.Add("Accept-Encoding", "gzip");

            WebResponse authResponse = authRequest.GetResponse();

            using (authResponse)
            {
                using (var reader = new StreamReader(authResponse.GetResponseStream()))
                {
                    var objectText = reader.ReadToEnd();
                    dynamic tokens = JObject.Parse(objectText);
                    tokenType = tokens.token_type;
                    accessToken = tokens.access_token;
                }
            }
        }


    }
}