using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfDraft2.Data;
using GolfDraft2.Models;
using System.Security.Claims;
using GolfDraft2.Services;

namespace GolfDraft2.Controllers
{
    public class DraftsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public DraftsController(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }


        public async Task<IActionResult> Draft()
        {
            Draft d = new Draft();
            d.DraftName = "First";
            d.Players = await _context.Players.ToListAsync();
            //d.Players = await _dataService.FetchPlayers();
            //await _context.AddRangeAsync(d.Players);
            //await _context.SaveChangesAsync();
            d.MyTeam = new MyTeam
            {
                Name = User.FindFirstValue(ClaimTypes.Name),
                UserID = User.FindFirstValue(ClaimTypes.NameIdentifier),
                FantasyLeagueID = 1,
                Players = new List<Player>()
            };
            return View(d);
        }
    }
}
