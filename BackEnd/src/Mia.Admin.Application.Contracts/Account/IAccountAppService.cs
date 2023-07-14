using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Mia.Admin.Account
{
    public interface IAccountAppService : IApplicationService
    {
        Task<LoginResultDto> LoginAsync(LoginDto model);
    }
}
