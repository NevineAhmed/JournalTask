using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Models;
using Inferastructure.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JournalTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        //private readonly IunitOfWork _uow;
        private readonly Ireposatory<Article> _repo;
        private readonly IHttpContextAccessor httpContextAccessor;
        public JournalDbcontext Context { get; set; }
        public ArticleController( Ireposatory<Article> repo, JournalDbcontext _Context)
        {
            // _uow = uow;
         //   httpContextAccessor = _httpContextAccessor;
             _repo = repo;
            Context = _Context;
        }
        [HttpGet]
        [Route("All")]
        public IActionResult AllArticles()
        {
            // userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            //var list = _repo.Get().OrderByDescending(a => a.author_name == userName);
            return Ok(_repo.Get().ToList());
        }
        [HttpPost]
        [Route("AddArticle")]
        public IActionResult AddArticle(Article entity)
        {
            if (ModelState.IsValid)
            {
                //var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                //var user=  Context.users.FirstOrDefault(a => a.Id == userId);
                //user.NoOfPublishes++;

                

                entity.publish_time = DateTime.Now.ToString();
                entity.published = false;
                _repo.Add(entity);
                Context.SaveChanges();
                return Ok();
            }
            return BadRequest("the data is not valid");


        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("getOneArt/{id}")]
        public IActionResult getOneArticl(int id)
        {
           Article art= _repo.Get().FirstOrDefault(a => a.id == id);
            if (art != null)
            {
                return Ok(art);
            }
            else
            {
                return BadRequest("Not Found");
            }
            
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("updateArticle")]
        public IActionResult updateArticle(Article entity)
        {
            if (ModelState.IsValid)
            {
                Article art = _repo.Get().FirstOrDefault(e => e.id == entity.id);
                art.title = entity.title;
                art.description = entity.description;
                art.published = entity.published;
                art.publish_time = entity.publish_time;
                art.author_name = entity.author_name;

                Context.SaveChanges();


                return Ok(entity);
            }
            return BadRequest("Not found before");

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("deleteArticle/{id}")]
        public IActionResult deleteArticle(int id)
        {
            Article art = _repo.Get().FirstOrDefault(e => e.id == id);
            if (art != null)
            {
                _repo.Delete(art);
                Context.SaveChanges();
                return Ok();
            }
            return BadRequest("Not found before");

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("updatePublished/{id}")]
        public IActionResult updatePublished(int id)
        {
            Article art = _repo.Get().FirstOrDefault(e => e.id == id);
            if (art != null)
            {
                art.published = !art.published;
                Context.SaveChanges();
                //_uow.Commit();
                return Ok(art);
            }
            return BadRequest("Not found");

        }



    }
}
