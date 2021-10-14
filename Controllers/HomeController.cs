using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.AtlanticSoccer = _context.Teams
                .Include(team => team.CurrLeague)
                .Where(atl => atl.CurrLeague.Name.Contains("Atlantic Soccer Conference"))
                .ToList();
            ViewBag.BoPenPlayers = _context.Players
                .Include(team => team.CurrentTeam)
                .Where(bopen => bopen.CurrentTeam.Location.Contains("Boston") && bopen.CurrentTeam.TeamName.Contains("Penguins"))
                .ToList();
            ViewBag.ICBC = _context.Players
                .Include(team => team.CurrentTeam)
                .ThenInclude(lea => lea.CurrLeague)
                .Where(fin => fin.CurrentTeam.CurrLeague.Name.Contains("International Collegiate Baseball Conference"))
                .ToList();
            ViewBag.Lop = _context.Players
                .Include(team => team.CurrentTeam)
                .ThenInclude(lea => lea.CurrLeague)
                .Where(fin => fin.CurrentTeam.CurrLeague.Name.Contains("American Conference") && fin.LastName.Contains("Lopez"))
                .ToList();
            ViewBag.foot = _context.Players
                .Include(team => team.CurrentTeam)
                .ThenInclude(lea => lea.CurrLeague)
                .Where(fin => fin.CurrentTeam.CurrLeague.Sport.Contains("Football"))
                .ToList();
            ViewBag.soph = _context.Teams
                .Include(team => team.CurrentPlayers)
                .Where(team => team.CurrentPlayers.Any(play => play.FirstName == "Sophia"))
                .ToList();
            ViewBag.SophiaL= _context.Leagues
                .Include(leag => leag.Teams)
                .ThenInclude(tea => tea.CurrentPlayers)
                .Where(lea => lea.Teams.Any(tea => tea.CurrentPlayers.Any(play => play.FirstName == "Sophia")))
                .ToList();
            ViewBag.Flores = _context.Players
                .Include(team => team.CurrentTeam)
                .Where(bopen => !bopen.CurrentTeam.Location.Contains("Washington") && !bopen.CurrentTeam.TeamName.Contains("Roughriders") && bopen.LastName.Contains("Flores"))
                .ToList();
            

            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            ViewBag.Sam = _context.Players
                .Include(play => play.CurrentTeam)
                .Include(player => player.AllTeams)
                .ThenInclude(pt => pt.TeamOfPlayer)
                .FirstOrDefault(play => play.FirstName == "Samuel" && play.LastName == "Evans");
            ViewBag.Manitoba = _context.Teams
                .Include(team => team.AllPlayers)
                .ThenInclude(p => p.PlayerOnTeam)
                .Where(team => team.Location.Contains("Manitoba"))
                .ToList();


            return View();
        }

    }
}