using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreTravels.ViewModels;
using CoreTravels.Services;
using Microsoft.Extensions.Configuration;
using CoreTravels.Models;

namespace CoreTravels.Controllers.web
{
    public class AppController : Controller
    {
        private IMailService _mailServices;
        private IConfigurationRoot _config;
        private ICoreTravelsContext _repostiory;

        public AppController(IMailService mailService, IConfigurationRoot config, ICoreTravelsContext repostiory)
        {
            _mailServices = mailService;
            _config = config;
            _repostiory = repostiory;
        }

        public IActionResult Index()
        {
            var data = _repostiory.Trips.ToList();
            return View(data);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailServices.SendMail(_config["MailSettings:toAddress"], model.Email, "", model.Message);
                return View("index");
            }

            return View();            
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
