using CarApp.Application.Dto.Input.Manufacturer;
using CarApp.Application.Dto.Output.Manufacturer;
using CarApp.Domain.Entities;

namespace CarApp.Application.Interfaces.Services
{
    /// <summary>
    /// Интерфейс сервиса производителей автомобилей.
    /// </summary>
    public interface IManufacturerService
    {
        /// <summary>
        /// Метод получает список производителей автомобилей.
        /// </summary>
        /// <returns>Список производителей.</returns>
        Task<IEnumerable<ManufacturerOutput>> GetManufacturersAsync();

        /// <summary>
        /// Метод создает производителя автомобиля.
        /// </summary>
        /// <param name="createManufacturerInput">Входная модель.</param>
        /// <returns>Созданный производитель.</returns>
        Task<ManufacturerCreatedOutput> CreateManufacturerAsync(CreateManufacturerInput createManufacturerInput);

        /// <summary>
        /// Метод удаляет производителя автомобиля.
        /// </summary>
        /// <param name="manufacturerId">Id производителя автомобиля.</param>
        Task RemoveManufacturerByIdAsync(int manufacturerId);
    }
}
