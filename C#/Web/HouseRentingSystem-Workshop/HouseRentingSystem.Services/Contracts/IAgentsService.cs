namespace HouseRentingSystem.Services.Contracts
{
    public interface IAgentsService
    {
        public  Task<bool> ExistsByIdAsync(string userId);

        public Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

        public Task<bool> UserHasRentsAsync(string userId);

        public Task CreateAgentAsync(string userId, string phoneNumber);
    }
}
