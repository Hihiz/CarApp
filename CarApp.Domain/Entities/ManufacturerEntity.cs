namespace CarApp.Domain.Entities;

/// <summary>
/// Класс производителя автомобиля сопоставляется с таблицей public.Manufacturer.
/// </summary>
public class ManufacturerEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название производителя автомобиля.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Список марок автомобилей, которые связанные с производителем.
    /// </summary>
    public ICollection<BrandEntity> Brands { get; set; } = new List<BrandEntity>();
}