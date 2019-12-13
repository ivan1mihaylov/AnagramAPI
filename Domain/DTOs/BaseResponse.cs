using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(string errorMessage)
        {
            HasError = true;
            ErrorMessage = errorMessage;
        }

        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
