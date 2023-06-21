using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.Branch;
using Shipping.Services.IServices;
using Shipping.Services.Services;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchReadDto>>> GetAllBranches()
        {
            var branches = await _branchService.GetAllAsync();
            return Ok(branches);
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
        public async Task<ActionResult> Deletebranch(int id)
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
