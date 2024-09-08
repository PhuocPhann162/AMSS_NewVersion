using System.ComponentModel.DataAnnotations;

namespace AMSS.Models
{
    public class PlantSuggest
    {
        [Key]
        public int Id { get; set; }
        public string CommonName { get; set; }
        public string Family { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }
        public string Cycle { get; set; }
        public string Watering { get; set; }
        public string WateringPeriod { get; set; }
        public List<string> Sunlight { get; set; }
        public List<string> PruningMonth { get; set; }
        public int Seeds { get; set; }
        public string Maintenance { get; set; }
        public List<string> Attracts { get; set; }
        public List<string> Propagation { get; set; }
        public bool Flowers { get; set; }
        public string FloweringSeason { get; set; }
        public string Color { get; set; }
        public List<string> Soil { get; set; }
        public bool Cones { get; set; }
        public bool Fruits { get; set; }
        public bool EdibleFruit { get; set; }
        public List<string> FruitColor { get; set; }
        public object HarvestSeason { get; set; }
        public string HarvestMethod { get; set; }
        public bool Leaf { get; set; }
        public List<string> LeafColor { get; set; }
        public bool EdibleLeaf { get; set; }
        public string GrowthRate { get; set; }
        public bool Medicinal { get; set; }
        public bool PoisonousToHumans { get; set; }
        public bool PoisonousToPets { get; set; }
        public bool DroughtTolerant { get; set; }
        public bool SaltTolerant { get; set; }
        public bool Rare { get; set; }
        public string RareLevel { get; set; }
        public bool Tropical { get; set; }
        public bool Cuisine { get; set; }
        public bool Indoor { get; set; }
        public string CareLevel { get; set; }
        public string Description { get; set; }
    }
}
