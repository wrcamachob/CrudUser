using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepos<Entity> where Entity : class
    {
        Task<int> Add(Entity entity);
        Task<int> Update(Entity entity);
        Task<int> Delete(long id);
        Task<IEnumerable<Entity>> GetAllUsers();

    }
}
