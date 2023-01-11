namespace Watchlist.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Watchlist.Data.DataConstants.User;

    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
