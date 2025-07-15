namespace CarApp.Domain.Entities;

/// <summary>
/// Класс марки автомобиля сопоставляется с таблицей public.Brand.
/// </summary>
public class BrandEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название марки автомобиля.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// FK Id производителя автомобиля.
    /// </summary>
    public int ManufacturerId { get; set; }

    /// <summary>
    /// Навигационное свойство.
    /// </summary>
    public ManufacturerEntity? Manufacturer { get; set; }

    /// <summary>
    /// Описание марки автомобиля.
    /// </summary>
    public string? Description { get; set; }
}