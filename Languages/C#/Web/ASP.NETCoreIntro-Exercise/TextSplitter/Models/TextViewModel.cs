namespace TextSplitter.Models
{
	using System.ComponentModel.DataAnnotations;

	public class TextViewModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Text field is required")]
		[StringLength(30, MinimumLength = 2, ErrorMessage = "The field Text must be a string with a minimum length of 2 and maximum length of 30.")]
		public string Text { get; set; }

		public string SplitText { get; set; }
	}
}
