using System.Threading.Tasks;
using Refactor.WebApi.Models;

namespace Refactor.WebApi.Interfaces
{
    public interface IIPRSProxy
    {
         Task<ESBMsg> GetData(string countryCode, string DocumentType, string documentId);
    }
}