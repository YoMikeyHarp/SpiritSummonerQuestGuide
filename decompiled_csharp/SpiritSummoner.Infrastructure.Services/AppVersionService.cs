using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Infrastructure.Services;

public class AppVersionService : IAppVersionService
{
	private sealed class AppVersionDTO : IFirestoreObject
	{
		[FirestoreProperty("minBuildNumber")]
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public int MinBuildNumber
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	[CompilerGenerated]
	private sealed class _003CIsClientUpToDateAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public AppVersionService _003C_003E4__this;

		private IDocumentSnapshot<AppVersionDTO> _003Csnapshot_003E5__1;

		private int _003CminBuildNumber_003E5__2;

		private int _003CclientBuild_003E5__3;

		private IDocumentSnapshot<AppVersionDTO> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IDocumentSnapshot<AppVersionDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<AppVersionDTO>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetDocument("config/appVersion").GetDocumentSnapshotAsync<AppVersionDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CIsClientUpToDateAsync_003Ed__2 _003CIsClientUpToDateAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<AppVersionDTO>>, _003CIsClientUpToDateAsync_003Ed__2>(ref awaiter, ref _003CIsClientUpToDateAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<AppVersionDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003CminBuildNumber_003E5__2 = (_003Csnapshot_003E5__1?.Data?.MinBuildNumber).GetValueOrDefault();
					result = _003CminBuildNumber_003E5__2 <= 0 || !int.TryParse(AppInfo.BuildString, ref _003CclientBuild_003E5__3) || _003CclientBuild_003E5__3 >= _003CminBuildNumber_003E5__2;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("AppVersionService: Could not check version, failing open. " + _003Cex_003E5__5.Message);
					result = true;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IFirebaseFirestore _firestore;

	public AppVersionService(IFirebaseFirestore firestore)
	{
		_firestore = firestore;
	}

	[AsyncStateMachine(typeof(_003CIsClientUpToDateAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> IsClientUpToDateAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int minBuildNumber = ((await _firestore.GetDocument("config/appVersion").GetDocumentSnapshotAsync<AppVersionDTO>((Source)0))?.Data?.MinBuildNumber).GetValueOrDefault();
			if (minBuildNumber <= 0)
			{
				return true;
			}
			int clientBuild = default(int);
			if (!int.TryParse(AppInfo.BuildString, ref clientBuild))
			{
				return true;
			}
			return clientBuild >= minBuildNumber;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("AppVersionService: Could not check version, failing open. " + ex.Message);
			return true;
		}
	}
}
