using DutchTreat.Data;
using DutchTreat.Models;
using DutchTreat.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDutchRepository _repo;


        public AppController(IMailService mailService, IDutchRepository repo)
        {
            _mailService = mailService;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var results = _repo.GetAllProducts();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                _mailService.SendMessage( "buzznode@yahoo.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}" );
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repo.GetAllProducts();

            return View(results);
        }
    }
}
