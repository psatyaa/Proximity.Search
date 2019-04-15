using System;
using System.Collections.Generic;
using System.Text;

namespace Proximity.Search.Domain
{
   public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
