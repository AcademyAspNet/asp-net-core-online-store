using OnlineStore.Data.Models;
using OnlineStore.Models.DTO;

namespace OnlineStore.Services
{
    public interface IUserService
    {
        public User? GetUserById(long id);
        public void RegisterUser(UserDTO userDTO);
    }
}
