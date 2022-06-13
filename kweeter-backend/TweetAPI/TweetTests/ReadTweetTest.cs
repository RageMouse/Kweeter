using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using TweetAPI.Controllers;
using TweetAPI.Data;


namespace TweetTests
{
    class ReadTweetTest
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
            .UseInMemoryDatabase("DatabaseReadTweet")
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
        public void ReadOneTweet()
        {
            var tweet = controller.Get(3);

            Assert.AreEqual(3, tweet.Result.Value.Id);
            Assert.AreEqual("Third Tweet", tweet.Result.Value.Title);
            Assert.AreEqual("Dit is de derde Tweet", tweet.Result.Value.Message);
            Assert.AreEqual(false, tweet.Result.Value.IsDeleted);
            Assert.AreEqual(1, tweet.Result.Value.UserId);
        }
    }
}
