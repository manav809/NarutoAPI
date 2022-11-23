//Manav Minesh Patel
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NarutoAPI.Controllers
{
    //character is the general character
    //shinobi means ninja in the ninjaworld of Naruto!!!!
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : Controller
    {
        private static List<Character> characters = new List<Character>
            {
                new Character {
                    Id = 1,
                    Name = "Naruto Uzumaki",
                    Gender = "Male",
                    Clan = "Uzumaki"
                },
                new Character{
                    Id = 2,
                    Name = "Sasuke Uchiha",
                    Gender = "Male",
                    Clan = "Uchiha"
                }
            };
        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get()
        {

            return Ok(characters);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> Get(int id)
        {
            var character = characters.Find(h => h.Id == id);
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
            characters.Add(shinobi);
            return Ok(characters);
        }
        [HttpPut]
        public async Task<ActionResult<List<Character>>> UpdateCharacter(Character shinobi)
        {
            var character = characters.Find(h => h.Id == shinobi.Id);
            if (character == null)
            {
                return BadRequest("No such character found.");
            }
            character.Name = shinobi.Name;
            character.Gender = shinobi.Gender;
            character.Clan = shinobi.Clan;

            return Ok(characters);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Character>> Delete(int id)
        {
            var character = characters.Find(h => h.Id == id);
            if(character == null)
            {
                return BadRequest("No Deletion Needed.. Character Not Found!!!");
            }
            characters.Remove(character);
            return Ok(character);
        }

    }
}

