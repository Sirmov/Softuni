namespace HouseRentingSystem.Services.Contracts
{
	using HouseRentingSystem.Services.Dtos;

	public interface IHousesService
	{
		public Task<ICollection<HouseDto>> GetLastThreeHousesAsync();
	}
}
