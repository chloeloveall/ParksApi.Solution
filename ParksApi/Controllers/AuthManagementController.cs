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
// using ParksApi.Models.DTOs.Requests;
// using ParksApi.Models.DTOs.Responses;

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

  }
}