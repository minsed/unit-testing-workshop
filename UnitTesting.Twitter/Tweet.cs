using System;
using UnitTesting.Twitter.Interfaces;

namespace UnitTesting.Twitter
{
    public class Tweet : ITweet
    {
        private readonly ITwitterClient _twitterClient;

        public Tweet(ITwitterClient twitterClient)
        {
            _twitterClient = twitterClient;
        }

        public void ReceiveMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException();
            }
            _twitterClient.WriteTweet(message);
            _twitterClient.SendTweetToServer(message);
        }
    }
}