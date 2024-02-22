using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tadbir.Ins.Application.InsuranceRequestApp;
using Tadbir.Ins.Application.InsuranceRequestApp.Model;
using Tadbir.Ins.QueryHandler.QueryHandlers;
using Vita.Shared.DtoModel;
using Vita.Shared.Pagination;
using Vita.Shared.Result;
using Vita.WebAPI.Controllers;

namespace Tadbir.Ins.WebAPI.Controllers
{

    [Produces("application/json")]
    // [ApiVersion(1.0)]
    // [Route("api/v{version:apiVersion}/[controller]/[action]")]
     [Route("api/[controller]/[action]")]
    [ApiController]
    public class InsuranceRequestController : VitaAPIControllerBase
    {
        private readonly IInsuranceRequestAppService _InsuranceRequestAppService;
        public InsuranceRequestController(IMediator mediator, IInsuranceRequestAppService insuranceRequestAppService) : base(mediator)
        {
            _InsuranceRequestAppService = insuranceRequestAppService;
        }

        /// <summary>
        /// ثبت درخواست ها
        /// </summary>
        /// <param name="InsuranceRequest"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize]
        public async Task<VitaResult<InsuranceRequestDto>> AddAsync([FromBody] InsuranceRequestDto InsuranceRequest)
        {
            return await _InsuranceRequestAppService.AddAsync(InsuranceRequest);
        }

        /// <summary>
        /// لیست درخواست ها
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<VitaResult<List<InsuranceRequestQueryDto>>> GetInsuranceCoverage([FromBody] InsuranceRequestQueryDto model)
        {
            return await _VitaMediator.Send(model);
        }


        #region CommentOtherCRUD
        //[HttpPost()]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize]
        //public async Task<VitaResult<InsuranceRequestDto>> UpdateAsync([FromBody] InsuranceRequestDto InsuranceRequest)
        //{
        //    return await _InsuranceRequestAppService.UpdateAsync(InsuranceRequest);
        //}

        //[HttpPost()]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize]
        //public async Task<VitaResult<bool>> DeleteByIdAsync([FromBody] Model<Guid> model)
        //{
        //    return await _InsuranceRequestAppService.DeleteByIdAsync(model.Id);
        //}

        //[HttpPost()]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize]
        //public async Task<VitaResult<InsuranceRequestDto>> GetById([FromBody] Model<Guid> model)
        //{
        //    return await _InsuranceRequestAppService.GetByIdAsync(model.Id);
        //}


        //[HttpPost()]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize]
        //public async Task<VitaResult<List<InsuranceRequestQueryDto>>> GetInsuranceRequest([FromBody] InsuranceRequestQueryDto InsuranceRequest)
        //{
        //    //return _InsuranceRequestAppService.GetAllInsuranceRequest(InsuranceRequest);
        //    return await _VitaMediator.Send(InsuranceRequest);
        //}
        #endregion



    }
}
