﻿using AMSS.Models;
using AMSS.Models.Dto.CountryContinent;
using AMSS.Models.Dto.Crop;
using AMSS.Models.Dto.CropType;
using AMSS.Models.Dto.Farm;
using AMSS.Models.Dto.Field;
using AMSS.Models.Dto.FieldCrop;
using AMSS.Models.Dto.Location;
using AMSS.Models.Dto.Polygon;
using AMSS.Models.Dto.Position;
using AMSS.Models.Dto.Province;
using AMSS.Models.Dto.SeriesMetric;
using AMSS.Models.Dto.SocialMetric;
using AMSS.Models.Dto.SocialYear;
using AMSS.Models.Dto.SoilQuality;
using AMSS.Models.Dto.User;
using AMSS.Models.Polygon;
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
            });

            return mappingConfig;
        }
    }
}
