using AMSS.Dto.CountryContinent;
using AMSS.Dto.Crop;
using AMSS.Dto.CropType;
using AMSS.Dto.Farm;
using AMSS.Dto.Field;
using AMSS.Dto.FieldCrop;
using AMSS.Dto.Location;
using AMSS.Dto.Polygon;
using AMSS.Dto.Position;
using AMSS.Dto.Province;
using AMSS.Dto.Responses.Commodities;
using AMSS.Dto.SeriesMetric;
using AMSS.Dto.SocialMetric;
using AMSS.Dto.SocialYear;
using AMSS.Dto.SoilQuality;
using AMSS.Dto.User;
using AMSS.Entities;
using AMSS.Entities.Polygon;
using AMSS.Models.Commodities;
using AutoMapper;

namespace AMSS.Utility
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // User
                config.CreateMap<ApplicationUser, UserDto>().ReverseMap();

                // Location
                config.CreateMap<Location, LocationDto>().ReverseMap();
                config.CreateMap<Location, CreateLocationDto>().ReverseMap();

                // Farm
                config.CreateMap<Farm, FarmDto>().ReverseMap();
                config.CreateMap<Farm, CreateFarmDto>().ReverseMap();

                // Field
                config.CreateMap<Field, FieldDto>().ReverseMap();
                config.CreateMap<Field, CreateFieldDto>().ReverseMap();
                config.CreateMap<Field, UpdateFieldDto>().ReverseMap();

                // FieldCrop
                config.CreateMap<FieldCrop, FieldCropDto>().ReverseMap();

                // Crop
                config.CreateMap<Crop, CropDto>().ReverseMap();
                config.CreateMap<Crop, CreateCropDto>().ReverseMap();

                // CropType
                config.CreateMap<CropType, CropTypeDto>().ReverseMap();
                config.CreateMap<CropType, CreateCropTypeDto>().ReverseMap();

                // Polygon 
                config.CreateMap<PolygonApp, PolygonDto>().ReverseMap();
                config.CreateMap<PolygonApp, CreatePolygonDto>().ReverseMap();
                config.CreateMap<PolygonApp, UpdatePolygonDto>().ReverseMap();

                // Position 
                config.CreateMap<Position, PositionDto>().ReverseMap();

                // Soil Quality 
                config.CreateMap<SoilQuality, SoilQualityDto>().ReverseMap();

                // Country Continent
                config.CreateMap<CountryContinent, CountryContinentDto>().ReverseMap();

                // Province 
                config.CreateMap<Province, ProvinceDto>().ReverseMap();

                // SeriesMetric 
                config.CreateMap<SeriesMetric, SeriesMetricDto>().ReverseMap();

                // Social Metric
                config.CreateMap<SocialMetric, SocialMetricDto>().ReverseMap();

                // Social Year 
                config.CreateMap<SocialYear, SocialYearDto>().ReverseMap();

                // Commodity 
                config.CreateMap<Commodity, GetCommodityResponse>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
