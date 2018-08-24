using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MsgService.Model;

namespace MsgService.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        //发请求，报文体为{phoneNum:"110",msg:"aaaaaaaaaaaaa"}，
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        [HttpPost(nameof(Send_MI))]
        [Route("api/SMS/Send_MI")]
        public void Send_MI(dynamic model)
        {
            Console.WriteLine($"通过小米短信接口向{model.phoneNum}发送短信{model.msg}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        [HttpPost(nameof(Send_LX))]
        [Route("api/SMS/Send_LX")]
        public void Send_LX(SendSMSRequest model)
        {
            Console.WriteLine($"通过联想短信接口向{model.PhoneNum}发送短信{model.Msg}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        [HttpPost(nameof(Send_HW))]
        [Route("api/SMS/Send_HW")]
        public void Send_HW(SendSMSRequest model)
        {
            Console.WriteLine($"通过华为短信接口向{model.PhoneNum}发送短信{model.Msg}");
        }
    }
}
