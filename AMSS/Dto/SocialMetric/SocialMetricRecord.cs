using AMSS.Utility;
using CsvHelper.Configuration;

namespace AMSS.Dto.SocialMetric
{
    public class SocialMetricRecord
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public string SeriesName { get; set; }
        public string SeriesCode { get; set; }
        public Dictionary<int, double?> YearData { get; set; } = new Dictionary<int, double?>();
    }

    public sealed class SocialMetricRecordMap : ClassMap<SocialMetricRecord>
    {
        public SocialMetricRecordMap()
        {
            Map(m => m.CountryName).Name(SD.HeaderRecordsSocialMetricTemplate[0]);
            Map(m => m.CountryCode).Name(SD.HeaderRecordsSocialMetricTemplate[1]);
            Map(m => m.ProvinceName).Name(SD.HeaderRecordsSocialMetricTemplate[2]);
            Map(m => m.ProvinceCode).Name(SD.HeaderRecordsSocialMetricTemplate[3]);
            Map(m => m.SeriesName).Name(SD.HeaderRecordsSocialMetricTemplate[4]);
            Map(m => m.SeriesCode).Name(SD.HeaderRecordsSocialMetricTemplate[5]);
        }
    }
}
