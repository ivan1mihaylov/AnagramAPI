using AnagramAPI.Contracts;
using AnagramAPI.Infrastructure.Extensions;
using AutoMapper;
using Domain.DTOs;
using Domain.Extensions;
using Entity;
using Entity.Contracts;
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
        private readonly IAnagramDbContext _anagramDbContext;
        private readonly IMapper _mapper;

        public AnagramContext(IAnagramDbContext anagramDbContext, IMapper mapper)
        {
            _anagramDbContext = anagramDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Save the provided
        /// </summary>
        /// <param name="encodedString"></param>
        /// <returns></returns>
        public async Task<BaseResponse> SaveNewWord(string encodedString)
        {
            if (!encodedString.IsBase64())
            {
                return new BaseResponse("The provided string is not Base64 encoded");
            }

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
                return _mapper.Map<ResultDTO>(source: existingResult);
            }

            var areAnagrams = AnagramExtensions.AreStringsAnagrams(firstWord.DecodedString, secondWord.DecodedString);

            var newCheckResult = new CheckResult(areAnagrams);

            try
            {
                await _anagramDbContext.CheckResults.AddAsync(newCheckResult);
                await _anagramDbContext.SaveChangesAsync();

                await _anagramDbContext.WordCheckResults.AddAsync(new WordCheckResult(firstWord, newCheckResult));
                await _anagramDbContext.WordCheckResults.AddAsync(new WordCheckResult(secondWord, newCheckResult));

                newCheckResult.Url = $"{address}/v1/anagram/{newCheckResult.Id}";
                _anagramDbContext.CheckResults.Update(newCheckResult);
                await _anagramDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new BaseResponse(e.Message);
            }

            return _mapper.Map<ResultDTO>(source: newCheckResult);
        }


        public async Task<BaseResponse> GetCheckResult(int id)
        {
            var checkResult = await _anagramDbContext.CheckResults.Include(x => x.WordCheckResults).ThenInclude(x => x.Word).FirstOrDefaultAsync(x => x.Id == id);
            
            if (checkResult.IsNull())
            {
                return new BaseResponse("Invalid result ID");
            }

            var result = new CheckResultDTO
            {
                AreAnagrams = checkResult.AreAnagrams,
                FirstWord = checkResult.WordCheckResults.FirstOrDefault().Word.DecodedString,
                SecondWord = checkResult.WordCheckResults.LastOrDefault().Word.DecodedString,
            };

            return result;
        }
    }
}
