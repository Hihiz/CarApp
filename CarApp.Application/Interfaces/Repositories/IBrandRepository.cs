using CarApp.Application.Dto.Output.Brand;
using CarApp.Domain.Entities;

namespace CarApp.Application.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс репозитория марок автомобилей.
    /// </summary>
    public interface IBrandRepository
    {
        /// <summary>
        /// Метод получает список марок автомобилей, по Id производителя.
        /// </summary>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <returns>Список марок.</returns>
        Task<IEnumerable<BrandOutput>> GetBrandsByManufacturerIdAsync(int manufacturerId);

        /// <summary>
        /// Метод создает марку автомобиля.
        /// </summary>
        /// <param name="brandEntity">Модель марки автомобиля.</param>
        Task CreateBrandAsync(BrandEntity brandEntity);

        /// <summary>
        /// Метод удаляет марку автомобиля по Id.
        /// </summary>
        /// <param name="brandId">Id марки.</param>
        Task RemoveBrandByIdAsync(int brandId);
    }
}