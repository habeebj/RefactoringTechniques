using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refactor.WebApi.Interfaces;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly ILogger<ValidateController> _logger;
        private readonly IIPRSProxy _iprsProxy;
        private readonly IValidationManager _validateManager;

        public ValidateController(ILogger<ValidateController> logger, IIPRSProxy iprsProxy, IValidationManager validateManager)
        {
            _logger = logger;
            _iprsProxy = iprsProxy;
            _validateManager = validateManager;
        }

        [HttpPost("identity")]
        [ProducesResponseType(typeof(IPRSBindingResponseModel), 200)]
        public async Task<IActionResult> ValidateIPRSData([FromBody] IPRSBindingModel model)
        {
            try
            {
                _logger.LogInformation("Validate Identity");
                if (model == null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = await _iprsProxy.GetData(model.CountryCode, model.DocumentType, model.DocumentNumber);
                if (response == null || response.RsData?.Status?.ResponseCode != "00")
                {
                    return BadRequest("Unable to validate IPRS");
                }
                var iprsResponseBindingModel = new IPRSBindingResponseModel
                {
                    FirstName = response.RsData.NationalIdentity.Person.PersonName.FirstName,
                    MiddleName = response.RsData.NationalIdentity.Person.PersonName.MiddleName,
                    LastName = response.RsData.NationalIdentity.Person.PersonName.LastName,
                    BirthDate = response.RsData.NationalIdentity.Person.BirthDate,
                    Gender = response.RsData.NationalIdentity.Person.GenderCode,
                    Nationality = response.RsData.NationalIdentity.Person.Nationality,
                    Occupation = response.RsData.NationalIdentity.Person.Occupation,
                    IdentityDocumentType = response.RsData.NationalIdentity.IdentityDocument.IdentityDocumentType,
                    IdentityDocumentNumber = response.RsData.NationalIdentity.IdentityDocument.IdentityDocumentID,
                    SerialNumber = response.RsData.NationalIdentity.IdentityDocument.IdentityDocumentSerialNumber,
                    IssueDate = response.RsData.NationalIdentity.IdentityDocument.IssueDate,
                    IssuingLocation = response.RsData.NationalIdentity.IdentityDocument.IssuingLocation,
                    IssuingAuthority = response.RsData.NationalIdentity.IdentityDocument.IssuingAuthority,
                };

                return Ok(iprsResponseBindingModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("identitylookup")]
        [ProducesResponseType(typeof(IPRSBindingResponse), 200)]
        public async Task<IActionResult> ValidateData([FromBody] ValidateBindingModel model)
        {
            try
            {
                _logger.LogInformation("Validate Identity");
                if (model == null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (model.CountryCode == "KE" && model.DocumentType.ToLower() == "nationalid")
                {
                    _logger.LogInformation($"Sent request for {model.DocumentNumber}");
                    var response = await _validateManager.GetIPRSData(model.CountryCode, model.DocumentType, model.DocumentNumber);
                    if (response.Item1 == null)
                    {
                        return BadRequest(response.Item2);
                    }
                    return Ok(response.Item1);
                }
                if (model.CountryCode == "RW" && model.DocumentType.ToLower() == "nationalid")
                {
                    _logger.LogInformation($"Sent request for {model.DocumentNumber}");
                    var response = await _validateManager.GetNIDAData(model.CountryCode, model.DocumentType, model.DocumentNumber, model.BankCode);


                    if (response.Item1 == null)
                    {
                        return BadRequest(response.Item2);

                    }
                    return Ok(response.Item1);
                }
                if (model.CountryCode.ToUpper() == "UG" && model.DocumentType.ToLower() == "nationalid")
                {
                    var response = await _validateManager.InitiateNIRAVerificationAsync(model.DocumentNumber, model.SerialNumber, model.Surname, model.GivenNames, model.DateOfBirth);
                    return Ok(response);
                }
                return BadRequest("The CountryCode or DocumentType provided could not be found, please recheck and try again");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}