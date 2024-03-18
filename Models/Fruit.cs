using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FruitIMSite.Models
{
    public class Fruit
    {

        public int FruitId { get; set; }
        public int FruitTypeId { get; set; }
        public FruitType FruitType { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double Weight { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        public DateTime DatePicked { get; set; }

        public bool HasSeeds { get; set; }

        public bool isEdible = true;

        public void MakeEdible(bool edible)
        {
            if (edible)
            {
                isEdible = true;
            }
            else
            {
                isEdible = false;
            }
        }
    }
}
