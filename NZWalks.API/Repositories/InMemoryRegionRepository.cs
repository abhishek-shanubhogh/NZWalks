using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class InMemoryRegionRepository //: IRegionRepositories
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>
            {
                new Region{
                Id = Guid.NewGuid(),
                Code = "YO YO",
                Name = "Honey Singh"
                }
            };
        }
    }
}
