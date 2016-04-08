using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace XamChat.Core
{
	public class FriendViewModel : BaseViewModel
	{
		public User[] Friends { get; private set; }

		public string Username { get; set; }

		public async Task GetFriends ()
		{
			if (settings.User == null)
				throw new Exception ("Not logged in");

			IsBusy = true;
			try {
				Friends = await service.GetFriends (settings.User.Id);
			} finally {
				IsBusy = false;
			}
		}

		public async Task AddFriend ()
		{
			if (settings.User == null)
				throw new Exception ("Not logged in");

			if (string.IsNullOrEmpty (Username))
				throw new Exception ("Username is blank");

			IsBusy = true;
			try {
				var friend = await service.AddFriend (settings.User.Id, Username);

				var friends = new List<User> ();
				if (Friends != null)
					friends.AddRange (Friends);

				friends.Add (friend);
				Friends = friends.OrderBy (x => x.Username).ToArray ();
			} finally {
				IsBusy = false;
			}
		}
	}
}

