namespace CarApp.Application.Dto.Input.Brand
{
    /// <summary>
    /// Класс входной модели создания марки.
    /// </summary>
    public class CreateBrandInput
    {
        /// <summary>
        /// Название марки автомобиля.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Id производителя автомобиля.
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Описание марки автомобиля.
        /// </summary>
        public string? Description { get; set; }
    }
}
