using DTOs;

namespace BusinessLogic
{
    public interface IBLFruit
    {
        bool IsFruitValid(FruitDTO fruitDTO, out string msg);
    }
}
