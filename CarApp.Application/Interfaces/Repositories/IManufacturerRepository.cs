using CarApp.Application.Dto.Output.Manufacturer;
using CarApp.Domain.Entities;

namespace CarApp.Application.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс репозитория производителей автомобилей.
    /// </summary>
    public interface IManufacturerRepository
    {
        /// <summary>
        /// Метод получает список производителей автомобилей.
        /// </summary>
        /// <returns>Список производителей.</returns>
        Task<IEnumerable<ManufacturerOutput>> GetManufacturersAsync();

        /// <summary>
        /// Метод создает производителя автомобиля.
        /// </summary>
        /// <param name="manufacturerEntity">Модель производителя.</param>
        Task CreateManufacturerAsync(ManufacturerEntity manufacturerEntity);

        /// <summary>
        /// Метод удаляет производителя автомобиля.
        /// </summary>
        /// <param name="manufacturerId">Id производителя автомобиля.</param>
        Task RemoveManufacturerByIdAsync(int manufacturerId);
    }
}