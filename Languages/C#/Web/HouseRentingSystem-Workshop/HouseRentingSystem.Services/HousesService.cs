namespace HouseRentingSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

    using HouseRentingSystem.Data;
    using HouseRentingSystem.Services.Contracts;
    using HouseRentingSystem.Services.Dtos;

    public class HousesService : IHousesService
	{
		private readonly HouseRentingDbContext dbContext;

		public HousesService(HouseRentingDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<ICollection<HouseDto>> GetLastThreeHousesAsync()
		{
			var houses = await this.dbContext.Houses
				.OrderByDescending(h => h.Id)
				.Select(h => new HouseDto()
				{
					Id = h.Id,
					Title = h.Title,
					ImageUrl = h.ImageUrl
				})
				.Take(3)
				.ToListAsync();

			return houses;
		}
	}
}
