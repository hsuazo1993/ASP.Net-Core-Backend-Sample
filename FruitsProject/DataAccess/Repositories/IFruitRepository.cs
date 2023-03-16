using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IFruitRepository
    {
        Task<ICollection<FruitDTO>> FindAll();
        Task<FruitDTO> FindById(long id);
        Task<FruitDTO> Save(FruitDTO fruitDTO);
        Task<FruitDTO> Update(long id, FruitDTO fruitDTO);
        Task<bool> Delete(long id);
    }
}
