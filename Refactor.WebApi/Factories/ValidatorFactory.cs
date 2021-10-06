using Refactor.WebApi.Helpers;

namespace Refactor.WebApi.Interface
{
    public class ValidatorFactory
    {
        public static IValidator Create(string countryCode, string documentType)
        {
            return ServiceCompositionRoot.GetService<IValidator>(v => v.CountryCode == countryCode && v.DocumentType == documentType);
        }
    }
}