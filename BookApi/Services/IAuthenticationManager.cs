using BookApi.Models;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateCredentials(AuthCredentials credentials);
        Task<string> CreateToken();
    }
}
