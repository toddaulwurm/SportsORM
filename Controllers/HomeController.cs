using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();

            
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(wom => wom.Name.Contains("Women"))
                .ToList();
            ViewBag.Hockey = _context.Leagues
                .Where(hock => hock.Sport.Contains("Hockey"))
                .ToList();
            ViewBag.NoFoot = _context.Leagues
                .Where(nofoot => !nofoot.Sport.Contains("Football"))
                .ToList();
            ViewBag.Conference = _context.Leagues
                .Where(conf => conf.Name.Contains("Conference"))
                .ToList();
            ViewBag.Atlantic = _context.Leagues
                .Where(atl => atl.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.Dallas = _context.Teams
                .Where(dal => dal.Location.Contains("Dallas"))
                .ToList();
            ViewBag.Raptors = _context.Teams
                .Where(rap => rap.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.City = _context.Teams
                .Where(rap => rap.Location.Contains("City"))
                .ToList();
            ViewBag.TTitle = _context.Teams
                .Where(tt => tt.TeamName.Contains("T"))
                .ToList();
            ViewBag.Abc = _context.Teams
                .OrderBy(abc => abc.Location)
                .ToList();           
            ViewBag.Cba = _context.Teams
                .OrderBy(cba => cba.TeamName)
                .ToList();
            ViewBag.Cba.Reverse();
            ViewBag.Cooper = _context.Players
                .Where(coop => coop.LastName.Contains("Cooper"))
                .ToList();
            ViewBag.Joshua = _context.Players
                .Where(josh => josh.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.CooperNoJ = _context.Players
                .Where(coop => coop.LastName.Contains("Cooper")).Where(josh => !josh.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.AW = _context.Players
                .Where(name => name.FirstName.Contains("Alexander") || name.FirstName.Contains("Wyatt"))
                .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}