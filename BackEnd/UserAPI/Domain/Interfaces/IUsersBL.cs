using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsersBL<T>
    {
        Task<IEnumerable<UsersModel>> GetAll();

        Task<string> Insert(UsersModel cliente);

        Task<string> Update(UsersModel cliente);

        Task<string> Delete(long id);
    }
}
