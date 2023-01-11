namespace SimpleChat.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using SimpleChat.Models;

	public class ChatController : Controller
	{
		private static List<KeyValuePair<string, string>> Messages = new();

		public IActionResult Show()
		{
			var chat = new ChatViewModel()
			{
				Messages = Messages
					.Select(m => new MessageViewModel()
					{
						Sender = m.Key,
						MessageText = m.Value
					})
					.ToList()
			};

			return View(chat);
		}

		[HttpPost]
		public IActionResult Send(ChatViewModel chat)
		{
			 MessageViewModel message = chat.CurrentMessage;

			Messages.Add(new KeyValuePair<string, string>(message.Sender, message.MessageText));

			return RedirectToAction(nameof(Show));
		}
	}
}
