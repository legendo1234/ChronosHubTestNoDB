using System;
using System.Collections.Generic;

namespace ChronosHubTestNoDB.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Abstract { get; set; } = "";
        public DateTime PublicationDate { get; set; }
        public Journal Journal { get; set; } = new Journal();
        public List<Author> Authors { get; set; } = new List<Author>();
    }

}
