using Shipping.Services.Dtos;

namespace Shipping.Services.IServices
{
    public interface IGovernmentService
    {
        Task<IEnumerable<GovermentReadDto>> Getall();
        Task<GovermentReadDto?> GetByid(int id);
        Task Add(GovermentAddDto goverment);
        Task Update(int id,GovermentUpdateDto goverment);
        Task Delete(int id);
        Task SaveChangesAsync();
        IQueryable<GovermentReadDto> GetGovernmentsPaginated();

    }
}
