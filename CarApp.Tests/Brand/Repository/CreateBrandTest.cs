using CarApp.Domain.Entities;

namespace CarApp.Tests.Brand.Repository
{
    public class CreateBrandTest : BaseIntegrationTest
    {
        [Fact]
        public async Task CreateBrandAsyncTest()
        {
            await brandRepository.CreateBrandAsync(new BrandEntity()
            {
                Title = "New brand",
                ManufacturerId = 3,
                Description = "New brand description"
            });
        }
    }
}