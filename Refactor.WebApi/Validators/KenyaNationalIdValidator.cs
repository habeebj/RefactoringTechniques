using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Refactor.WebApi.Enums;
using Refactor.WebApi.Helpers;
using Refactor.WebApi.Interface;
using Refactor.WebApi.Interfaces;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Validators
{
    public class KenyaNationalIdValidator : IValidator
    {
        public KenyaNationalIdValidator()
        {
        }

        public string DocumentType => DocumentTypeEnum.NationalId.ToString();

        public string CountryCode => CountryCodeEnum.KE.ToString();

        public async Task<(bool succeeded, object response)> ValidateAsync(ValidateBindingModel model)
        {
            using (var scope = ServiceCompositionRoot.BeginLifetimeScope())
            {
                var validateManager = scope.ServiceProvider.GetService<IValidationManager>();
                var response = await validateManager.GetIPRSData(model.CountryCode, model.DocumentType, model.DocumentNumber);
                return (response.Item1 is not null, response.Item1);
            }
        }
    }
}