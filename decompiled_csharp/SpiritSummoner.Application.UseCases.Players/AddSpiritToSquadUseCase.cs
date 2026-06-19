using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Application.UseCases.Players;

public class AddSpiritToSquadUseCase : IUseCase<AddSpiritToSquadRequest, AddSpiritToSquadResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public AddSpiritToSquadRequest request;

		public AddSpiritToSquadUseCase _003C_003E4__this;

		internal ValidationResult _003CExecuteAsync_003Eb__0(Player player)
		{
			if (!player.PlayerSpirits.ContainsKey(request.SpiritId))
			{
				return ValidationResult.Failure("Spirit not found in player's collection");
			}
			PlayerSpirit playerSpirit = player.PlayerSpirits[request.SpiritId];
			Spirit spiritTemplate = _003C_003E4__this._stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
			int activeSquadSlot = player.ActiveSquadSlot;
			List<string> val = player.Squads[activeSquadSlot.ToString()];
			bool flag = val.Contains(request.SpiritId);
			if (spiritTemplate != null && spiritTemplate.IsUnique && !flag)
			{
				PlayerSpirit playerSpirit2 = default(PlayerSpirit);
				for (int i = 0; i < val.Count; i++)
				{
					if (i == request.PositionInSquad)
					{
						continue;
					}
					string text = val[i];
					if (!string.IsNullOrEmpty(text) && !(text == request.SpiritId) && player.PlayerSpirits.TryGetValue(text, ref playerSpirit2))
					{
						Spirit spiritTemplate2 = _003C_003E4__this._stateService.GetSpiritTemplate(playerSpirit2.BaseSpiritID);
						if (spiritTemplate2 != null && spiritTemplate2.IsUnique)
						{
							return ValidationResult.Failure("A squad can only contain one unique spirit");
						}
					}
				}
			}
			return ValidationResult.Success();
		}

		internal _003C_003Ef__AnonymousType3<int, List<string>> _003CExecuteAsync_003Eb__1(Player player)
		{
			int activeSquadSlot = player.ActiveSquadSlot;
			List<string> val = new List<string>((global::System.Collections.Generic.IEnumerable<string>)player.Squads[activeSquadSlot.ToString()]);
			string text = val[request.PositionInSquad];
			int num = val.IndexOf(request.SpiritId);
			if (num >= 0)
			{
				val[num] = text;
				val[request.PositionInSquad] = request.SpiritId;
			}
			else
			{
				val[request.PositionInSquad] = request.SpiritId;
			}
			player.UpdateSquad(activeSquadSlot, val);
			return new
			{
				activeSquadSlot = activeSquadSlot,
				currentSquad = val
			};
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player player, _003C_003Ef__AnonymousType3<int, List<string>> updateResult)
		{
			return new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				SquadUpdates = new Dictionary<string, List<string>> { [updateResult.activeSquadSlot.ToString()] = updateResult.currentSquad },
				SlotInSquad = request.PositionInSquad,
				NewActiveSquadComp = updateResult.currentSquad
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<AddSpiritToSquadResponse>> _003C_003Et__builder;

		public AddSpiritToSquadRequest request;

		public AddSpiritToSquadUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass2_0 _003C_003E8__1;

		private Player _003Cplayer_003E5__2;

		private Result<_003C_003Ef__AnonymousType3<int, List<string>>> _003Cresult_003E5__3;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			Result<AddSpiritToSquadResponse> result;
			try
			{
				_003C_003E8__1 = new _003C_003Ec__DisplayClass2_0();
				_003C_003E8__1.request = request;
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				_003Cplayer_003E5__2 = _003C_003E4__this._stateService.GetCurrentPlayer();
				if (_003Cplayer_003E5__2 == null)
				{
					result = Result<AddSpiritToSquadResponse>.FailureResult("Player not found");
				}
				else if (_003C_003E8__1.request.PositionInSquad < 0 || _003C_003E8__1.request.PositionInSquad > 2)
				{
					result = Result<AddSpiritToSquadResponse>.FailureResult("Position in squad must be between 0 and 2");
				}
				else if (string.IsNullOrEmpty(_003C_003E8__1.request.SpiritId))
				{
					result = Result<AddSpiritToSquadResponse>.FailureResult("Spirit ID cannot be empty");
				}
				else
				{
					_003Cresult_003E5__3 = _003C_003E4__this._stateService.ExecuteUpdate(delegate(Player player)
					{
						if (!player.PlayerSpirits.ContainsKey(_003C_003E8__1.request.SpiritId))
						{
							return ValidationResult.Failure("Spirit not found in player's collection");
						}
						PlayerSpirit playerSpirit = player.PlayerSpirits[_003C_003E8__1.request.SpiritId];
						Spirit spiritTemplate = _003C_003E8__1._003C_003E4__this._stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
						int activeSquadSlot2 = player.ActiveSquadSlot;
						List<string> val2 = player.Squads[activeSquadSlot2.ToString()];
						bool flag = val2.Contains(_003C_003E8__1.request.SpiritId);
						if (spiritTemplate != null && spiritTemplate.IsUnique && !flag)
						{
							PlayerSpirit playerSpirit2 = default(PlayerSpirit);
							for (int i = 0; i < val2.Count; i++)
							{
								if (i != _003C_003E8__1.request.PositionInSquad)
								{
									string text3 = val2[i];
									if (!string.IsNullOrEmpty(text3) && !(text3 == _003C_003E8__1.request.SpiritId) && player.PlayerSpirits.TryGetValue(text3, ref playerSpirit2))
									{
										Spirit spiritTemplate2 = _003C_003E8__1._003C_003E4__this._stateService.GetSpiritTemplate(playerSpirit2.BaseSpiritID);
										if (spiritTemplate2 != null && spiritTemplate2.IsUnique)
										{
											return ValidationResult.Failure("A squad can only contain one unique spirit");
										}
									}
								}
							}
						}
						return ValidationResult.Success();
					}, delegate(Player player)
					{
						int activeSquadSlot = player.ActiveSquadSlot;
						List<string> val = new List<string>((global::System.Collections.Generic.IEnumerable<string>)player.Squads[activeSquadSlot.ToString()]);
						string text2 = val[_003C_003E8__1.request.PositionInSquad];
						int num2 = val.IndexOf(_003C_003E8__1.request.SpiritId);
						if (num2 >= 0)
						{
							val[num2] = text2;
							val[_003C_003E8__1.request.PositionInSquad] = _003C_003E8__1.request.SpiritId;
						}
						else
						{
							val[_003C_003E8__1.request.PositionInSquad] = _003C_003E8__1.request.SpiritId;
						}
						player.UpdateSquad(activeSquadSlot, val);
						return new
						{
							activeSquadSlot = activeSquadSlot,
							currentSquad = val
						};
					}, (Player player, updateResult) => new PlayerBatchUpdate
					{
						PlayerId = (player.PlayerID ?? string.Empty),
						SquadUpdates = new Dictionary<string, List<string>> { [updateResult.activeSquadSlot.ToString()] = updateResult.currentSquad },
						SlotInSquad = _003C_003E8__1.request.PositionInSquad,
						NewActiveSquadComp = updateResult.currentSquad
					});
					result = (_003Cresult_003E5__3.Success ? Result<AddSpiritToSquadResponse>.SuccessResult(new AddSpiritToSquadResponse(_003C_003E8__1.request.PositionInSquad, _003C_003E8__1.request.SpiritId)) : Result<AddSpiritToSquadResponse>.FailureResult(_003Cresult_003E5__3.ErrorMessage ?? "Failed"));
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cplayer_003E5__2 = null;
				_003Cresult_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cplayer_003E5__2 = null;
			_003Cresult_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	public AddSpiritToSquadUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<AddSpiritToSquadResponse>> ExecuteAsync(AddSpiritToSquadRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		AddSpiritToSquadRequest request2 = request;
		Player player2 = _stateService.GetCurrentPlayer();
		if (player2 == null)
		{
			return Result<AddSpiritToSquadResponse>.FailureResult("Player not found");
		}
		if (request2.PositionInSquad < 0 || request2.PositionInSquad > 2)
		{
			return Result<AddSpiritToSquadResponse>.FailureResult("Position in squad must be between 0 and 2");
		}
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return Result<AddSpiritToSquadResponse>.FailureResult("Spirit ID cannot be empty");
		}
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			if (!player.PlayerSpirits.ContainsKey(request2.SpiritId))
			{
				return ValidationResult.Failure("Spirit not found in player's collection");
			}
			PlayerSpirit playerSpirit = player.PlayerSpirits[request2.SpiritId];
			Spirit spiritTemplate = _stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
			int activeSquadSlot2 = player.ActiveSquadSlot;
			List<string> val2 = player.Squads[activeSquadSlot2.ToString()];
			bool flag = val2.Contains(request2.SpiritId);
			if (spiritTemplate != null && spiritTemplate.IsUnique && !flag)
			{
				PlayerSpirit playerSpirit2 = default(PlayerSpirit);
				for (int i = 0; i < val2.Count; i++)
				{
					if (i != request2.PositionInSquad)
					{
						string text3 = val2[i];
						if (!string.IsNullOrEmpty(text3) && !(text3 == request2.SpiritId) && player.PlayerSpirits.TryGetValue(text3, ref playerSpirit2))
						{
							Spirit spiritTemplate2 = _stateService.GetSpiritTemplate(playerSpirit2.BaseSpiritID);
							if (spiritTemplate2 != null && spiritTemplate2.IsUnique)
							{
								return ValidationResult.Failure("A squad can only contain one unique spirit");
							}
						}
					}
				}
			}
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			int activeSquadSlot = player.ActiveSquadSlot;
			List<string> val = new List<string>((global::System.Collections.Generic.IEnumerable<string>)player.Squads[activeSquadSlot.ToString()]);
			string text2 = val[request2.PositionInSquad];
			int num = val.IndexOf(request2.SpiritId);
			if (num >= 0)
			{
				val[num] = text2;
				val[request2.PositionInSquad] = request2.SpiritId;
			}
			else
			{
				val[request2.PositionInSquad] = request2.SpiritId;
			}
			player.UpdateSquad(activeSquadSlot, val);
			return new
			{
				activeSquadSlot = activeSquadSlot,
				currentSquad = val
			};
		}, (Player player, updateResult) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			SquadUpdates = new Dictionary<string, List<string>> { [updateResult.activeSquadSlot.ToString()] = updateResult.currentSquad },
			SlotInSquad = request2.PositionInSquad,
			NewActiveSquadComp = updateResult.currentSquad
		});
		if (!result.Success)
		{
			return Result<AddSpiritToSquadResponse>.FailureResult(result.ErrorMessage ?? "Failed");
		}
		return Result<AddSpiritToSquadResponse>.SuccessResult(new AddSpiritToSquadResponse(request2.PositionInSquad, request2.SpiritId));
	}
}
