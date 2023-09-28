using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twoChapter.IServices;

namespace twoChapter.Controllers
{
    [ApiController]
    [Route("api/kzf")]
    public class LogOnController: ControllerBase
    {

        private readonly ILogOnRepository _ILogOnRepository;

       public LogOnController(ILogOnRepository ILogOnRepository)
        {
            _ILogOnRepository = ILogOnRepository ?? throw new ArgumentNullException(nameof(ILogOnRepository));
        }
       //验证码
       [Route("VerifyCode")]
       [HttpGet]
       public IActionResult VerifyCode()
        {
            return Ok(_ILogOnRepository.VerifyCode());
        }
    }
}
