using DAL_ADO.Interfaces;
using DAL_ADO.Models;
using DAL_ADO.Services;
using GestionEvenementsAPI.Models.Form;
using GestionEvenementsAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEvenementsAPI.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
   public class UserController : ControllerBase
   {
      private readonly IUserService _UserService;
      private readonly IRoleService _RoleService;
      private readonly TokenManager _tokenManager;
      public UserController(IUserService UserService,IRoleService roleService, TokenManager tokenManager)
      {
         _UserService = UserService;
         _RoleService = roleService;
         _tokenManager = tokenManager;
      }
      [Authorize("AdminPolicy")]
      [HttpGet]
      public IActionResult GetAll()
      {
         List<User> users = _UserService.ReadAll("Users").ToList();
         foreach (User u in users) 
         {
            u.Role = _RoleService.ReadOne(u.Role.Id);
         }
         return Ok(users);
      }
      [HttpGet("{id}")]
      public IActionResult GetById([FromRoute] int id)
      {
         User u = _UserService.ReadOne(id, "Users");
         u.Role = _RoleService.ReadOne(u.Role.Id);
         return Ok(u);
      }
      [HttpPost("register")]
      public IActionResult Register([FromBody] UserRegisterForm user)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         try
         {
            if (_UserService.Register(user.Email, user.Password, user.LastName,user.FirstName))
            {
               return Ok();
            }
            return Ok();
         }
         catch (Exception ex)
         {

            BadRequest(ex.Message);
         }
         return Ok();

      }

      [HttpPost("login")]
      public IActionResult Login([FromBody] UserLoginForm user)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         try
         {
            User u = _UserService.Login(user.Email, user.Password);
            
            return Ok(_tokenManager.GenerateToken(u));
         }
         catch (Exception ex)
         {
            return BadRequest(ex.Message);
         }
      }
      [Authorize("AdminPolicy")]
      [HttpPatch("setRole")]
      public IActionResult SetRole(SetRoleForm model)
      {
         _UserService.SetRole(model.UserId, model.RoleId);
         return Ok();
      }
   }
}
