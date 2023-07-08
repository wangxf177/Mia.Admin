using Microsoft.AspNetCore.Mvc;
using Mia.Admin.Messages;
using System.Threading.Tasks;

namespace Mia.Admin.Controllers
{
    public class MessageController : MiaControllerBase
    {
        private readonly IAdminRepository<Comment> _AdminRepository;

        public MessageController(IAdminRepository<Comment> AdminRepository)
        {
            _AdminRepository = AdminRepository;
        }

        [HttpPost]
        public async Task<bool> Create()
        {
            await _AdminRepository.InsertAsync(new Comment
            {
                TxtResponse = "This is a test message!"
            });
            return true;
        }
    }
}
