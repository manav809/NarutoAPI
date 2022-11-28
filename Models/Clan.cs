using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NarutoAPI.Models
{
    public class Clan
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; } = string.Empty;
        [NotMapped]
        //[JsonIgnore]
        public List<Character> ClanCharacters { get; set; } = null!;
    }
}

