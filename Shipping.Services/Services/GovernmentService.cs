using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;

namespace Shipping.Services.Services
{
    public class GovernmentService : IGovernmentService
    
    {
        private readonly IGovermentRepository _govermentRepository;
        private readonly IMapper _mapper;

        public GovernmentService(IGovermentRepository govermentRepository , IMapper mapper)
        {
            _govermentRepository = govermentRepository;
            _mapper = mapper;
        }
        public async Task Add(GovermentAddDto govermentDto)
        {
            await _govermentRepository.Add(_mapper.Map<Goverment>(govermentDto));
            await SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _govermentRepository.Delete(id);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<GovermentReadDto>> Getall()
        {
            var govermentsfromDB = await _govermentRepository.Getall();
            return _mapper.Map<IEnumerable<GovermentReadDto>>(govermentsfromDB);     
        }
        public async Task<GovermentReadDto?> GetByid(int id)
        {
            Goverment? govermentfromDB = await _govermentRepository.GetByid(id);
            if(govermentfromDB == null)
            {
                return null;
            }
            return _mapper.Map<GovermentReadDto>(govermentfromDB);
        }

        public IQueryable<GovermentReadDto> GetGovernmentsPaginated()
        {
            IQueryable governments = _govermentRepository.GetGovernmentPaginated();
            return governments.ProjectTo<GovermentReadDto>(_mapper.ConfigurationProvider);
        }

        public async Task SaveChangesAsync()
        {
            await _govermentRepository.Savechanges();
        }

        public  async Task Update(int id, GovermentUpdateDto govermentdto)
        {
            Goverment governmentToUpdate = await _govermentRepository.GetByid(id);
            if (governmentToUpdate != null)
            {
                _mapper.Map(govermentdto, governmentToUpdate);
                await _govermentRepository.Savechanges();
            }
        }
    }
}
