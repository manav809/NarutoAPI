using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NarutoAPI.Data
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int ClanId { get; set; }
        [NotMapped]
        public string ClanName { get; set; }
        //public Clan? CharacterClan { get; set; }
    }
}

