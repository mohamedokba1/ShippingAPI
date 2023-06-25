using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.Branch;
using Shipping.Services.IServices;
using Shipping.Services.Services;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchReadDto>>> GetAllBranches()
        {
            var branches = await _branchService.GetAllAsync();
            return Ok(branches);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationResponse<BranchReadDto>>> GetBranch([FromQuery] PaginationParameters paginationParameters)
        {
            var branches = _branchService.GetBranchesPaginated();
            
            int totalRecords = await branches.CountAsync();

            List<BranchReadDto>? listOfBranches = await branches
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
            PaginationResponse<BranchReadDto> result =
                new PaginationResponse<BranchReadDto>()
                {
                    Data = listOfBranches,
                    PageNo = paginationParameters.PageNumber,
                    PageSize = paginationParameters.PageSize,
                    TotalRecords = totalRecords
                };
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BranchReadDto>> GetBranch(int id)
        {
            var branch = await _branchService.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            return Ok(branch);
        }

        [HttpPost]
        public async Task<ActionResult> AddBranch(BranchAddDto branch)
        {
            if (branch == null)
            {
                return BadRequest("Branch is Null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _branchService.AddAsync(branch);

            return Ok("added success");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateBranch(int id, BranchUpdateDto branch)
        {
            if (id != branch.Id)
            {
                return BadRequest("Branch is Null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistingBranch = await _branchService.GetByIdAsync(id);
            if (ExistingBranch == null)
            {
                return NotFound();
            }
            await _branchService.UpdateAsync(branch, id);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            var ExistingBranch = await _branchService.GetByIdAsync(id);
            if (ExistingBranch == null)
            {
                return NotFound();
            }
            await _branchService.DeleteAsync(id);
            return NoContent();
        }
    }
}
