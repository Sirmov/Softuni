namespace HouseRentingSystem.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using HouseRentingSystem.Data;
    using HouseRentingSystem.Data.Entities;
    using HouseRentingSystem.Services.Contracts;

    public class AgentsService : IAgentsService
    {
        private readonly HouseRentingDbContext dbContext;

        public AgentsService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAgentAsync(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await this.dbContext.Agents.AddAsync(agent);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await this.dbContext.Agents.AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            return await this.dbContext.Houses.AnyAsync(h => h.RenterId == userId);
        }
        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await this.dbContext.Agents.AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
