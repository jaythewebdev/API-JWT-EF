
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models.DTO
{
    public class UserRegisterDTO:User
    {
        [MinLength(6,ErrorMessage ="Password should be of minimum 6 characters")]
        public string PasswordClear { get; set; }

    }
}
