using System;
using System.Collections.Generic;
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
            foreach (var article in _articles)
            {
                if (article.Id == id)
                    return article;
            }
            return null;
        }

        public IEnumerable<Article> GetByAuthor(int authorId)
        {
            List<Article> result = new();
            foreach (var article in _articles)
            {
                foreach (var author in article.Authors)
                {
                    if (author.Id == authorId)
                    {
                        result.Add(article);
                        break;
                    }
                }
            }
            return result;
        }

        public IEnumerable<Article> GetByJournal(int journalId)
        {
            List<Article> result = new();
            foreach (var article in _articles)
            {
                if (article.Journal.Id == journalId)
                {
                    result.Add(article);
                }
            }
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
