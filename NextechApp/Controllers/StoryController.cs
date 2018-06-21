using NextechApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NextechApp.Controllers
{
    public class StoryController : ApiController
    {
        // GET: api/News
        public List<Story> GetStories()
        {
            StoryRespository storyRepository = new StoryRespository();
            List<Story> stories = storyRepository.GetTopStories();
            return stories;
        }

        public List<Story> GetStories(string search)
        {
            StoryRespository storyRepository = new StoryRespository();
            List<Story> stories = storyRepository.GetTopStories(search);
            return stories;
        }

        // GET: api/News/5
        public Story GetStory(int id)
        {
            return new Story();
        }

    }
}
