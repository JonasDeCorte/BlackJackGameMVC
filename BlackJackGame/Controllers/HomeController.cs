using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJackGame.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace BlackJackGame.Controllers
{
    
    public class HomeController : Controller
    {   private BlackJack _blackjack;
        public IActionResult Index()
        {
            _blackjack = new BlackJack();
            // serializeren van object 
            HttpContext.Session.SetString("bj", JsonConvert.SerializeObject(_blackjack));
                 
            return View(_blackjack);
        }
        public IActionResult NextCard() {
            // deserializeren van object 
            _blackjack = JsonConvert.DeserializeObject<BlackJack>(HttpContext.Session.GetString("bj"));
            _blackjack.GivePlayerAnotherCard();
            // serializeren van object 
            HttpContext.Session.SetString("bj", JsonConvert.SerializeObject(_blackjack));
            return View("Index",_blackjack);
        }
        public IActionResult Pass()
        {
            // deserializeren van object 
            _blackjack = JsonConvert.DeserializeObject<BlackJack>(HttpContext.Session.GetString("bj"));
            _blackjack.PassToDealer();
            // serializeren van object 
            HttpContext.Session.SetString("bj", JsonConvert.SerializeObject(_blackjack));
            return View("Index", _blackjack);
        }
    }
}
