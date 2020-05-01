using System.Threading.Tasks;

namespace Mfm.Jane.Domain.Contracts
{
    public interface ITextManagerDomainService
    {
        Task<string> ToUpper(string textToConvert);
    }
}
