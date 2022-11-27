using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NarutoAPI.Data
{
    public class Clan
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; } = string.Empty;
        [NotMapped]
        public List<Character> ClanCharacters { get; set; } = null!;
    }
}

