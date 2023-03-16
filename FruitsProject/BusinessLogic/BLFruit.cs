using DTOs;

namespace BusinessLogic
{
    public class BLFruit : IBLFruit
    {
        public bool IsFruitValid(FruitDTO fruitDTO, out string msg)
        {
            if (fruitDTO == null)
            {
                msg = "Fruit information not provided";
                return false;
            }
            if (fruitDTO.TypeId == default)
            {
                msg = "Fruit type is not valid";
                return false;
            }
            if (string.IsNullOrWhiteSpace(fruitDTO.Name))
            {
                msg = "Fruit name is not valid";
                return false;
            }
            if (string.IsNullOrWhiteSpace(fruitDTO.Description))
            {
                msg = "Fruit description is not valid";
                return false;
            }
            if (fruitDTO.Description.Length < 25)
            {
                msg = "Fruit description must be at least 25 characters long";
                return false;
            }

            msg = string.Empty;
            return true;
        }
    }
}
