using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NarutoAPI.Data
{
    public class Character
    {
        //[JsonIgnore]
        public int CharacterId { get; set; }
        public string CharacterName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int ClanId { get; set; }
        [NotMapped]
        //[JsonIgnore]
        public string ClanName { get; set; }
        //[NotMapped]
        //[JsonIgnore]
        //public Response response { get; set; }

        //public Clan? CharacterClan { get; set; }
    }
}

