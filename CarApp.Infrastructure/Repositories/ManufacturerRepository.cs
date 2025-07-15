using CarApp.Application.Dto.Output.Brand;
using CarApp.Application.Dto.Output.Manufacturer;
using CarApp.Application.Interfaces.Repositories;
using CarApp.Domain.Entities;
using CarApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarApp.Infrastructure.Repositories
{
    /// <summary>
    /// Класс реализует методы репозитория производителей автомобилей.
    /// </summary>
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="db">Класс контекста БД.</param>
        public ManufacturerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        #region Публичные методы.

        /// <inheritdoc />
        public async Task<IEnumerable<ManufacturerOutput>> GetManufacturersAsync()
        {
            List<ManufacturerOutput> result = await _db.Manufacturers
                .AsNoTracking()
                .Select(m => new ManufacturerOutput
                {
                    Id = m.Id,
                    Title = m.Title,
                    Brands = m.Brands.Select(b => new BrandOutput
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Description = b.Description
                    }).ToList()
                })
                .OrderBy(m => m.Id)
                .ToListAsync();

            return result;
        }

        /// <inheritdoc />
        public async Task CreateManufacturerAsync(ManufacturerEntity manufacturerEntity)
        {
            await _db.Manufacturers.AddAsync(manufacturerEntity);
            await _db.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task RemoveManufacturerByIdAsync(int manufacturerId)
        {
            using IDbContextTransaction transaction = await _db.Database.BeginTransactionAsync(System.Data
              .IsolationLevel.ReadCommitted);

            try
            {
                // Удаляем марки которые связаны с производителем.
                int removedBrands = await _db.Brands
                     .Where(b => b.ManufacturerId == manufacturerId)
                     .ExecuteDeleteAsync();

                if (removedBrands <= 0)
                {
                    throw new InvalidOperationException(
                        "Ошибка удаления марок автомобилей, которые связанные с производителем. " +
                        $"ManufacturerId: {manufacturerId}.");
                }

                // Удаляем производителя.
                await _db.Manufacturers
                    .Where(m => m.Id == manufacturerId)
                    .ExecuteDeleteAsync();

                await transaction.CommitAsync();
            }

            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        #endregion

        #region Приватные методы.

        #endregion
    }
}