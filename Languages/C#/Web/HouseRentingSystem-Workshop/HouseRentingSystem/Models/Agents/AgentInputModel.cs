namespace HouseRentingSystem.Web.Models.Agents
{
	using System.ComponentModel.DataAnnotations;

	using static HouseRentingSystem.Common.DataConstants.Agent;

	public class AgentInputModel
	{
		[Required]
		[StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
		[Display(Name = "Phone Number")]
		[Phone]
		public string PhoneNumber { get; set; } = null!;
	}
}
