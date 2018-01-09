using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    //[Authorize]
    public class TestController : Controller
    {
        private readonly IMail _mailService;

        public TestController(IMail mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        [Route("api/feedback")]
        public void GetBattleInfo([FromBody]ClientInfo data)
        {
            _mailService.Send(data);
        }

    }
}
