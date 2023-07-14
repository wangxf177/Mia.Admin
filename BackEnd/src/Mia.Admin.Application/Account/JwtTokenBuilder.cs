using Mia.Admin.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Volo.Abp.Security.Claims;

namespace Mia.Admin.Account
{
    public sealed class JwtTokenBuilder
    {
        private SecurityKey? _securityKey;
        private bool _useissuer;
        private string _issuer = "";
        private bool _useaudience;
        private string _audience = "";
        private readonly Dictionary<string, object> _claims = new();
        private int _expiryInMinutes = 20;

        private void EnsureArguments()
        {
            if (_securityKey == null)
                throw new ArgumentNullException("Security Key");

            if (_useissuer && string.IsNullOrEmpty(_issuer))
                throw new ArgumentNullException("Issuer");

            if (_useaudience && string.IsNullOrEmpty(_audience))
                throw new ArgumentNullException("Audience");
        }

        public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
        {
            _securityKey = securityKey;
            return this;
        }

        public JwtTokenBuilder AddIssuer(string issuer)
        {
            _issuer = issuer;
            _useissuer = true;
            return this;
        }

        public JwtTokenBuilder AddAudience(string audience)
        {
            _audience = audience;
            _useaudience = true;
            return this;
        }

        public JwtTokenBuilder AddClaim(string type, string value)
        {
            _claims.Add(type, value);
            return this;
        }

        public JwtTokenBuilder AddClaim(string type, object value)
        {
            _claims.Add(type, JsonConvert.SerializeObject(value));
            return this;
        }

        public JwtTokenBuilder AddClaim(string type, List<string> values)
        {
            if (values != null && values.Count > 0)
            {
                _claims.Add(type, values);
            }
            return this;
        }

        public JwtTokenBuilder AddClaims(Dictionary<string, string> claims)
        {
            if (claims.Count > 0)
            {
                foreach (var item in claims)
                {
                    if (!_claims.ContainsKey(item.Key) && !string.IsNullOrEmpty(item.Value))
                    {
                        _claims.Add(item.Key, item.Value);
                    }
                }
            }
            return this;
        }

        public JwtTokenBuilder AddExpiry(int expiryInMinutes)
        {
            _expiryInMinutes = expiryInMinutes;
            return this;
        }

        private List<Claim> BuildClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var item in _claims)
            {
                if (item.Value is List<string>)
                {
                    if (item.Value is List<string> values)
                    {
                        values.ForEach(m => claims.Add(new Claim(item.Key, m)));
                    }
                }
                else
                {
                    claims.Add(new Claim(item.Key, item.Value.ToString() ?? ""));
                }
            }
            return claims;
        }

        public JwtToken Build()
        {
            EnsureArguments();

            var securityKey = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _issuer,
                audience: _audience,
            claims: BuildClaims(),
                expires: DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                signingCredentials: securityKey);

            return new JwtToken(token);
        }

        public JwtToken Build(DateTime exprieTime)
        {
            EnsureArguments();
            var securityKey = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: BuildClaims(),
                expires: exprieTime,
                signingCredentials: securityKey);

            return new JwtToken(token);
        }

        public static Tokens CreateTokens(JwtConfig _config, JwtUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));

            var accessBuilder = new JwtTokenBuilder();
            var accessToken = accessBuilder.AddAudience(_config.Audience)
                .AddExpiry(_config.ExpiryInMinutes)
                .AddIssuer(_config.Issuer)
                .AddSecurityKey(securityKey)
                .AddClaim(AbpClaimTypes.UserName, userInfo.UserName)
                .AddClaim(AbpClaimTypes.UserId, userInfo.UserId)
                .AddClaim(AbpClaimTypes.Role, userInfo.Roles)
                .AddClaim(ClaimTypes.GroupSid, userInfo.Groups)
                .Build().Value;

            var refreshBuilder = new JwtTokenBuilder();
            var refreshToken = refreshBuilder.AddAudience(_config.Audience)
                .AddExpiry(_config.RefreshExpiryInMinutes)
                .AddIssuer(_config.Issuer)
                .AddSecurityKey(securityKey)
                .AddClaim(AbpClaimTypes.Name, userInfo.UserName)
                .AddClaim(AbpClaimTypes.UserId, userInfo.UserId)
                .AddClaim(AbpClaimTypes.Role, userInfo.Roles)
                .AddClaim(ClaimTypes.GroupSid, userInfo.Groups)
                .Build().Value;

            return new Tokens { AccessToken = accessToken, RefreshToken = refreshToken };
        }

        public static Tokens RefreshTokens(JwtConfig _config, JwtUser userInfo, DateTime exprieTime)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));
            var accessBuilder = new JwtTokenBuilder();
            var accessToken = accessBuilder.AddAudience(_config.Audience)
                  .AddExpiry(_config.ExpiryInMinutes)
                  .AddIssuer(_config.Issuer)
                  .AddSecurityKey(securityKey)
                  .AddClaim(AbpClaimTypes.Name, userInfo.UserName)
                  .AddClaim(AbpClaimTypes.UserId, userInfo.UserId)
                  .AddClaim(AbpClaimTypes.Role, userInfo.Roles)
                  .AddClaim(ClaimTypes.GroupSid, userInfo.Groups)
                  .Build().Value;

            var refreshBuilder = new JwtTokenBuilder();
            var refreshToken = refreshBuilder.AddAudience(_config.Audience)
                .AddExpiry(_config.RefreshExpiryInMinutes)
                .AddIssuer(_config.Issuer)
                .AddSecurityKey(securityKey)
                .AddClaim(AbpClaimTypes.Name, userInfo.UserName)
                .AddClaim(AbpClaimTypes.UserId, userInfo.UserId)
                .AddClaim(AbpClaimTypes.Role, userInfo.Roles)
                .AddClaim(ClaimTypes.GroupSid, userInfo.Groups)
                .Build(exprieTime).Value;

            return new Tokens { AccessToken = accessToken, RefreshToken = refreshToken };
        }
    }

    public sealed class JwtToken
    {
        private readonly JwtSecurityToken _token;

        internal JwtToken(JwtSecurityToken token)
        {
            _token = token;
        }

        public DateTime ValidTo => _token.ValidTo;
        public string Value => new JwtSecurityTokenHandler().WriteToken(_token);
    }

    public class Tokens
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class JwtUser
    {
        public string UserName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ICollection<string> Roles { get; set; } = new List<string>();
        public ICollection<string> Groups { get; set; } = new List<string>();
    }
}
