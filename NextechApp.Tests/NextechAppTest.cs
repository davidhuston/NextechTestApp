using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NextechApp.Models;

namespace NextechApp.Tests
{
    [TestClass]
    public class NextechAppTest
    {
        [TestMethod]
        public void TestTopStories()
        {
            var storyRepository = new StoryRespository();
            var stories = storyRepository.GetTopStories();

            Assert.AreEqual(20, stories.Count());
        }

        [TestMethod]
        public void TestStoryAuthor()
        {
            var storyRepository = new StoryRespository();
            var story = storyRepository.GetStory(17357319);

            Assert.AreEqual("samlambert", story.by);
        }

    }
}
