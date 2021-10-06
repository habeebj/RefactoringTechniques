using System;
using System.Threading.Tasks;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Interfaces
{
    public interface IValidationManager
    {
        Task<(IPRSBindingResponse, string)> GetIPRSData(string countryCode, string documentType, string documentId);
        Task<(NIDABindingResponseModel, string)> GetNIDAData(string countryCode, string documentType, string documentId, string bankCode);
        Task<NIRAInitiateResponseModel> InitiateNIRAVerificationAsync(string documentNumber, string serialNumber, string surname = "", string givenNames = "", DateTime? dateOfBirth = null);
        Task<NIRAVerificationResponseModel> GetNIRADataAsync(string requestId);
    }
}