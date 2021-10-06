using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Refactor.WebApi.Enums;
using Refactor.WebApi.Helpers;
using Refactor.WebApi.Interface;
using Refactor.WebApi.Interfaces;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Validators
{
    public class RwandaNationalIdValidator : IValidator
    {
        public RwandaNationalIdValidator()
        {
        }

        public string DocumentType => DocumentTypeEnum.NationalId.ToString();

        public string CountryCode => CountryCodeEnum.RW.ToString();

        public async Task<(bool succeeded, object response)> ValidateAsync(ValidateBindingModel model)
        {
            using (var scope = ServiceCompositionRoot.BeginLifetimeScope())
            {
                var validateManager = scope.ServiceProvider.GetService<IValidationManager>();
                var response = await validateManager.GetNIDAData(model.CountryCode, model.DocumentType, model.DocumentNumber, model.BankCode);
                return (response.Item1 is null, response.Item1);
            }
        }
    }
}