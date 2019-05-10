namespace UnitTesting.Twitter.Interfaces
{
    public interface ITwitterClient
    {
        void WriteTweet(string message);

        void SendTweetToServer(string message);
    }
}
