using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NarutoAPI.Data;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NarutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanController : Controller
    {
        private static List<Clan> clans = new List<Clan>
        {
            new Clan {
                ClanId = 1,
                ClanName = "Uchiha"
            } 
        };
        [HttpGet]
        public async Task<ActionResult<List<Clan>>> Get()
        {
            return Ok(clans);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Clan>> Get(int id)
        {
            var clan = clans.Find(h => h.ClanId == id);
            if(clan == null)
            {
                return BadRequest("Clan Not Found!!!");
            }
            return Ok(clan);
        }
        [HttpPost]
        public async Task<ActionResult<List<Clan>>> AddClan(Clan clan)
        {
            clans.Add(clan);
            return Ok(clans);
        }
        [HttpPut]
        public async Task<ActionResult<List<Clan>>> UpdateClan(Clan clan_)
        {
            var clan = clans.Find(h => h.ClanId == clan_.ClanId);
            if(clan == null)
            {
                return BadRequest("No such character found.");
            }
            clan.ClanName = clan_.ClanName;
            return Ok(clans);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Character>> DeleteClan(int id)
        {
            var clan = clans.Find(h => h.ClanId == id);
            if(clan == null)
            {
                return BadRequest("No Deletion Needed");
            }
            clans.Remove(clan);
            return Ok(clans);

        }
    }
    
}

