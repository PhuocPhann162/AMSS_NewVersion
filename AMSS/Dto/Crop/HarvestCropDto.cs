namespace AMSS.Dto.Crop
{
    public class HarvestPlant
    {
        public string PlantName { get; set; }
        public string Variety { get; set; }
        public DateTime PlantingDate { get; set; }
        public DateTime ExpectedHarvestDate { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }

    public class HarvestSeed
    {
        public string SeedName { get; set; }
        public string Variety { get; set; }
        public DateTime StorageDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }

    public class HarvestExportData
    {
        public List<HarvestPlant> Plants { get; set; } = new List<HarvestPlant>();
        public List<HarvestSeed> Seeds { get; set; } = new List<HarvestSeed>();
        public DateTime GeneratedDate { get; set; } = DateTime.Now;
    }
}
