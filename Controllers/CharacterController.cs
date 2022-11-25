//Manav Minesh Patel
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NarutoAPI.Data;
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
        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get()
        {

            var myCharacterList = await _context.Characters.ToListAsync();
            var myClanList = await _context.Clans.ToListAsync();
            myCharacterList.ForEach(c => c.ClanName = myClanList.Single(h => h.ClanId == c.ClanId).ClanName);
            return myCharacterList;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> Get(int id)
        {
            var character = await _context.Characters.SingleAsync(h => h.CharacterId == id);
            var clanName = (await _context.Clans.SingleAsync(h => h.ClanId == character.ClanId)).ClanName;
            character.ClanName = clanName;
            if(character == null)
            {
                return BadRequest("Character Not Found! Try another.");
            }
            return Ok(character);
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character shinobi)
        { 
            //Used to add Naruto Characters
            _context.Characters.Add(shinobi);
            await _context.SaveChangesAsync();
            return Ok(await _context.Characters.ToListAsync());/*CreatedAtAction("GetCharacter", new { id = shinobi.CharacterId }, shinobi);*/
        }
        [HttpPut]
        public async Task<ActionResult<List<Character>>> UpdateCharacter(Character shinobi)
        {
            var character = await _context.Characters.FindAsync(shinobi.CharacterId);
            if (character == null)
            {
                return BadRequest("No such character found.");
            }
        
            character.CharacterId = shinobi.CharacterId;
            character.CharacterName = shinobi.CharacterName;
            character.Gender = shinobi.Gender;
            character.ClanId = shinobi.ClanId;
            await _context.SaveChangesAsync();
            return Ok(await _context.Characters.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Character>> Delete(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if(character == null)
            {
                return BadRequest("No Deletion Needed.. Character Not Found!!!");
            }
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return Ok(await _context.Characters.ToListAsync());
        }

    }
}

