using JWT;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using DGQ.Code.Json;

namespace DGQ.Code.Operator
{
    public class OperatorProvider
    {
        
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }

        public OperatorModel GetCurrent(string cookies)
        {
            OperatorModel operatorModel = new OperatorModel();
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer,provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
            var json = decoder.Decode(cookies).ToObject<OperatorModel>();
            return json;
        }
    }
}
