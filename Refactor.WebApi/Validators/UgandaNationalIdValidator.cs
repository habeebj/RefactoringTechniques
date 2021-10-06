using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Refactor.WebApi.Enums;
using Refactor.WebApi.Helpers;
using Refactor.WebApi.Interface;
using Refactor.WebApi.Interfaces;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Validators
{
    public class UgandaNationalIdValidator : IValidator
    {
        public UgandaNationalIdValidator()
        {
        }

        public string DocumentType => DocumentTypeEnum.NationalId.ToString();

        public string CountryCode => CountryCodeEnum.UG.ToString();

        public async Task<(bool succeeded, object response)> ValidateAsync(ValidateBindingModel model)
        {
            using (var scope = ServiceCompositionRoot.BeginLifetimeScope())
            {
                var validateManager = scope.ServiceProvider.GetService<IValidationManager>();
                var response = await validateManager.InitiateNIRAVerificationAsync(model.DocumentNumber, model.SerialNumber, model.Surname, model.GivenNames, model.DateOfBirth);
                return (response is not null, response);
            }
        }
    }
}