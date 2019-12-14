using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class CheckResultDTO : BaseDTO
    {
        public bool AreAnagrams { get; set; }
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }
    }
}
