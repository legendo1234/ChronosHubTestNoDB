using System.Collections.Generic;
using ChronosHubTestNoDB.Models;

namespace ChronosHubTestNoDB.Data
{
    public interface IAcademicRepository
    {
        Article? GetArticle(int id);
        IEnumerable<Article> GetByAuthor(int authorId);
        IEnumerable<Article> GetByJournal(int journalId);
        void AddArticle(Article article);
        IEnumerable<Article> GetAllArticles(); // Added for POST ID Function
    }
}
