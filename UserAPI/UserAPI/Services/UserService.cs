using System.Security.Cryptography;
using System.Text;
using UserAPI.Interfaces;
using UserAPI.Models.DTO;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService
    {
        private IUser<int, User> _repo;
        private ITokenGenerate _tokenService;

        public UserService(IUser<int, User> repo, ITokenGenerate tokenGenerate)
        {
            _repo = repo;
            _tokenService = tokenGenerate;
        }

        //Method for Login
        public UserDTO Login(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = _repo.Get(userDTO.UserId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.HashKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.UserId = userDTO.UserId;
                user.Username = userData.Username;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

        //Method for registration
        public UserDTO Register(UserRegisterDTO userDTO)
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            userDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.PasswordClear));
            userDTO.HashKey = hmac.Key;
            var resultUser = _repo.Add(userDTO);
            if (resultUser != null)
            {
                user = new UserDTO();
                user.UserId = resultUser.UserId;
                user.Username = resultUser.Username;
                user.Role = resultUser.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
    }
}
