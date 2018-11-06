using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.ViewModel
{
    public class ResultModel
    {
        public int StatusCode { get; set; }

        public string StatusText { get; set; }

        public Object Result { get; set; }
    }
}
