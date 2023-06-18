using AutoMapper;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos.Branch;
using Shipping.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository branchRepository;
        private readonly IMapper mapper;

        public BranchService(IBranchRepository branchRepository , IMapper mapper)
        {
            this.branchRepository = branchRepository;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<BranchReadDto>> Getall()
        {
            var branchFromDB = await branchRepository.GetAllAsync();
            return mapper.Map<IEnumerable<BranchReadDto>>(branchFromDB);
        }
    }
}
