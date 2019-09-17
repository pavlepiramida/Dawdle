using Dawdle.Database.Models;

namespace Dawdle.Core.DTO
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
