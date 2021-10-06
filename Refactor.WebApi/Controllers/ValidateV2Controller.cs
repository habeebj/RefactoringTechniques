using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refactor.WebApi.Interface;
using Refactor.WebApi.Interfaces;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateV2Controller : ControllerBase
    {
        private readonly ILogger<ValidateController> _logger;
        private readonly IIPRSProxy _iprsProxy;

        public ValidateV2Controller(ILogger<ValidateController> logger, IIPRSProxy iprsProxy)
        {
            _logger = logger;
            _iprsProxy = iprsProxy;
        }

        [HttpPost("identityV2")]
        [ProducesResponseType(typeof(IPRSBindingResponseModel), 200)]
        public async Task<IActionResult> ValidateIPRSData([FromBody] IPRSBindingModel model)
        {
            _logger.LogInformation("Validate Identity");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _iprsProxy.GetData(model.CountryCode, model.DocumentType, model.DocumentNumber);
            bool notSucceeded = response?.RsData?.Status?.ResponseCode != "00";
            if (notSucceeded)
                return BadRequest("Unable to validate IPRS");

            var person = response.RsData.NationalIdentity.Person;
            var identityDocument = response.RsData.NationalIdentity.IdentityDocument;
            var iprsResponseBindingModel = IPRSBindingResponseModel.Create(person, identityDocument);

            return Ok(iprsResponseBindingModel);
        }

        [HttpPost("identitylookupV2")]
        [ProducesResponseType(typeof(IPRSBindingResponse), 200)]
        public async Task<IActionResult> ValidateData([FromBody] ValidateBindingModel model)
        {
            _logger.LogInformation("Validate Identity");

            var validator = ValidatorFactory.Create(model.CountryCode, model.DocumentType);
            _logger.LogInformation(validator?.GetType()?.Name);
            if (validator is null)
                return BadRequest("The CountryCode or DocumentType provided could not be found, please recheck and try again");

            var (succeeded, response) = await validator.ValidateAsync(model);
            
            if (!succeeded)
                return StatusCode((int)HttpStatusCode.InternalServerError, "unable to validate document. Please try again.");
            
            return Ok(response);
        }


    }
}