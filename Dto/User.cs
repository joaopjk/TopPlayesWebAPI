using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Dto
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
