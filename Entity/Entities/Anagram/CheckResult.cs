using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities.Anagram
{
    public class CheckResult : Entity
    {
        public CheckResult():base()
        {
        }

        public CheckResult(bool areAnagrams):base()
        {
            AreAnagrams = areAnagrams;
        }

        public string Url { get; set; }
        public bool AreAnagrams { get; set; }

        public ICollection<WordCheckResult> WordCheckResults { get; set; }
    }
}
