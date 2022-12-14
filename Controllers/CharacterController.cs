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
    //character is the general character
    //shinobi means ninja in the ninjaworld of Naruto!!!!
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;
        public CharacterController(DataContext context) {
            _context = context; 
        }
        /*
        This is for visualization purposes
        private static List<Character> characters = new List<Character>
            {
                new Character {
                    CharacterId = 1,
                    CharacterName = "Naruto Uzumaki",
                    Gender = "Male",
                    //Clan = "Uzumaki"
                },
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
        */
        [HttpGet]
        public async Task<ActionResult<List<Response>>> Get()
        {

            var myCharacterList = await _context.Characters.ToListAsync();
            var myClanList = await _context.Clans.ToListAsync();
            myCharacterList.ForEach(c => c.ClanName = myClanList.Single(h => h.ClanId == c.ClanId).ClanName);
            Response response = new Response();
            response.charactersList = myCharacterList;
            response.statusCode = 200;
            response.statusDescription = "Success!";
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(int id)
        {
            try
            {
                Response response = new Response();
                var character = await _context.Characters.SingleAsync(h => h.CharacterId == id);
                var clanName = (await _context.Clans.SingleAsync(h => h.ClanId == character.ClanId)).ClanName;
                character.ClanName = clanName;
                List<Character> characterlist = new List<Character>();
                characterlist.Add(character);
                response.statusCode = 200;
                response.statusDescription = "Success!";
                response.charactersList = characterlist;
                return Ok(response);
            }
            catch(Exception error)    
            {

                Response response = new Response();
                response.statusCode = BadRequest().StatusCode;
                response.statusDescription = error.Message + " Error: Out of Bounds";
                //var jsonResponse = JsonSerializer.Serialize<Response>(response);
                return Ok(response);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Response>>> AddCharacter(Character shinobi)
        {
            //Used to add Naruto Characters
            Response response = new Response();
            try
            {
                _context.Characters.Add(shinobi);
                await _context.SaveChangesAsync();
                response.statusCode = 201;
                response.statusDescription = "Successfully Added New Character!";
                response.charactersList = await _context.Characters.ToListAsync();
                return Ok(response);
            }
            catch(Exception error)
            {
                //Response response = new Response();
                response.statusCode = BadRequest().StatusCode;
                response.statusDescription = error.Message + " Error: shinobi attributes may be causing the error... check id and clan";
                //var jsonResponse = JsonSerializer.Serialize<Response>(response);
                return Ok(response);
            }
        }
        [HttpPut]
        public async Task<ActionResult<List<Response>>> UpdateCharacter(Character shinobi)
        {
            Response response = new Response();
            try
            {
                var character = await _context.Characters.FindAsync(shinobi.CharacterId);
                character.CharacterId = shinobi.CharacterId;
                character.CharacterName = shinobi.CharacterName;
                character.Gender = shinobi.Gender;
                character.ClanId = shinobi.ClanId;
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Successfully Updated Character!";
                response.charactersList = await _context.Characters.ToListAsync();
                return Ok(response);
            }
            catch(Exception error)
            {
                //Response response = new Response();
                response.statusCode = BadRequest().StatusCode;
                response.statusDescription = error.Message + " Error: id request body does not exist or shinobi.ClanId does not exist...cannot find character to update!";
                //var jsonResponse = JsonSerializer.Serialize<Response>(response);
                return BadRequest(response);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            Response response = new Response();
            try
            {
                var character = await _context.Characters.FindAsync(id);
                //if (character == null)
                //{
                //    return BadRequest("No Deletion Needed.. Character Not Found!!!");
                //}
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Successfully Deleted Character!";
                response.charactersList = await _context.Characters.ToListAsync();
                return Ok(response);
            }
            catch(Exception error)
            {
                //Response response = new Response();
                response.statusCode = BadRequest().StatusCode;
                response.statusDescription = error.Message + " Error: Parameter id out of bounds or character already doesn't exit!";
                //var jsonResponse = JsonSerializer.Serialize<Response>(response);
                return BadRequest(response);
            }
        }
       

    }
}

