namespace TaskBoardApp.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.User;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; init; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; init; } = null!;
    }
}
