namespace SimpleChat.Models
{
	public class ChatViewModel
	{
		public MessageViewModel CurrentMessage { get; set; }

		public List<MessageViewModel> Messages { get; set; }
	}
}
