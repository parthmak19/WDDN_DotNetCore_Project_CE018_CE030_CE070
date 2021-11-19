using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_News_System.Models;
using Online_News_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_News_System.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;

        public NewsController( INewsRepository newsRepository)
        {     
            _newsRepository = newsRepository;
        }

        //[AllowAnonymous]
        public IActionResult Index()
        {
            var model = _newsRepository.GetAllNews();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Create(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                News news = new News
                {
                    Title = model.Title,
                    Description = model.Description
                };
                _newsRepository.AddNews(news);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        //[Authorize]
        public ViewResult Edit(int id)
        {
            News news = _newsRepository.GetNews(id);
            NewsViewModel newsViewModel = new NewsViewModel
            {
                Title = news.Title,
                Description = news.Description
        };
            return View(newsViewModel);
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Edit(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                News news = _newsRepository.GetNews(model.id);
                news.Title = model.Title;
                news.Description = model.Description;
                News updatedNews = _newsRepository.UpdateNews(news);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        //[AllowAnonymous]
        public ViewResult Details(int id)
        {
            News news = _newsRepository.GetNews(id);
            if (news == null)
            {
                Response.StatusCode = 404;
                return View("StaffNotFound", id);
            }
            return View(news);
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Delete(int id)
        {
            News news = _newsRepository.GetNews(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }
        [HttpPost, ActionName("Delete")]
        //[Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            var news = _newsRepository.GetNews(id);
            _newsRepository.DeleteNews(news.Id);
            return RedirectToAction("Index");
        }

    }
}
