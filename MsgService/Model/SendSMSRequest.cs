﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsgService.Model
{
    public class SendSMSRequest
    {
        public string PhoneNum { get; set; }
        public string Msg { get; set; }
    }
}
