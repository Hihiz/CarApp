using AutoMapper;
using CarApp.Application.Dto.Input.Brand;
using CarApp.Application.Dto.Output.Brand;
using CarApp.Domain.Entities;

namespace CarApp.Application.Profiles.Brand
{
    /// <summary>
    /// Класс конфигурации маппера для профиля марки автомобиля.
    /// </summary>
    public class BrandProfile : Profile
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public BrandProfile()
        {
            CreateMap<CreateBrandInput, BrandEntity>();
            CreateMap<BrandEntity, BrandCreatedOutput>();
        }
    }
}
