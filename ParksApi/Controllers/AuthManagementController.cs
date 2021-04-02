using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParksApi.Configuration;
using ParksApi.Models.DTOs.Requests;
using ParksApi.Models.DTOs.Responses;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")] // api/authManagement
  [ApiController]
  public class AuthManagementController : ControllerBase
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtConfig _jwtConfig;

    public AuthManagementController(
      UserManager<IdentityUser> userManager,
      IOptionsMonitor<JwtConfig> optionsMonitor)
    {
      _userManager = userManager;
      _jwtConfig = optionsMonitor.CurrentValue;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
    {
      if(ModelState.IsValid)
      {
        // We can utilise the model
        var existingUser = await _userManager.FindByEmailAsync(user.Email);

        if(existingUser != null)
        {
          return BadRequest(new RegistrationResponse(){
                  Errors = new List<string>() {
                    "Email already in use"
                  },
                  Result = false
          });
        }

        var newUser = new IdentityUser() { Email = user.Email, UserName = user.Username};
        var isCreated = await _userManager.CreateAsync(newUser, user.Password);
        if(isCreated.Succeeded)
        {
          var jwtToken =  GenerateJwtToken( newUser);

          return Ok(new RegistrationResponse() {
              Result = true,
              Token = jwtToken
          });
        } else {
            return BadRequest(new RegistrationResponse(){
                    Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                    Result = false
            });
        }
      }

      return BadRequest(new RegistrationResponse(){
              Errors = new List<string>() {
                  "Invalid payload"
              },
              Result = false
      });
    }

  }
}