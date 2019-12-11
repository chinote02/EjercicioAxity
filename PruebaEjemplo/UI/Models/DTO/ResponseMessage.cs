using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.DTO
{
    public class ResponseMessage
    {
        public string Message { get; set; }
        public string HttpReDirect { get; set; }
        public bool HasError { get; set; }
    }
}