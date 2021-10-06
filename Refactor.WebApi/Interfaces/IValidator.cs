using System;
using System.Threading.Tasks;
using Refactor.WebApi.Enums;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Interface
{
    public interface IValidator
    {
        string DocumentType { get; }
        string CountryCode { get; }
        Task<(bool succeeded, Object response)> ValidateAsync(ValidateBindingModel model);
    }
}