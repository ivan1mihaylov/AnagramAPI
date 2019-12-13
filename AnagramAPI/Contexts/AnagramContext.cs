using AnagramAPI.Contracts;
using AutoMapper;
using Domain.DTOs;
using Domain.Extensions;
using Entity;
using Entity.Entities.Anagram;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Contexts
{
    public class AnagramContext : IAnagramContext
    {
        private readonly AnagramDbContext _anagramDbContext;
        private readonly IMapper _mapper;

        public AnagramContext(AnagramDbContext anagramDbContext, IMapper mapper)
        {
            _anagramDbContext = anagramDbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse> SaveNewAnagram(string encodedString)
        {
            var existingEntry = await _anagramDbContext.Words.FirstOrDefaultAsync(x => x.EncodedString == encodedString);
            if (!existingEntry.IsNull())
            {
                return _mapper.Map<BaseDTO>(source: existingEntry);
            }

            var newWord = new Word(encodedString);

            await _anagramDbContext.Words.AddAsync(newWord);

            try
            {
                await _anagramDbContext.SaveChangesAsync();
                return _mapper.Map<BaseDTO>(source: newWord);
            }
            catch (Exception e)
            {
                return new BaseResponse(e.Message);
            }
        }

        public async Task<BaseResponse> CheckAnagram(int ID1, int ID2, string address)
        {
            var firstWord = await _anagramDbContext.Words.FirstOrDefaultAsync(x => x.Id == ID1);
            var secondWord = await _anagramDbContext.Words.FirstOrDefaultAsync(x => x.Id == ID2);

            if (firstWord.IsNull() || secondWord.IsNull())
            {
                return new BaseResponse("You must provide a valid IDs!");
            }

            var existingResult = await _anagramDbContext.CheckResults
                .Include(x => x.WordCheckResults)
                .FirstOrDefaultAsync(x =>
                    x.WordCheckResults.FirstOrDefault(y => y.WordId == firstWord.Id) != null
                    && x.WordCheckResults.FirstOrDefault(y => y.WordId == secondWord.Id) != null
                );

            if (!existingResult.IsNull())
            {
                return _mapper.Map<CheckResultDTO>(source: existingResult);
            }

            var areAnagrams = AreStringsAnagrams(firstWord.DecodedString, secondWord.DecodedString);

            var newCheckResult = new CheckResult(areAnagrams);

            await _anagramDbContext.CheckResults.AddAsync(newCheckResult);
            await _anagramDbContext.SaveChangesAsync();

            await _anagramDbContext.WordCheckResults.AddAsync(new WordCheckResult(firstWord, newCheckResult));
            await _anagramDbContext.WordCheckResults.AddAsync(new WordCheckResult(secondWord, newCheckResult));

            newCheckResult.Url = $"{address}/{newCheckResult.Id}";
            _anagramDbContext.CheckResults.Update(newCheckResult);
            await _anagramDbContext.SaveChangesAsync();

            return _mapper.Map<CheckResultDTO>(source: newCheckResult);
        }

        private static bool AreStringsAnagrams(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b) || a.Length != b.Length)
            {
                return false;
            }

            a = a.Trim().ToLower();
            b = b.Trim().ToLower();

            if (a.Equals(b))
                return false;

            char[] ac = a.ToCharArray();
            char[] bc = b.ToCharArray();
            Array.Sort(ac);
            Array.Sort(bc);
            for (int i = 0; i < ac.Length; i++)
            {
                if (ac[i] != bc[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
