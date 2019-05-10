using System;
using System.IO;
using UnitTesting.Twitter.Interfaces;

namespace UnitTesting.Twitter.Repository
{
    public class TweetRepository : ITweetRepository
    {
        private const string ServerFileName = "Server.txt";
        private const string MessageSeparator = "<[<MessageSeparator>]>";
        private readonly string _serverFullPath = Path.Combine(Environment.CurrentDirectory, ServerFileName);

        public void SaveTweet(string content) => File.AppendAllText(this._serverFullPath, $"{content}{MessageSeparator}");
    }
}
