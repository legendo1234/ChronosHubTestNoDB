using System;
using System.Collections.Generic;
using System.Linq; // Make sure to include this for LINQ
using ChronosHubTestNoDB.Models;

namespace ChronosHubTestNoDB.Data
{
    public class AcademicRepository : IAcademicRepository
    {
        private List<Journal> _journals = new()
        {
            new Journal { Id = 1, Name = "Danish Journal", Issn = "0001-1234", Publisher = "Aarhus" }
        };

        private List<Author> _authors = new()
        {
            new Author { Id = 1, FirstName = "Nemo", LastName = "Jensen", Affiliation = "Københavns University" },
            new Author { Id = 2, FirstName = "Mads", LastName = "Andersen", Affiliation = "Aalborg University" }
        };

        private List<Article> _articles = new();

        public AcademicRepository()
        {
            _articles.Add(new Article
            {
                Id = 1,
                Title = "Do we love data science.",
                Abstract = "Is data science cool or is cloud cooler.",
                PublicationDate = DateTime.UtcNow.Date,
                Journal = _journals[0],
                Authors = new List<Author> { _authors[0], _authors[1] }
            });
        }

        public Article? GetArticle(int id)
        {
            var result = from article in _articles
                         where article.Id == id
                         select article;

            return result.FirstOrDefault();
        }

        public IEnumerable<Article> GetByAuthor(int authorId)
        {
            var result = from article in _articles
                         where (from author in article.Authors
                                where author.Id == authorId
                                select author).Any()
                         select article;

            return result;
        }

        public IEnumerable<Article> GetByJournal(int journalId)
        {
            var result = from article in _articles
                         where article.Journal.Id == journalId
                         select article;

            return result;
        }

        public void AddArticle(Article article)
        {
            _articles.Add(article);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _articles;
        }
    }
}
