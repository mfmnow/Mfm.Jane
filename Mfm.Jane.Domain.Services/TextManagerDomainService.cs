using Mfm.Jane.Domain.Contracts;
using System.Threading.Tasks;

namespace Mfm.Jane.Domain.Services
{
    public class TextManagerDomainService : ITextManagerDomainService
    {
        public Task<string> ToUpper(string textToConvert)
        {
            return Task.FromResult(textToConvert.ToUpper());
        }
    }
}
