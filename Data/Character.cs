using System;
namespace NarutoAPI.Data
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        //public Clan? Clan { get; set; }
    }
}

