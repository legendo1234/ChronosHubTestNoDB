using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChronosHubTestNoDB.Data;
using ChronosHubTestNoDB.Models;
using System.Linq;

//used some linq here just to show it .

namespace ChronosHubTestNoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IAcademicRepository _repo;

        public ArticlesController(IAcademicRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public ActionResult<Article> Get(int id)
        {
            var result = from article in _repo.GetAllArticles()
                         where article.Id == id
                         select article;

            var articleFound = result.FirstOrDefault();
            if (articleFound == null) return NotFound();
            return Ok(articleFound);
        }

        [HttpGet("byAuthor/{authorId}")]
        public ActionResult<IEnumerable<Article>> ByAuthor(int authorId)
        {
            var result = from article in _repo.GetAllArticles()
                         where (from author in article.Authors
                                where author.Id == authorId
                                select author).Any()
                         select article;

            return Ok(result);
        }

        [HttpGet("byJournal/{journalId}")]
        public ActionResult<IEnumerable<Article>> ByJournal(int journalId)
        {
            var result = from article in _repo.GetAllArticles()
                         where article.Journal.Id == journalId
                         select article;

            return Ok(result);
        }

        // POST api/articles , in case i will need to make post requests in the future
        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            var _repo = new AcademicRepository(); // Assuming you have a way to add articles in your repository

            // Get the next ID manually
            //var maxId = repo.GetAllArticles().Max(a => a.Id);
            //newArticle.Id = maxId + 1;

            //Dont know why i tried to overy complicate linq, should just use qurries tbh

            return CreatedAtAction(nameof(Get), new { id = article.Id }, article);
        }
    }
}
