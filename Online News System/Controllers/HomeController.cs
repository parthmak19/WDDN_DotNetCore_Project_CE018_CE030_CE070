using Microsoft.AspNetCore.Mvc;
using Online_News_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_News_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly INewsRepository _newsRepository;

        public HomeController(IUserRepository userRepository, INewsRepository newsRepository)
        {
            _userRepository = userRepository;
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            var model = _newsRepository.GetAllNews();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
