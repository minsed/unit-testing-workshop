using UnitTesting.Twitter.Interfaces;

namespace UnitTesting.Twitter.Models
{
    public class CoffeeMachine : ITwitterClient
    {
        private readonly IWriter _writer;
        private readonly ITweetRepository _tweetRepository;

        public CoffeeMachine(IWriter writer, ITweetRepository tweetRepository)
        {
            _writer = writer;
            _tweetRepository = tweetRepository;
        }

        public void WriteTweet(string message) => _writer.WriteLine(message);

        public void SendTweetToServer(string message) => _tweetRepository.SaveTweet(message);
    }
}
