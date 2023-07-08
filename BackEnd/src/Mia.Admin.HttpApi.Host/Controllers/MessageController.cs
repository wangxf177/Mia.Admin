using Microsoft.AspNetCore.Mvc;
using Mia.Admin.Messages;
using System.Threading.Tasks;

namespace Mia.Admin.Controllers
{
    public class MessageController : MiaControllerBase
    {
        private readonly IMiaRepository<Comment> _MiaRepository;

        public MessageController(IMiaRepository<Comment> MiaRepository)
        {
            _MiaRepository = MiaRepository;
        }

        [HttpPost]
        public async Task<bool> Create()
        {
            await _MiaRepository.InsertAsync(new Comment
            {
                TxtResponse = "This is a test message!"
            });
            return true;
        }
    }
}
