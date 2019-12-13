using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class BaseDTO : BaseResponse
    {
        public BaseDTO():base()
        {
        }

        public BaseDTO(string errorMessage) : base(errorMessage)
        {
        }

        public long Id { get; set; }

    }
}
