using DataAccess.Models;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class FruitRepository : IFruitRepository
    {
        private readonly FruitContext _fruitContext;

        public FruitRepository(FruitContext fruitContext)
        {
            _fruitContext = fruitContext;
        }


        public async Task<ICollection<FruitDTO>> FindAll()
        {
            return await _fruitContext.Fruits.AsQueryable()
                                             .AsNoTracking()
                                             .Select(e => new FruitDTO()
                                             {
                                                 Id = e.Id,
                                                 Name = e.Name,
                                                 Description = e.Description,
                                                 TypeId = e.TypeId
                                             }).ToListAsync();
        }
        public async Task<FruitDTO> FindById(long id)
        {
            return await _fruitContext.Fruits.AsQueryable()
                                             .AsNoTracking()
                                             .Where(e => e.Id == id)
                                             .Select(e => new FruitDTO()
                                             {
                                                 Id = e.Id,
                                                 Name = e.Name,
                                                 Description = e.Description,
                                                 TypeId = e.TypeId
                                             }).FirstOrDefaultAsync();
        }
        public async Task<FruitDTO> Save(FruitDTO fruitDTO)
        {
            Fruit newFruit = new Fruit()
            {
                Name = fruitDTO.Name,
                Description = fruitDTO.Description,
                TypeId = fruitDTO.TypeId
            };
            await _fruitContext.Fruits.AddAsync(newFruit);
            await _fruitContext.SaveChangesAsync();


            return await FindById(newFruit.Id);
        }
        public async Task<FruitDTO> Update(long id, FruitDTO fruitDTO)
        {
            Fruit fruit = await _fruitContext.Fruits.AsQueryable()
                                                    .FirstOrDefaultAsync(e => e.Id == id);

            if (fruit == null) return fruitDTO;


            fruit.Name = fruitDTO.Name;
            fruit.Description = fruitDTO.Description;
            fruit.TypeId = fruitDTO.TypeId;

            await _fruitContext.SaveChangesAsync();

            return fruitDTO;
        }
        public async Task<bool> Delete(long id)
        {
            Fruit fruit = await _fruitContext.Fruits.AsQueryable()
                                                    .FirstOrDefaultAsync(e => e.Id == id);

            if (fruit == null) return false;


            _fruitContext.Fruits.Remove(fruit);
            await _fruitContext.SaveChangesAsync();

            return true;
        }
    }
}
