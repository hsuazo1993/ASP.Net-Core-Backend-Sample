namespace DataAccess.Models
{
    public class Fruit
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public FruitType Type { get; set; } = null!;
    }
}
