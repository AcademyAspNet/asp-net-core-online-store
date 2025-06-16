using OnlineStore.Data;
using OnlineStore.Data.Models;
using OnlineStore.Models.DTO;

namespace OnlineStore.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _database;

        public UserService(ApplicationDbContext database)
        {
            _database = database;
        }

        public User? GetUserById(long id)
        {
            return _database.Users.First();
        }

        public void RegisterUser(UserDTO userDTO)
        {
            if (userDTO.Email == null)
                throw new ArgumentNullException("User email is not specified");

            if (userDTO.FirstName == null)
                throw new ArgumentNullException("User first name is not specified");

            if (userDTO.Password == null)
                throw new ArgumentNullException("User password is not specified");

            User user = new User()
            {
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Password = userDTO.Password
            };

            _database.Users.Add(user);
            _database.SaveChanges();
        }
    }
}
