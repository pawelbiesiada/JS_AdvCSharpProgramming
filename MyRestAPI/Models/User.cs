using System.Text.Json.Serialization;

namespace MyRestAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        [JsonIgnore]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }

    //AutoMapper   mapper.Map<User, UserDto>()
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
