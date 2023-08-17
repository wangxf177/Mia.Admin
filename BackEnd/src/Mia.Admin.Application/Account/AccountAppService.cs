using Mia.Admin.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Mia.Admin.Account
{
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        private readonly JwtConfig _jwtConfig;

        public AccountAppService(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<LoginResultDto> LoginAsync(LoginDto model)
        {
            JwtUser user = new JwtUser();

            var token = JwtTokenBuilder.CreateTokens(_jwtConfig, user);

            return await Task.FromResult(new LoginResultDto(token.AccessToken, token.RefreshToken, ""));
        }
    }
}
