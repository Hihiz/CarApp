namespace CarApp.Application.Dto.Output.Brand
{
    /// <summary>
    /// Класс выходной модели марки автомобиля.
    /// </summary>
    public class BrandOutput
    {
        /// <summary>
        /// Id марки.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название марки автомобиля.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Описание марки автомобиля.
        /// </summary>
        public string? Description { get; set; }
    }
}
