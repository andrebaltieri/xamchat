using System;
using System.Threading.Tasks;

namespace XamChat.Core
{
	public class FakeWebService : IWebService
	{
		public int SleepDuration { get; set; }

		public FakeWebService ()
		{
			SleepDuration = 1;
		}

		private Task Sleep ()
		{
			return Task.Delay (SleepDuration);
		}

		public async Task<User> Login (string username, string password)
		{
			await Sleep ();
			return new User { Id = "1", Username = "andrebaltieri", Password = "andrebaltieri" };
		}

		public async Task<User> Register(User user){
			await Sleep ();
			return user;
		}

		public async Task<User[]> GetFriends(string userId){
			await Sleep ();
			return new[] 
			{
				new User { Id = "2", Username = "batman" },
				new User { Id = "3", Username = "ironman" },
				new User { Id = "4", Username = "hulk" },
				new User { Id = "5", Username = "spiderman" },
				new User { Id = "6", Username = "blackwidow" }
			};
		}

		public async Task<User> AddFriend(string userId, string username){
			await Sleep ();
			return new User { Id = "7", Username = username };
		}

		public async Task<Conversation[]> GetConversations(string userId)
		{
			await Sleep ();
			return new[] 
			{
				new Conversation { Id="1", UserId="2" }, 
				new Conversation { Id="2", UserId="3" }, 
				new Conversation { Id="3", UserId="4" }, 
				new Conversation { Id="4", UserId="5" }, 
				new Conversation { Id="5", UserId="6" } 
			};
		}

		public async Task<Message[]> GetMessages(string conversationId)
		{
			await Sleep ();
			return new[] {
				new Message { Id="1", ConversationId = conversationId, UserId="2", Text="hey Apple!" },
				new Message { Id="2", ConversationId = conversationId, UserId="1", Text="hi droid!" },
				new Message { Id="3", ConversationId = conversationId, UserId="2", Text="how are you?" },
				new Message { Id="4", ConversationId = conversationId, UserId="1", Text="fine n u?" },
				new Message { Id="5", ConversationId = conversationId, UserId="2", Text="fine 2" },
			};
		}

		public async Task<Message> SendMessage(Message message)
		{
			await Sleep();
			return message;
		}
	}
}

