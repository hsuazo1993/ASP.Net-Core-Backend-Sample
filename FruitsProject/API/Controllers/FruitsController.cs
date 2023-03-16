using API.Utils;
using BusinessLogic;
using DataAccess.Repositories;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitsController : ControllerBase
    {
        private readonly IFruitRepository _fruitRepository;
        private readonly IBLFruit _bLFruit;

        public FruitsController(IFruitRepository fruitRepository, IBLFruit bLFruit)
        {
            _fruitRepository = fruitRepository;
            _bLFruit = bLFruit;
        }


        [HttpGet]
        public async Task<IActionResult> FindAllFruits()
        {
            ICollection<FruitDTO> fruitDTOs = await _fruitRepository.FindAll();
            return Ok(fruitDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindFruitById(long id)
        {
            FruitDTO fruitDTO = await _fruitRepository.FindById(id);
            if (fruitDTO == null)
            {
                var response = CustomResponse.Builder.NotFound("Fruit not found")
                                                     .Build();
                return NotFound(response);
            }

            return Ok(fruitDTO);
        }

        [HttpPost]
        public async Task<IActionResult> SaveFruit([FromBody] FruitDTO fruitDTO)
        {
            string msg = string.Empty;
            bool fruitIsValid = _bLFruit.IsFruitValid(fruitDTO, out msg);
            if (!fruitIsValid)
            {
                var response = CustomResponse.Builder.ValidationCriteriaNotMet(msg)
                                                     .Build();
                return BadRequest(response);
            }

            fruitDTO = await _fruitRepository.Save(fruitDTO);

            return StatusCode(StatusCodes.Status201Created, fruitDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFruit(long id, [FromBody] FruitDTO fruitDTO)
        {
            string msg = string.Empty;
            bool fruitIsValid = _bLFruit.IsFruitValid(fruitDTO, out msg);
            if (!fruitIsValid)
            {
                var response = CustomResponse.Builder.ValidationCriteriaNotMet(msg)
                                                     .Build();
                return BadRequest(response);
            }

            fruitDTO = await _fruitRepository.Update(id, fruitDTO);

            return StatusCode(StatusCodes.Status204NoContent, fruitDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFruit(long id)
        {
            bool deleted = await _fruitRepository.Delete(id);
            if (!deleted)
            {
                var response = CustomResponse.Builder.NotFound("Fruit not found")
                                     .Build();
                return NotFound(response);
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
