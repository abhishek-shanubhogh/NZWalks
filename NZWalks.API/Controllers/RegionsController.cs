using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Domain.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepositories regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext,IRegionRepositories regionRepository,IMapper mapper) {

            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //https://localhost:portnumber/api/regions
        



        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id=Guid.NewGuid(),
            //        Name="Auckland Region",
            //        Code="AKL",
            //        RegionImageUrl="https://www.pexels.com/photo/sky-tower-in-auckland-831910/"
            //    },
            //     new Region
            //    {
            //        Id=Guid.NewGuid(),
            //        Name="Wellindton Region",
            //        Code="WLG",
            //        RegionImageUrl="https://www.pexels.com/photo/equestrian-statue-of-duke-of-wellington-near-city-buildings-5870360/"
            //    },

            //};
            //var regionsDomain = await dbContext.Regions.ToListAsync();
            var regionsDomain=await regionRepository.GetAllAsync();


            //var regionsDto = new List<RegionDTO>();
            //foreach (var region in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDTO() 
            //    {
            //        Id=region.Id,
            //        Code=region.Code,
            //        Name=region.Name,
            //        RegionImageUrl=region.RegionImageUrl
            //    });
            //}

           // var regionsDto =mapper.Map<List<RegionDTO>>(regionsDomain);
           //return Ok(regionDto)

            return Ok(mapper.Map<List<RegionDTO>>(regionsDomain));
        }
        


        
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById( [FromRoute]Guid id)
        {
            //var region =dbContext.Regions.Find(id);
            // var regionDomain  = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomain =await regionRepository.GetByIdAsync(id);



            if (regionDomain == null)
            {
                return NotFound();
            }
            //var regiondto = new regiondto
            //{
            //    id = regiondomain.id,
            //    code = regiondomain.code,
            //    name = regiondomain.name,
            //    regionimageurl = regiondomain.regionimageurl
            //};

            // var regionDto = mapper.Map<RegionDTO>(regionDomain);
            //return Ok(regionDto); 
            return Ok(mapper.Map<RegionDTO>(regionDomain)); 
            
        }



        
        [HttpPost]
        public async Task<IActionResult >Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            //var regionDomainModel = new Region
            //{
            //    Code = addRegionRequestDTO.Code,
            //    Name = addRegionRequestDTO.Name,
            //    RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            //};
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDTO);

            //await dbContext.Regions.AddAsync(regionDomainModel);
            //await dbContext.SaveChangesAsync();
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            //var regionDTO = regionDomainModel;

            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);
            return CreatedAtAction(nameof(GetById), new {id= regionDTO.Id}, regionDTO);
        }



        
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult >UpdateRegion([FromRoute] Guid id,[FromBody]UpdateRegionRequestDTO x)
        {
            //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(y => y.Id == id);

            //var regionDomain = new Region
            //{
            //    Code = x.Code,
            //    Name = x.Name,
            //    RegionImageUrl = x.RegionImageUrl,
            //};

            var regionDomain=mapper.Map<Region>(x);

            regionDomain=await regionRepository.UpdateAsync(id, regionDomain);

            if (regionDomain == null )
            {
                return NotFound();
                
            }
            //regionDomain.Code = x.Code;
            //regionDomain.Name = x.Name;
            //regionDomain.RegionImageUrl = x.RegionImageUrl;
            //await dbContext.SaveChangesAsync();

            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl

            //};

            //var regionDto = mapper.Map<RegionDTO>(regionDomain);
            //return Ok(regionDto);
            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }




        
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult >DeleteRegion([FromRoute] Guid id)
        {
            //  var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var regionDomain = await regionRepository.DeleteAsync(id);

            if (regionDomain == null) { return NotFound(); }

            //dbContext.Regions.Remove(regionDomain);
            //await dbContext.SaveChangesAsync();

            //Return Deleted Region
            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl

            //};
            //var regionDto= mapper.Map<RegionDTO>(regionDomain); 

            //return Ok(regionDto);
            return Ok(mapper.Map<RegionDTO>(regionDomain));

        }

    }
}
