using System.Threading.Tasks;
using DatinApp.Api.Models;

namespace DatinApp.Api.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string user, string password);
         Task<bool> UserExists(string username);
    }
}