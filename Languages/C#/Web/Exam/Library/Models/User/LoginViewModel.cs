namespace Library.Models.User
{
    using System.ComponentModel.DataAnnotations;

    using static Library.Data.DataConstants.ApplicationUser;

    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;
    }
}
