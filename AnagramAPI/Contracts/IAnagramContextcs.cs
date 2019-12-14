using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Contracts
{
    public interface IAnagramContext
    {
        Task<BaseResponse> SaveNewWord(string encodedString);
        Task<BaseResponse> CheckAnagram(int ID1, int ID2, string address);
        Task<BaseResponse> GetCheckResult(int id);

    }
}
