using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace NarutoAPI.Data
{
    public class Response
    {
        [NotMapped]
        public int? statusCode { get; set; }
        [NotMapped]
        public string? statusDescription { get; set; }
        [NotMapped]
        public List<Character>? charactersList { get; set; }
        [NotMapped]
        public List<Clan>? clansList { get; set; }
    }
}

