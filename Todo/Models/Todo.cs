using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Todo
/// </summary>

namespace Todo.Models
{
    public class Post
    {
        public int userId;
        public int id;
        public string title;
        public string body;

        public Post()
        {
            title = "";
            body = "";

        }
        public Post(int userIdinput, int idinput, string titleinput, string bodyinput)
        {
            userId = userIdinput;
            id = idinput;
            title = titleinput;
            body = bodyinput;
        }        
    }
    public static class Postgetter
    {
        public static List<Post> GetPosts()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/posts");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var postlist = JsonConvert.DeserializeObject<List<Post>>(reader.ReadToEnd());
                return postlist;
            }
        }
    }

}

