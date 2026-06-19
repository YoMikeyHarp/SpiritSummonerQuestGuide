using System;
using System.Threading.Tasks;
using Plugin.Firebase.Auth;

namespace SpiritSummoner.Infrastructure.Contracts;

public interface IAuthService
{
	IFirebaseUser CurrentUser { get; }

	bool IsCurrentUserAnonymous { get; }

	event EventHandler<IFirebaseUser> UserChanged;

	global::System.Threading.Tasks.Task<IFirebaseUser> SignInWithEmailAndPasswordAsync(string email, string password);

	global::System.Threading.Tasks.Task<IFirebaseUser> CreateUserWithEmailAndPasswordAsync(string email, string password);

	global::System.Threading.Tasks.Task SignInAnonymouslyAsync();

	global::System.Threading.Tasks.Task<IFirebaseUser> SignInWithGoogle();

	global::System.Threading.Tasks.Task<IFirebaseUser> SignInWithApple();

	global::System.Threading.Tasks.Task<IFirebaseUser> SignInWithFacebook();

	global::System.Threading.Tasks.Task<IFirebaseUser> LinkWithEmailAndPasswordAsync(string email, string password);

	global::System.Threading.Tasks.Task<IFirebaseUser> LinkWithGoogleAsync();

	global::System.Threading.Tasks.Task<IFirebaseUser> LinkWithAppleAsync();

	global::System.Threading.Tasks.Task SignOutAsync();

	global::System.Threading.Tasks.Task DeleteUserAsync(string? password = null);
}
