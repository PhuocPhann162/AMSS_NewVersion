namespace AMSS.Utility
{
    public class SD
    {
        public const string SD_Storage_Container = "amssclient";

        public const string Status_Idle = "Idle";
        public const string Status_Planted = "Planted";
        public const string Status_NeedsCare = "Needs Care";
        public const string Status_AwaitingHarvest = "Awaiting Harvest";
        public const string Status_Harvesting = "Harvesting";
        public const string Status_RecoveryNeeded = "Recovery Needed";


        public const string CsvExtension = ".csv";
        public const string ExcelExtension = ".xlsx";

        public static readonly List<string> HeaderRecordsSocialMetricTemplate = new()
        {
            "Country Name",
            "Country Code",
            "Province Name", 
            "Province Code",
            "Series Name",
            "Series Code",
        };

        public const string ClaimType_Id = "id";
    }
}
