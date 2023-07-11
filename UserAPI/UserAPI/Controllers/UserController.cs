using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Exceptions.CustomExceptions;
using UserAPI.Models;
using UserAPI.Models.DTO;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost("Register User")]
        [ProducesResponseType(typeof(ICollection<UserDTO>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> Register([FromBody] UserRegisterDTO userDTO)
        {
            try
            {
                var user = _service.Register(userDTO);
                if (user == null)
                {
                    return BadRequest(new Error(1, "Unable to register"));
                }
                return Ok(user);
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }

        }


        [HttpPost("Login User")]
        [ProducesResponseType(typeof(ICollection<UserDTO>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> Login([FromBody] UserDTO userDTO)
        {
            try
            {
                var user = _service.Login(userDTO);
                if (user == null)
                {
                    return BadRequest(new Error(1, "Invalid username or password"));
                }
                return Ok(user);
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }
    }
}
