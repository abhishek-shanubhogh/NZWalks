using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using NZWalks.API.Models.Domain;
using System.Runtime.InteropServices;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepositories
    {
        Task<List<Region>> GetAllAsync();
        Task <Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?>UpdateAsync(Guid id, Region region);

        Task <Region?> DeleteAsync(Guid id);
    }
}
