
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pro.DataAccess;
using Pro.Entities.identity;
using Pro.Services.Contracts;
using Pro.Services.Api.Contract;
using Pro.ViewModels.DynamicAccess;
using Pro.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Services.Api
{
    public class jwtService : IjwtService
    {
        public readonly IApplicationUserManager _userManager;
        public readonly IApplicationRoleManager _roleManager;
        public readonly IUnitOfWork _uw;
        public readonly SiteSettings _siteSettings;
        public jwtService(IApplicationUserManager userManager, IApplicationRoleManager roleManager, IUnitOfWork uw, IOptionsSnapshot<SiteSettings> siteSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _uw = uw;
            _siteSettings = siteSettings.Value;
        }

        public async Task<string> GenerateTokenAsync(User user)
        {
            var secretKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encrytionKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.EncrypKey);
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encrytionKey),SecurityAlgorithms.Aes128KW,SecurityAlgorithms.Aes128CbcHmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _siteSettings.JwtSettings.Issuer,
                Audience = _siteSettings.JwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(_siteSettings.JwtSettings.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(_siteSettings.JwtSettings.ExpirationMinutes),
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(await GetClaimsAsync(user)),
                EncryptingCredentials= encryptingCredentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }


        public async Task<IEnumerable<Claim>> GetClaimsAsync(User user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                new Claim(new ClaimsIdentityOptions().SecurityStampClaimType,user.SecurityStamp),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach(var item in userClaims)
                Claims.Add(new Claim(ConstantPolicies.DynamicPermissionClaimType, item.Value));

            foreach (var item in userRoles)
                Claims.Add(new Claim(ClaimTypes.Role, item));

            return Claims;
        }
    }
}
