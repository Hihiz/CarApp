using CarApp.Api.Validators.Manufacturer;
using CarApp.Application.Dto.Input.Manufacturer;
using CarApp.Application.Dto.Output.Manufacturer;
using CarApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace CarApp.Api.Controllers
{
    /// <summary>
    /// Контроллер производителей автомобилей.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="manufacturerService">Сервис производителей автомобилей.</param>
        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        /// <summary>
        /// Метод получает список производителей автомобилей.
        /// </summary>
        /// <returns>Список производителей.</returns>
        [HttpGet]
        [Route("manufacturer")]
        public async Task<IActionResult> GetManufacturersAsync()
        {
            IEnumerable<ManufacturerOutput> result = await _manufacturerService.GetManufacturersAsync();

            return Ok(result);
        }

        /// <summary>
        /// Метод создает производителя автомобиля.
        /// </summary>
        /// <param name="createManufacturerInput">Входная модель.</param>
        /// <returns>Созданный производитель.</returns>
        [HttpPost]
        [Route("manufacturer")]
        public async Task<IActionResult> CreateManufacturerAsync([FromBody] CreateManufacturerInput
            createManufacturerInput)
        {
            ValidationResult validator = await new CreateManufacturerValidator().ValidateAsync(
                createManufacturerInput);

            if (!validator.IsValid)
            {
                return BadRequest(string.Join('\n', validator.Errors));
            }

            ManufacturerCreatedOutput result = await _manufacturerService.CreateManufacturerAsync(
                createManufacturerInput);

            return Ok(result);
        }

        /// <summary>
        /// Метод удаляет производителя автомобиля.
        /// </summary>
        /// <param name="manufacturerId">Id производителя автомобиля.</param>
        [HttpDelete]
        [Route("manufacturer")]
        public async Task<IActionResult> RemoveManufacturerAsync([FromQuery] int manufacturerId)
        {
            ValidationResult validator = await new RemoveManufacturerValidator().ValidateAsync(manufacturerId);

            if (!validator.IsValid)
            {
                return BadRequest(string.Join('\n', validator.Errors));
            }

            await _manufacturerService.RemoveManufacturerByIdAsync(manufacturerId);

            return Ok();
        }
    }
}