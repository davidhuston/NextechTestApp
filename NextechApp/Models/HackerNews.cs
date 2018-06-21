using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace NextechApp.Models
{
    public class HackerNews
    {
        private const string baseUrl = "https://hacker-news.firebaseio.com/v0/";
        private const string topStories = "topstories.json?print=pretty";

        public IEnumerable<int> GetTopStories()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl + topStories);
            request.ContentType = "application/json charset=utf-8";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Stream responseStream = response.GetResponseStream();

            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(IEnumerable<int>));

            IEnumerable<int> stories = (IEnumerable<int>)dataContractJsonSerializer.ReadObject(responseStream);

            return stories;
        }

        public Story GetStory(int id)
        {
            Story story = new Story();

            string url = $"{baseUrl}item/{id}.json?print.pretty";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json charset=utf-8";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Stream responseStream = response.GetResponseStream();

            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Story));

            story = (Story)dataContractJsonSerializer.ReadObject(responseStream);

            return story;
        }
    }
}