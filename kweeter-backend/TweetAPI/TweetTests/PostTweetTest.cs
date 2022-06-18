using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using TweetAPI.Controllers;
using TweetAPI.Data;

namespace TweetTests
{
    public class PostTweetTest
    {
        public TweetServiceContext _context { get; private set; }
        public TweetController controller { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDb();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _context.Dispose();
            controller.Dispose();
        }

        private void SeedDb()
        {
            var options = new DbContextOptionsBuilder<TweetServiceContext>()
            .UseInMemoryDatabase("DatabasePostTweet")
            .Options;

            controller = new TweetController(new TweetServiceContext(options));
            _context = new TweetServiceContext(options);

            var dateTime = new DateTime();

            _context.Tweet.Add(new TweetAPI.Model.Tweet(1, "First Tweet", dateTime, "Dit is de eerste Tweet", false, 1));
            _context.Tweet.Add(new TweetAPI.Model.Tweet(2, "Second Tweet", dateTime, "Dit is de tweede Tweet", false, 1));
            _context.Tweet.Add(new TweetAPI.Model.Tweet(3, "Third Tweet", dateTime, "Dit is de derde Tweet", false, 1));
            _context.SaveChanges();
        }

        [Test]
        public void PostOneTweet()
        {
            var dateTime = new DateTime();
            var newTweet = new TweetAPI.Model.Tweet(4, "Fourth Tweet", dateTime, "Dit is de vierde Tweet", false, 2);
            controller.Post(newTweet);

            Assert.NotNull(controller.Get(4));
        }

        [Test]
        public void PostOneTweet_TestProperties()
        {
            var tweet = controller.Get(4);

            Assert.AreEqual(4, tweet.Result.Value.Id);
            Assert.AreEqual("Fourth Tweet", tweet.Result.Value.Title);
            Assert.AreEqual("Dit is de vierde Tweet", tweet.Result.Value.Message);
            Assert.AreEqual(false, tweet.Result.Value.IsDeleted);
            Assert.AreEqual(2, tweet.Result.Value.UserId);
        }
    }
}