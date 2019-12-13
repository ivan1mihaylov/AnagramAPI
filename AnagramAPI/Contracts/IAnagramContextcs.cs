using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Contracts
{
    public interface IAnagramContext
    {
        Task<BaseResponse> SaveNewAnagram(string encodedString);
        Task<BaseResponse> CheckAnagram(int ID1, int ID2, string address);

    }
}
