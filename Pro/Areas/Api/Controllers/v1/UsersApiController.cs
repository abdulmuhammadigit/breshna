using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common;
using Pro.Common.Api;
using Pro.Common.Api.Attributes;
using Pro.Services.Api.Contract;
using Pro.Services.Contracts;
using Pro.ViewModels.Api.UsersApi;
using Pro.ViewModels.DynamicAccess;
using Pro.ViewModels.UserManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pro.Areas.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiResultFilter]
    [ApiVersion("1")]
    public class UsersApiController : ControllerBase
    {
        private readonly IApplicationUserManager _userManager;
        private readonly IjwtService _jwtService;
        public UsersApiController(IApplicationUserManager userManager, IjwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpGet]
        [JwtAuthentication(Policy = ConstantPolicies.DynamicPermission)]
        public virtual async Task<ApiResult<List<UsersViewModel>>> Get(int offset, int limit, string order, string search)
        {
            if (!search.HasValue())
                search = "";
            return Ok(await _userManager.GetPaginateUsersAsync(offset, limit, order, search));
        }

        [HttpGet("{id}")]
        public virtual async Task<ApiResult<UsersViewModel>> Get(int id)
        {
            var user = await _userManager.FindUserWithRolesByIdAsync(id);
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpPost("[action]")]
        public virtual async Task<ApiResult<string>> SignIn([FromBody] SignInBaseViewModel ViewModel)
        {
            var User = await _userManager.FindByNameAsync(ViewModel.UserName);
            if (User == null)
                return BadRequest("نام کاربری یا کلمه عبور شما صحیح نمی باشد.");
            else
            {
                var result = await _userManager.CheckPasswordAsync(User, ViewModel.Password);
                if (result)
                    return Ok(await _jwtService.GenerateTokenAsync(User));
                else
                    return BadRequest("نام کاربری یا کلمه عبور شما صحیح نمی باشد.");
            }
        }
    }
}