using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace MyFan.App_Code.Twitter
{
    public class TwitterClient
    {

        private String oauth_consumer_key;
        private String oauth_consumer_secret;
        private String oauth_token;
        private String oauth_token_secret;

        
        /// <summary>
        /// Creates a new object that can update statuses in twitter. Loads all keys.
        /// </summary>
        public TwitterClient()
        {
            oauth_consumer_key = ConfigurationManager.AppSettings["twitterConsumerKey"];
            oauth_consumer_secret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
            oauth_token = ConfigurationManager.AppSettings["twitterAccessToken"];
            oauth_token_secret = ConfigurationManager.AppSettings["twitterAccessTokenSecret"];
        }

        /// <summary>
        /// Update status
        /// </summary>
        /// <param name="status">The content of the status</param>
        /// <returns>True if status was updated, false otherwise</returns>
        public bool tweet(String status)
        {
            bool retorno = false;

            string twitterURL = "http://api.twitter.com/1.1/statuses/update.json";
          
            string oauth_version = "1.0";
            string oauth_signature_method = "HMAC-SHA1";

        
            string oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            System.TimeSpan timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            string oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

        
            string baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" + "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&status={6}";

            string baseString = string.Format(
                baseFormat,
                oauth_consumer_key,
                oauth_nonce,
                oauth_signature_method,
                oauth_timestamp, oauth_token,
                oauth_version,
                Uri.EscapeDataString(status)
            );

            string oauth_signature = null;
            using (HMACSHA1 hasher = new HMACSHA1
                (ASCIIEncoding.ASCII.GetBytes(Uri.EscapeDataString(oauth_consumer_secret)
                + "&" + Uri.EscapeDataString(oauth_token_secret))))
            {
                oauth_signature = Convert.ToBase64String(hasher.ComputeHash
                    (ASCIIEncoding.ASCII.GetBytes("POST&" + Uri.EscapeDataString(twitterURL) 
                    + "&" + Uri.EscapeDataString(baseString))));
            }

      
            string authorizationFormat = "OAuth oauth_consumer_key=\"{0}\", oauth_nonce=\"{1}\", " +
                "oauth_signature=\"{2}\", oauth_signature_method=\"{3}\", " + 
                "oauth_timestamp=\"{4}\", oauth_token=\"{5}\", " + "oauth_version=\"{6}\"";

            string authorizationHeader = string.Format(
                authorizationFormat,
                Uri.EscapeDataString(oauth_consumer_key),
                Uri.EscapeDataString(oauth_nonce),
                Uri.EscapeDataString(oauth_signature),
                Uri.EscapeDataString(oauth_signature_method),
                Uri.EscapeDataString(oauth_timestamp),
                Uri.EscapeDataString(oauth_token),
                Uri.EscapeDataString(oauth_version)
            );

            HttpWebRequest objHttpWebRequest = (HttpWebRequest)WebRequest.Create(twitterURL);
            objHttpWebRequest.Headers.Add("Authorization", authorizationHeader);
            objHttpWebRequest.Method = "POST";
            objHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            using (Stream objStream = objHttpWebRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes("status=" + Uri.EscapeDataString(status));
                objStream.Write(content, 0, content.Length);
            }

            var responseResult = "";
            try
            {
                WebResponse objWebResponse = objHttpWebRequest.GetResponse();
                StreamReader objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                responseResult = objStreamReader.ReadToEnd().ToString();
                retorno = true;
            }
            catch (Exception ex)
            {

                responseResult = "Twitter Post Error: " + ex.Message.ToString() + ", authHeader: " + authorizationHeader;
            }
            return retorno;
        }
    }
}