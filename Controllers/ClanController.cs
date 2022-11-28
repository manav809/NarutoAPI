//Manav Minesh Patel
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NarutoAPI.Models;
using System.Text.Json;
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
        /*
        This is for visualization purposes

        private static List<Character> characters = new List<Character>
        {
                new Character{
                    CharacterId = 2,
                    CharacterName = "Sasuke Uchiha",
                    Gender = "Male",
                    ClanId = 1,
                    ClanName = "Uchiha"
                },
                new Character
                {
                    CharacterId = 3,
                    CharacterName = "Itachi Uchiha",
                    Gender = "Male",
                    ClanId = 1,
                    ClanName = "Uchiha"
                }
        };
        
        private static List<Clan> clans = new List<Clan>
        {
            new Clan {
                ClanId = 1,
                ClanName = "Uchiha",
                ClanCharacters = characters
            } 
        };
        */
        [HttpGet]
        public async Task<ActionResult<List<Response>>> Get()
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
            Response response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Success!";
            response.clansList = myClansList;
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(int id)
        {
            Response response = new Response();
            try
            {
                var clan = await _context.Clans.SingleAsync(h => h.ClanId == id);
                var clanCharacters = await _context.Characters
                            .Where(c => c.ClanId == id)
                            .ToListAsync();
                clan.ClanCharacters = clanCharacters;
                response.statusCode = 200;
                response.statusDescription = "Success!";
                List<Clan> clanList = new List<Clan>();
                clanList.Add(clan);
                response.clansList = clanList;
                return Ok(response);
            }
            catch(Exception error)
            {
                //Response response = new Response();
                response.statusCode = BadRequest().StatusCode;
                response.statusDescription = error.Message + "Error: Out of Bounds";
                var jsonResponse = JsonSerializer.Serialize<Response>(response);
                return BadRequest(response);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Response>>> AddClan(Clan clan)
        {
            Response response = new Response();
            try
            {
                var myClanList = await _context.Clans.ToListAsync();
                var clanCount = myClanList.Count() + 1;
                if(clan.ClanId != clanCount)
                {
                    //Exception error;
                    response.statusCode = BadRequest().StatusCode;
                    response.statusDescription = "Error: Undefined or Bad Request Body...Try the next ClanId";
                    var jsonResponse = JsonSerializer.Serialize<Response>(response);
                    return Ok(response);
                }
                //clan.ClanId = clanCount;
                _context.Clans.Add(clan);
                await _context.SaveChangesAsync();
                response.statusCode = 201;
                response.statusDescription = "Successfully Added Clan!";
                response.clansList = await _context.Clans.ToListAsync();
                return Ok(response);
            }
            catch(Exception error)
            {
                //Response response = new Response();
                response.statusCode = BadRequest().StatusCode;
                response.statusDescription = error.Message + "Error: Undefined Request Body, Try the next ClanId";
                var jsonResponse = JsonSerializer.Serialize<Response>(response);
                return Ok(response);
            }
            //clans.Add(clan);
            //return Ok(clans);
        }
        [HttpPut]
        public async Task<ActionResult<List<Response>>> UpdateClan(Clan clan_)
        {
            Response response = new Response();
            try
            {
                var clan = await _context.Clans.FindAsync(clan_.ClanId);
                //if(clan == null)
                //{
                //    return BadRequest("No such character found.");
                //}
                clan.ClanName = clan_.ClanName;
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Successfully Updated Clan!";
                response.clansList = await _context.Clans.ToListAsync();
                return Ok(response);
            }
            catch(Exception error)
            {
                //Response response = new Response();
                response.statusCode = BadRequest().StatusCode;
                response.statusDescription = error.Message + "Error: id in request body does not exist.";
                var jsonResponse = JsonSerializer.Serialize<Response>(response);
                return Ok(response);
            }
        }
        
        //Deletion not necessary as this is a parent

        [HttpDelete("{id}")]
        public async Task<ActionResult<Clan>> DeleteClan(int id)
        {
            var clan = await _context.Clans.FindAsync(id);
            if(clan == null)
            {
                return BadRequest("No Deletion Needed");
            }
            _context.Clans.Remove(clan);
            await _context.SaveChangesAsync();
            return Ok(await _context.Clans.ToListAsync());
        }
        
    }

}

