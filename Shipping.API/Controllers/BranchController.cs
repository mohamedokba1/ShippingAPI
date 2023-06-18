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
        private readonly IBranchService branchService;

        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }
        [HttpGet]
        [Route("Getall")]

        public async Task<ActionResult<IEnumerable<BranchReadDto>>> Getall()
        {
            return Ok(await branchService.Getall());

        }



    }
}
