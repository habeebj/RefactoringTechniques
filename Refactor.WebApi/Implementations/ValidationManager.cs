using System;
using System.Threading.Tasks;
using Refactor.WebApi.Interfaces;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Implementations
{
    public class ValidationManager : IValidationManager
    {
        public Task<(IPRSBindingResponse, string)> GetIPRSData(string countryCode, string documentType, string documentId)
        {
            throw new NotImplementedException();
        }

        public Task<(NIDABindingResponseModel, string)> GetNIDAData(string countryCode, string documentType, string documentId, string bankCode)
        {
            throw new NotImplementedException();
        }

        public Task<NIRAVerificationResponseModel> GetNIRADataAsync(string requestId)
        {
            throw new NotImplementedException();
        }

        public Task<NIRAInitiateResponseModel> InitiateNIRAVerificationAsync(string documentNumber, string serialNumber, string surname = "", string givenNames = "", DateTime? dateOfBirth = null)
        {
            throw new NotImplementedException();
        }
    }
}