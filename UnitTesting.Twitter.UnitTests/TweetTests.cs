using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTesting.Twitter.Interfaces;
using Xunit;

namespace UnitTesting.Twitter.UnitTests
{
    public class TweetTests
    {
        [Fact]
        public void GivenTweet_WhenReceivedMessage_ThenWriteToClient() {

            //Arrange
            var twitterClientMock = Substitute.For<ITwitterClient>();
            var tweet = new Tweet(twitterClientMock);
            string message = "Test message";

            //Act
            tweet.ReceiveMessage(message);

            //Assert
            twitterClientMock.Received(1).WriteTweet(Arg.Is<string>(message));
        }
    }
}
