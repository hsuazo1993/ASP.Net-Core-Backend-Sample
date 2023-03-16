﻿using System.Collections.Generic;

namespace DataAccess.Models
{
    public class FruitType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Fruit> Fruits { get; set; }
    }
}
