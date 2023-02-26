using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Tmf.InstaVerita.Core.Constants;
using Tmf.InstaVerita.Core.Exception;
using Tmf.InstaVerita.Core.RequestModels;
using Tmf.InstaVerita.Core.ResponseModels;
using Tmf.InstaVerita.Manager.Interfaces;

namespace Tmf.InstaVerita.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstaVeritaController : ControllerBase
    {
        private readonly IInstaVeritaManager _instaVeritaManager;
        private readonly IValidator<InstaVeritaRequest> _instaVeritaValidator;

        public InstaVeritaController(IInstaVeritaManager instaVeritaManager, IValidator<InstaVeritaRequest> instaVeritaValidator)
        {
            _instaVeritaManager = instaVeritaManager;
            _instaVeritaValidator = instaVeritaValidator;
        }

        [HttpGet]
        [Route("GetVehicleDetails")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InstaVeritaResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehicleDetails([FromQuery] InstaVeritaRequest instaVeritaRequest)
        {
            ValidationResult result = await _instaVeritaValidator.ValidateAsync(instaVeritaRequest);
            if (!result.IsValid)
            {
                return BadRequest(new ErrorResponse { Message = ValidationMessages.GeneralValidationErrorMessage, Error = result.Errors.Select(m => m.ErrorMessage) });
            }
            var data = await _instaVeritaManager.GetRCDetails(instaVeritaRequest);
            return Ok(data);
        }
    }
}
