using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Database
{
    public interface ILocalDataService
    {
        void Initialize();

        void CreateUser(User user);
        User GetUser();
        void DeleteUser(User user);
    }
}
