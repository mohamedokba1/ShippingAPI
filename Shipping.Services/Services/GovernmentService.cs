using AutoMapper;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Services
{
    public class GovernmentService : IGovernmentService
    
    {
        private readonly IGovermentRepository govermentRepository;
        private readonly IMapper mapper;

        public GovernmentService(IGovermentRepository govermentRepository , IMapper mapper)
        {
            this.govermentRepository = govermentRepository;
            this.mapper = mapper;
        }
        public async Task Add(GovermentAddDto govermentDto)
        {
           Goverment g = mapper.Map<Goverment>(govermentDto);

            await govermentRepository.Add(g);
        }

        public async Task Delete(int id)
        {
            await govermentRepository.Delete(id);
        }

        public async Task<IEnumerable<GovermentReadDto>> Getall()
        {
            var govermentsfromDB = await govermentRepository.Getall();
            return mapper.Map<IEnumerable<GovermentReadDto>>(govermentsfromDB);
            
        }

        public async Task<GovermentReadDto> GetByid(int id)
        {
            Goverment? govermentfromDB = await govermentRepository.GetByid(id);

            if(govermentfromDB == null)
            {
                return null;
            }
            return mapper.Map<GovermentReadDto>(govermentfromDB);
        }

        public async Task Savechanges()
        {
            await govermentRepository.Savechanges();
        }

        public  async Task Update(int id, GovermentUpdateDto govermentdto)
        {
            Goverment governmentToUpdate = await govermentRepository.GetByid(id);
            if (governmentToUpdate != null)
            {
                mapper.Map(govermentdto, governmentToUpdate);
                await govermentRepository.Savechanges();


                //governmentToUpdate.GovermentName = govermentdto.GovermentName;
                //governmentToUpdate.State = govermentdto.State;
                


            }

        }
    }
}
