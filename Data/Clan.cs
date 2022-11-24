using System;
namespace NarutoAPI.Data
{
    public class Clan
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; } = string.Empty;
        //public int CharacterId { get; set; }
        public List<Character> ClanCharacters { get; set; } = null!;
    }
}

