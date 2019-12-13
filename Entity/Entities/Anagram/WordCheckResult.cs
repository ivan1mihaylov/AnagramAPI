using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities.Anagram
{
    public class WordCheckResult
    {
        public WordCheckResult(Word word, CheckResult checkResult)
        {
            Word = word;
            CheckResult = checkResult;
        }

        public WordCheckResult(long wordId, long checkResultId)
        {
            WordId = wordId;
            CheckResultId = checkResultId;
        }

        public long WordId { get; set; }
        public Word Word { get; set; }
        public long CheckResultId { get; set; }
        public CheckResult CheckResult { get; set; }
    }
}
