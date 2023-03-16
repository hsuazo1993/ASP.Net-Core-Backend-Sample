using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Utils
{
    public static class SeedData
    {
        public static List<FruitType> FruitTypesData = new List<FruitType>()
        {
            new FruitType()
            {
                Id = (int) FruitTypes.Citrus,
                Name = "citrus",
                Description = "Critus are fruits such as oranges, grapefruits, mandarins and limes."
            },
            new FruitType()
            {
                Id = (int) FruitTypes.StoneFruit,
                Name = "stone fruit",
                Description = "Critus are fruits such as nectarines, apricots, peaches and plums."
            },
            new FruitType()
            {
                Id = (int) FruitTypes.TropicalAndExotic,
                Name = "tropical and exotic",
                Description = "Critus are fruits such as bananas and mangoes."
            },
            new FruitType()
            {
                Id = (int) FruitTypes.Berries,
                Name = "berries",
                Description = "Critus are fruits such as strawberries, raspberries, blueberries, kiwifruit and passionfruit."
            },
            new FruitType()
            {
                Id = (int) FruitTypes.Melons,
                Name = "melons",
                Description = "Critus are fruits such as watermelons, rockmelons and honeydew melons."
            }
        };
    }
}
