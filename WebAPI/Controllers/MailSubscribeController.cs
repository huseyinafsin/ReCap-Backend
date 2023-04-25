using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailSubscribeController : ControllerBase
    {
        private readonly IMailSubscribeService _mailSubscribeService;

        public MailSubscribeController(IMailSubscribeService mailSubscribeService)
        {
            _mailSubscribeService = mailSubscribeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _mailSubscribeService.GetAllMails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(Guid mailId)
        {
            var result =await _mailSubscribeService.GetMailByIdAsync(mailId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] MailSubscribe mail)
        {
            var result = _mailSubscribeService.AddMail(mail);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] MailSubscribe mail)
        {
            var result = _mailSubscribeService.DeleteMail(mail);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] MailSubscribe mail)
        {
            var result = _mailSubscribeService.UpdateMail(mail);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
