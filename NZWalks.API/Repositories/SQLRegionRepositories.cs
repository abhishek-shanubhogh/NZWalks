using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepositories : IRegionRepositories
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepositories(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
             await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var exsitingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (exsitingRegion != null) { return null; }
            dbContext.Regions.Remove(exsitingRegion);
            await dbContext.SaveChangesAsync();
            return exsitingRegion;

        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
            
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var exisitingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (exisitingRegion == null) { return null; }
            exisitingRegion.Code = region.Code;
            exisitingRegion.Name =  region.Name;    
            exisitingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return exisitingRegion;


        }
    }
}
