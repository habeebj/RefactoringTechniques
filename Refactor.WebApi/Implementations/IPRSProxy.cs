using System.Threading.Tasks;
using Refactor.WebApi.Interfaces;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Implementations
{
    public class IPRSProxy : IIPRSProxy
    {
        public Task<ESBMsg> GetData(string countryCode, string DocumentType, string documentId)
        {
            throw new System.NotImplementedException();
        }
    }
}