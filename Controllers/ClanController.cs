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
    public class ClanController : ControllerBase
    {
        private readonly DataContext _context;
        public ClanController(DataContext context)
        {
            _context = context;
        }
        private static List<Character> characters = new List<Character>
        {
                new Character{
                    CharacterId = 2,
                    CharacterName = "Sasuke Uchiha",
                    Gender = "Male",
                    //Clan = "Uchiha"
                },
                new Character
                {
                    CharacterId = 3,
                    CharacterName = "Itachi Uchiha",
                    Gender = "Male",
                    //Clan = "Uchiha"
                }
        };
        private static List<Clan> clans = new List<Clan>
        {
            new Clan {
                ClanId = 1,
                ClanName = "Uchiha",
                //ClanCharacters = characters
            } 
        };
        [HttpGet]
        public async Task<ActionResult<List<Clan>>> Get()
        {
            var myClansList = await _context.Clans.ToListAsync(); //List<Clan>
            var myCharacterList = await _context.Characters.ToListAsync();//List<Character>
            int ClanSize = myClansList.Count + 1;
            for(int id = 1; id < ClanSize; id++)
            {
                var clan = await _context.Clans.SingleAsync(h => h.ClanId == id);
                var clanCharacters = await _context.Characters
                                     .Where(c => c.ClanId == id)
                                     .ToListAsync();
                clan.ClanCharacters = clanCharacters;
            }
            //myClansList.ForEach(c => c.ClanId == myCharacterList.ForEach(h => h.ClanId == c.ClanId)
            //for(int i = 0; i < )
            //List<string> clanMembers = new List<string>();
            //var myCharacterList = await _context.Characters.ToListAsync();
            //myClansList.ForEach(c => c.ClanName == ); 
            return myClansList;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Clan>> Get(int id)
        {
            var clan = await _context.Clans.SingleAsync(h => h.ClanId == id);
            var clanCharacters = await _context.Characters
                        .Where(c => c.ClanId == id)
                        .ToListAsync();
            //var potentialClanList = await _context.Characters.ToListAsync().;
            clan.ClanCharacters = clanCharacters;
            if(clan == null)
            {
                return BadRequest("Clan Not Found!!!");
            }
            return Ok(clan);
        }
        [HttpPost]
        public async Task<ActionResult<List<Clan>>> AddClan(Clan clan)
        {
            _context.Clans.Add(clan);
            await _context.SaveChangesAsync();
            return Ok(await _context.Clans.ToListAsync());

            //clans.Add(clan);
            //return Ok(clans);
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

