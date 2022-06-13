using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using TweetAPI.Controllers;
using TweetAPI.Data;

namespace TweetTests
{
    public class DeleteTweetTest
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
            .UseInMemoryDatabase("DatabaseDeleteTweet")
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
        public void DeleteOneTweet()
        {
            controller.Delete(3);

            var tweet = controller.Get(3);

            Assert.AreEqual(true, tweet.Result.Value.IsDeleted);
        }
    }
}