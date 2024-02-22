using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tadbir.Ins.Application.InsuranceRequestApp.Model;
using Tadbir.Ins.QueryHandler.QueryHandlers;
using Vita.Shared.Result;
using Vita.WebAPI.Controllers;

namespace Tadbir.Ins.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InsuranceCoverageController : VitaAPIControllerBase
    {
        public InsuranceCoverageController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// دریافت لیست پوشش های بیمه ای
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<VitaResult<List<InsuranceCoverageQueryDto>>> GetInsuranceCoverage([FromBody] InsuranceCoverageQueryDto model)
        {
            return await _VitaMediator.Send(model);
        }


    }
}
