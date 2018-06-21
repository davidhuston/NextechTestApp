using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NextechApp.Models
{
    public class StoryRespository
    {
        private int displayMax = 20;
        private int fetchMax = 100;

        public List<Story> GetTopStories()
        {
            List<Story> topStories = new List<Story>();

            var stories = GetAllTopStories();

            int max = stories.Count > displayMax ? displayMax : stories.Count;

            for (int i = 0; i < max; i++)
            {
                topStories.Add(GetStory(stories[i]));
            }

            return topStories;
        }

        public List<Story> GetTopStories(string search)
        {
            List<Story> topStories = new List<Story>();

            var stories = GetAllTopStories();

            int i = 0;
            while (topStories.Count < displayMax && i < stories.Count)
            {
                var story = GetStory(stories[i]);
                if (story.title.ToUpper().Contains(search.ToUpper()))
                {
                    topStories.Add(story);
                }
                i++;
            }

            return topStories;
        }

        public Story GetStory(int id)
        {
            Story story = new Story();

            HackerNews hacker = new HackerNews();
            story = hacker.GetStory(id);

            return story;
        }

        private List<int> GetAllTopStories()
        {
            List<int> topStories = new List<int>();

            HackerNews hacker = new HackerNews();

            List<int> stories = hacker.GetTopStories().ToList();

            int max = stories.Count > fetchMax ? fetchMax : stories.Count;

            for (int i = 0; i < max; i++)
            {
                topStories.Add(stories[i]);
            }

            return topStories;
        }

    }
}