using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.ValueObjects.Battle;

namespace SpiritSummoner.Domain.Services;

public class SpecialAbilityService : ISpecialAbilityService
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public SquadSynergyEffect synergy;

		internal bool _003CHandleSquadSynergyEffects_003Eb__0(BattleSprite s)
		{
			return ((object)s.BaseSpirit.Type1).ToString().Equals(synergy.RequiredType, (StringComparison)5) || ((object)s.BaseSpirit.Type2).ToString().Equals(synergy.RequiredType, (StringComparison)5);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public SpecialAbilityService _003C_003E4__this;

		public BattleMode battleMode;

		public HashSet<string> bearerIds;

		public Func<BattleSprite, bool> _003C_003E9__2;

		internal bool _003CApplyGuardianAngelAuraHeal_003Eb__0(BattleSprite s)
		{
			return _003C_003E4__this.HasSpecialAbility(s, "guardianAngelAura", battleMode);
		}

		internal bool _003CApplyGuardianAngelAuraHeal_003Eb__2(BattleSprite s)
		{
			return s.HP > 0 && !bearerIds.Contains(s.PlayerSpirit.PlayerSpiritID);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public BattleSprite koSpirit;

		internal bool _003CHandleComebackKidEffect_003Eb__0(BattleSprite s)
		{
			return s.HP > 0 && s.PlayerSpirit.PlayerSpiritID != koSpirit.PlayerSpirit.PlayerSpiritID;
		}
	}

	[CompilerGenerated]
	private sealed class _003CApplyDamageOverTime_003Ed__35 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleSprite sprite;

		public BattleMode battleMode;

		public float fatigueMultiplier;

		public SpecialAbilityService _003C_003E4__this;

		private global::System.Collections.Generic.IEnumerator<ValueTuple<string, Item>> _003C_003Es__1;

		private string _003Cslot_003E5__2;

		private Item _003Citem_003E5__3;

		private float _003CrawDamage_003E5__4;

		private int _003CdmgInt_003E5__5;

		private int _003ChpBefore_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003Es__1 = GetActiveSlotItems(sprite, battleMode).GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__1).MoveNext())
						{
							ValueTuple<string, Item> current = _003C_003Es__1.Current;
							_003Cslot_003E5__2 = current.Item1;
							_003Citem_003E5__3 = current.Item2;
							ItemEffect? effect = _003Citem_003E5__3.Effect;
							if (effect != null && effect.DamagePerTurn > 0f)
							{
								_003CrawDamage_003E5__4 = ((_003Citem_003E5__3.Effect.DamagePerTurn < 1f) ? ((float)sprite.MaxHP * _003Citem_003E5__3.Effect.DamagePerTurn) : _003Citem_003E5__3.Effect.DamagePerTurn);
								_003CdmgInt_003E5__5 = (int)(_003CrawDamage_003E5__4 * fatigueMultiplier);
								if (_003CdmgInt_003E5__5 > 0)
								{
									_003ChpBefore_003E5__6 = sprite.HP;
									sprite.HP = Math.Max(0, sprite.HP - _003CdmgInt_003E5__5);
									Debug.WriteLine($"[AbilityFX] [{_003Cslot_003E5__2}] damagePerTurn {_003Citem_003E5__3.Name} ({sprite.BaseSpirit.Name}) — -{_003CdmgInt_003E5__5} HP ({_003ChpBefore_003E5__6}→{sprite.HP}/{sprite.MaxHP})");
									_003Cslot_003E5__2 = null;
									_003Citem_003E5__3 = null;
								}
							}
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__1 != null)
						{
							((global::System.IDisposable)_003C_003Es__1).Dispose();
						}
					}
					_003C_003Es__1 = null;
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyDamageOverTime_003Ed__35 _003CApplyDamageOverTime_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyDamageOverTime_003Ed__35>(ref awaiter, ref _003CApplyDamageOverTime_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CApplyGuardianAngelAuraHeal_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public global::System.Collections.Generic.IReadOnlyList<BattleSprite> team;

		public BattleMode battleMode;

		public float fatigueMultiplier;

		public SpecialAbilityService _003C_003E4__this;

		private _003C_003Ec__DisplayClass37_0 _003C_003E8__1;

		private List<BattleSprite> _003Cbearers_003E5__2;

		private Enumerator<BattleSprite> _003C_003Es__3;

		private BattleSprite _003Cbearer_003E5__4;

		private Item _003Ctalent_003E5__5;

		private float _003ChealPerTurn_003E5__6;

		private global::System.Collections.Generic.IEnumerator<BattleSprite> _003C_003Es__7;

		private BattleSprite _003Cally_003E5__8;

		private float _003CrawHeal_003E5__9;

		private int _003ChealInt_003E5__10;

		private int _003ChpBefore_003E5__11;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0406: Unknown result type (might be due to invalid IL or missing references)
			//IL_040b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0422;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass37_0();
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				_003C_003E8__1.battleMode = battleMode;
				_003Cbearers_003E5__2 = Enumerable.ToList<BattleSprite>(Enumerable.Where<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)team, (Func<BattleSprite, bool>)((BattleSprite s) => _003C_003E8__1._003C_003E4__this.HasSpecialAbility(s, "guardianAngelAura", _003C_003E8__1.battleMode))));
				if (_003Cbearers_003E5__2.Count != 0)
				{
					_003C_003E8__1.bearerIds = Enumerable.ToHashSet<string>(Enumerable.Select<BattleSprite, string>((global::System.Collections.Generic.IEnumerable<BattleSprite>)_003Cbearers_003E5__2, (Func<BattleSprite, string>)((BattleSprite s) => s.PlayerSpirit.PlayerSpiritID)));
					_003C_003Es__3 = _003Cbearers_003E5__2.GetEnumerator();
					try
					{
						while (_003C_003Es__3.MoveNext())
						{
							_003Cbearer_003E5__4 = _003C_003Es__3.Current;
							if (!_003Cbearer_003E5__4.Equipments.TryGetValue("talent", ref _003Ctalent_003E5__5))
							{
								continue;
							}
							Item item = _003Ctalent_003E5__5;
							if (item == null || !(item.Effect?.HealPerTurn > 0f))
							{
								continue;
							}
							_003ChealPerTurn_003E5__6 = _003Ctalent_003E5__5.Effect.HealPerTurn;
							_003C_003Es__7 = Enumerable.Where<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)team, (Func<BattleSprite, bool>)((BattleSprite s) => s.HP > 0 && !_003C_003E8__1.bearerIds.Contains(s.PlayerSpirit.PlayerSpiritID))).GetEnumerator();
							try
							{
								while (((global::System.Collections.IEnumerator)_003C_003Es__7).MoveNext())
								{
									_003Cally_003E5__8 = _003C_003Es__7.Current;
									_003CrawHeal_003E5__9 = ((_003ChealPerTurn_003E5__6 < 1f) ? ((float)_003Cally_003E5__8.MaxHP * _003ChealPerTurn_003E5__6) : _003ChealPerTurn_003E5__6);
									_003ChealInt_003E5__10 = (int)(_003CrawHeal_003E5__9 * fatigueMultiplier);
									_003ChpBefore_003E5__11 = _003Cally_003E5__8.HP;
									_003Cally_003E5__8.HP = Math.Min(_003Cally_003E5__8.MaxHP, _003Cally_003E5__8.HP + _003ChealInt_003E5__10);
									Debug.WriteLine($"[AbilityFX] [talent] guardianAngelAura {_003Ctalent_003E5__5.Name} ({_003Cbearer_003E5__4.BaseSpirit.Name}) — healed {_003Cally_003E5__8.BaseSpirit.Name} +{_003ChealInt_003E5__10} HP ({_003ChpBefore_003E5__11}→{_003Cally_003E5__8.HP}/{_003Cally_003E5__8.MaxHP})");
									_003Cally_003E5__8 = null;
								}
							}
							finally
							{
								if (num < 0 && _003C_003Es__7 != null)
								{
									((global::System.IDisposable)_003C_003Es__7).Dispose();
								}
							}
							_003C_003Es__7 = null;
							_003Ctalent_003E5__5 = null;
							_003Cbearer_003E5__4 = null;
						}
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__3).Dispose();
						}
					}
					_003C_003Es__3 = default(Enumerator<BattleSprite>);
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyGuardianAngelAuraHeal_003Ed__37 _003CApplyGuardianAngelAuraHeal_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyGuardianAngelAuraHeal_003Ed__37>(ref awaiter, ref _003CApplyGuardianAngelAuraHeal_003Ed__);
						return;
					}
					goto IL_0422;
				}
				goto end_IL_0007;
				IL_0422:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cbearers_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cbearers_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CApplyHealOverTime_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleSprite sprite;

		public BattleMode battleMode;

		public float fatigueMultiplier;

		public SpecialAbilityService _003C_003E4__this;

		private global::System.Collections.Generic.IEnumerator<ValueTuple<string, Item>> _003C_003Es__1;

		private string _003Cslot_003E5__2;

		private Item _003Citem_003E5__3;

		private float _003CrawHeal_003E5__4;

		private HPThresholdEffect _003Cthreshold_003E5__5;

		private int _003ChealInt_003E5__6;

		private int _003ChpBefore_003E5__7;

		private float _003ChpPercent_003E5__8;

		private bool _003CconditionMet_003E5__9;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0391: Unknown result type (might be due to invalid IL or missing references)
			//IL_0396: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003Es__1 = GetActiveSlotItems(sprite, battleMode).GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__1).MoveNext())
						{
							ValueTuple<string, Item> current = _003C_003Es__1.Current;
							_003Cslot_003E5__2 = current.Item1;
							_003Citem_003E5__3 = current.Item2;
							_003CrawHeal_003E5__4 = 0f;
							ItemEffect? effect = _003Citem_003E5__3.Effect;
							if (effect != null && effect.HealPerTurn > 0f && _003Citem_003E5__3.Effect.HpThresholdEffect == null)
							{
								_003CrawHeal_003E5__4 += ((_003Citem_003E5__3.Effect.HealPerTurn < 1f) ? ((float)sprite.MaxHP * _003Citem_003E5__3.Effect.HealPerTurn) : _003Citem_003E5__3.Effect.HealPerTurn);
							}
							_003Cthreshold_003E5__5 = _003Citem_003E5__3.Effect?.HpThresholdEffect;
							HPThresholdEffect hPThresholdEffect = _003Cthreshold_003E5__5;
							if (hPThresholdEffect != null && hPThresholdEffect.HealPerTurn > 0f)
							{
								_003ChpPercent_003E5__8 = (float)sprite.HP / (float)sprite.MaxHP;
								_003CconditionMet_003E5__9 = (_003Cthreshold_003E5__5.ActivatesBelowThreshold ? (_003ChpPercent_003E5__8 <= _003Cthreshold_003E5__5.Threshold) : (_003ChpPercent_003E5__8 >= _003Cthreshold_003E5__5.Threshold));
								if (_003CconditionMet_003E5__9)
								{
									_003CrawHeal_003E5__4 += ((_003Cthreshold_003E5__5.HealPerTurn < 1f) ? ((float)sprite.MaxHP * _003Cthreshold_003E5__5.HealPerTurn) : _003Cthreshold_003E5__5.HealPerTurn);
								}
							}
							_003ChealInt_003E5__6 = (int)(_003CrawHeal_003E5__4 * fatigueMultiplier);
							if (_003ChealInt_003E5__6 > 0)
							{
								_003ChpBefore_003E5__7 = sprite.HP;
								sprite.HP = Math.Min(sprite.MaxHP, sprite.HP + _003ChealInt_003E5__6);
								Debug.WriteLine($"[AbilityFX] [{_003Cslot_003E5__2}] healPerTurn {_003Citem_003E5__3.Name} ({sprite.BaseSpirit.Name}) — +{_003ChealInt_003E5__6} HP ({_003ChpBefore_003E5__7}→{sprite.HP}/{sprite.MaxHP})");
								_003Cthreshold_003E5__5 = null;
								_003Cslot_003E5__2 = null;
								_003Citem_003E5__3 = null;
							}
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__1 != null)
						{
							((global::System.IDisposable)_003C_003Es__1).Dispose();
						}
					}
					_003C_003Es__1 = null;
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyHealOverTime_003Ed__34 _003CApplyHealOverTime_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyHealOverTime_003Ed__34>(ref awaiter, ref _003CApplyHealOverTime_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetActiveSlotItems_003Ed__36 : global::System.Collections.Generic.IEnumerable<ValueTuple<string, Item>>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<ValueTuple<string, Item>>, global::System.Collections.IEnumerator, global::System.IDisposable
	{
		private int _003C_003E1__state;

		private ValueTuple<string, Item> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private BattleSprite sprite;

		public BattleSprite _003C_003E3__sprite;

		private BattleMode battleMode;

		public BattleMode _003C_003E3__battleMode;

		private Item _003Cgear_003E5__1;

		private Item _003Ctalent_003E5__2;

		private Item _003CheldItem_003E5__3;

		ValueTuple<string, Item> global::System.Collections.Generic.IEnumerator<ValueTuple<string, Item>>.Current
		{
			[DebuggerHidden]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _003C_003E2__current;
			}
		}

		object global::System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetActiveSlotItems_003Ed__36(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void global::System.IDisposable.Dispose()
		{
			_003Cgear_003E5__1 = null;
			_003Ctalent_003E5__2 = null;
			_003CheldItem_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			Dictionary<string, Item?> equipments2;
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				Dictionary<string, Item?> equipments = sprite.Equipments;
				if (equipments != null && equipments.TryGetValue("gear", ref _003Cgear_003E5__1) && _003Cgear_003E5__1 != null)
				{
					_003C_003E2__current = new ValueTuple<string, Item>("gear", _003Cgear_003E5__1);
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0091;
			}
			case 1:
				_003C_003E1__state = -1;
				goto IL_0091;
			case 2:
				_003C_003E1__state = -1;
				goto IL_00eb;
			case 3:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_0091:
				equipments2 = sprite.Equipments;
				if (equipments2 != null && equipments2.TryGetValue("talent", ref _003Ctalent_003E5__2) && _003Ctalent_003E5__2 != null)
				{
					_003C_003E2__current = new ValueTuple<string, Item>("talent", _003Ctalent_003E5__2);
					_003C_003E1__state = 2;
					return true;
				}
				goto IL_00eb;
				IL_00eb:
				if (battleMode != BattleMode.PVP)
				{
					Dictionary<string, Item?> equipments3 = sprite.Equipments;
					if (equipments3 != null && equipments3.TryGetValue("heldItem", ref _003CheldItem_003E5__3) && _003CheldItem_003E5__3 != null)
					{
						_003C_003E2__current = new ValueTuple<string, Item>("heldItem", _003CheldItem_003E5__3);
						_003C_003E1__state = 3;
						return true;
					}
				}
				break;
			}
			return false;
		}

		bool global::System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void global::System.Collections.IEnumerator.Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<ValueTuple<string, Item>> global::System.Collections.Generic.IEnumerable<ValueTuple<string, Item>>.GetEnumerator()
		{
			_003CGetActiveSlotItems_003Ed__36 _003CGetActiveSlotItems_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetActiveSlotItems_003Ed__ = this;
			}
			else
			{
				_003CGetActiveSlotItems_003Ed__ = new _003CGetActiveSlotItems_003Ed__36(0);
			}
			_003CGetActiveSlotItems_003Ed__.sprite = _003C_003E3__sprite;
			_003CGetActiveSlotItems_003Ed__.battleMode = _003C_003E3__battleMode;
			return _003CGetActiveSlotItems_003Ed__;
		}

		[DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return (global::System.Collections.IEnumerator)((global::System.Collections.Generic.IEnumerable<ValueTuple<string, Item>>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleBattleStartEffects_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleState battleState;

		public BattleMode battleMode;

		public SpecialAbilityService _003C_003E4__this;

		private global::System.Collections.Generic.IEnumerator<BattleSprite> _003C_003Es__1;

		private BattleSprite _003Csprite_003E5__2;

		private global::System.Collections.Generic.IEnumerator<BattleSprite> _003C_003Es__3;

		private BattleSprite _003Csprite_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_017f;
					}
					_003C_003Es__1 = Enumerable.Concat<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.PlayerBattleSprites, (global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.OpponentBattleSprites).GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__1).MoveNext())
						{
							_003Csprite_003E5__2 = _003C_003Es__1.Current;
							_003C_003E4__this.InitializeTurnBasedEffects(_003Csprite_003E5__2, battleMode);
							_003Csprite_003E5__2 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__1 != null)
						{
							((global::System.IDisposable)_003C_003Es__1).Dispose();
						}
					}
					_003C_003Es__1 = null;
					awaiter2 = _003C_003E4__this.HandleSquadSynergyEffects((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.PlayerBattleSprites).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CHandleBattleStartEffects_003Ed__4 _003CHandleBattleStartEffects_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleBattleStartEffects_003Ed__4>(ref awaiter2, ref _003CHandleBattleStartEffects_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter2)).GetResult();
				awaiter = _003C_003E4__this.HandleSquadSynergyEffects((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.OpponentBattleSprites).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CHandleBattleStartEffects_003Ed__4 _003CHandleBattleStartEffects_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleBattleStartEffects_003Ed__4>(ref awaiter, ref _003CHandleBattleStartEffects_003Ed__);
					return;
				}
				goto IL_017f;
				IL_017f:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this.HandleHarmonyEffect((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.PlayerBattleSprites, battleMode);
				_003C_003E4__this.HandleHarmonyEffect((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.OpponentBattleSprites, battleMode);
				_003C_003E4__this.HandleMonotypeMasterySetup((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.PlayerBattleSprites, battleMode);
				_003C_003E4__this.HandleMonotypeMasterySetup((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.OpponentBattleSprites, battleMode);
				_003C_003E4__this.HandleGuardianAngelAura((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.PlayerBattleSprites, battleMode);
				_003C_003E4__this.HandleGuardianAngelAura((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.OpponentBattleSprites, battleMode);
				_003C_003Es__3 = Enumerable.Concat<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.PlayerBattleSprites, (global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.OpponentBattleSprites).GetEnumerator();
				try
				{
					while (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
					{
						_003Csprite_003E5__4 = _003C_003Es__3.Current;
						ApplyStatConversions(_003Csprite_003E5__4, _003C_003E4__this.GetAllSpecialAbilities(_003Csprite_003E5__4, battleMode));
						_003Csprite_003E5__4 = null;
					}
				}
				finally
				{
					if (num < 0 && _003C_003Es__3 != null)
					{
						((global::System.IDisposable)_003C_003Es__3).Dispose();
					}
				}
				_003C_003Es__3 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleComebackKidEffect_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleState battleState;

		public BattleSprite koSpirit;

		public KnockoutEffectResult result;

		public SpecialAbilityService _003C_003E4__this;

		private _003C_003Ec__DisplayClass39_0 _003C_003E8__1;

		private List<BattleSprite> _003CaliveAllies_003E5__2;

		private Enumerator<BattleSprite> _003C_003Es__3;

		private BattleSprite _003Cally_003E5__4;

		private TurnBasedEffectTracker _003Ceffects_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass39_0();
					_003C_003E8__1.koSpirit = koSpirit;
					_003CaliveAllies_003E5__2 = Enumerable.ToList<BattleSprite>(Enumerable.Where<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.PlayerBattleSprites, (Func<BattleSprite, bool>)((BattleSprite s) => s.HP > 0 && s.PlayerSpirit.PlayerSpiritID != _003C_003E8__1.koSpirit.PlayerSpirit.PlayerSpiritID)));
					_003C_003Es__3 = _003CaliveAllies_003E5__2.GetEnumerator();
					try
					{
						while (_003C_003Es__3.MoveNext())
						{
							_003Cally_003E5__4 = _003C_003Es__3.Current;
							if (_003C_003E4__this.HasSpecialAbility(_003Cally_003E5__4, "comebackKid", BattleMode.PVP))
							{
								_003Ceffects_003E5__5 = _003C_003E4__this.GetTurnBasedEffects(_003Cally_003E5__4.PlayerSpirit.PlayerSpiritID);
								_003Ceffects_003E5__5.ComebackStacks++;
								result.StatBoosts.Add(new StatBoost
								{
									SpiritID = _003Cally_003E5__4.PlayerSpirit.PlayerSpiritID,
									StatName = "ALL",
									Multiplier = 1.15f,
									IsPermanent = false,
									Source = "Comeback Kid"
								});
								result.EffectDescriptions.Add(_003Cally_003E5__4.BaseSpirit.Name + " draws strength from loss!");
								Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(_003Cally_003E5__4, "comebackKid", BattleMode.PVP)}] comebackKid ({_003Cally_003E5__4.BaseSpirit.Name}) — stack {_003Ceffects_003E5__5.ComebackStacks}, ALL stats ×1.15 (temporary)");
								_003Ceffects_003E5__5 = null;
							}
							_003Cally_003E5__4 = null;
						}
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__3).Dispose();
						}
					}
					_003C_003Es__3 = default(Enumerator<BattleSprite>);
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleComebackKidEffect_003Ed__39 _003CHandleComebackKidEffect_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleComebackKidEffect_003Ed__39>(ref awaiter, ref _003CHandleComebackKidEffect_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CaliveAllies_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CaliveAllies_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandlePostCombatEffects_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PostCombatEffectResult> _003C_003Et__builder;

		public BattleSprite attacker;

		public BattleSprite defender;

		public int damageDealt;

		public Move move;

		public BattleMode battleMode;

		public SpecialAbilityService _003C_003E4__this;

		private PostCombatEffectResult _003Cresult_003E5__1;

		private TurnBasedEffectTracker _003CdefFx_003E5__2;

		private int _003ChealAmount_003E5__3;

		private int _003CreflectDamage_003E5__4;

		private double _003Croll_003E5__5;

		private bool _003Cpoisoned_003E5__6;

		private ActiveStatusEffect _003Cpoison_003E5__7;

		private TurnBasedEffectTracker _003CdefenderFx_003E5__8;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			PostCombatEffectResult result;
			try
			{
				_003Cresult_003E5__1 = new PostCombatEffectResult();
				if (_003C_003E4__this.HasSpecialAbility(attacker, "lifeDrain", battleMode))
				{
					_003ChealAmount_003E5__3 = (int)((float)damageDealt * 0.2f);
					_003Cresult_003E5__1.AttackerHealAmount = _003ChealAmount_003E5__3;
					_003Cresult_003E5__1.EffectDescriptions.Add($"{attacker.BaseSpirit.Name} absorbed {_003ChealAmount_003E5__3} HP!");
				}
				if (_003C_003E4__this.HasSpecialAbility(defender, "thornReflect", battleMode))
				{
					_003CreflectDamage_003E5__4 = (int)((float)damageDealt * 0.5f);
					_003Cresult_003E5__1.DefenderReflectDamage = _003CreflectDamage_003E5__4;
					_003Cresult_003E5__1.EffectDescriptions.Add($"{defender.BaseSpirit.Name}'s thorns dealt {_003CreflectDamage_003E5__4} damage!");
				}
				if (_003C_003E4__this.HasSpecialAbility(attacker, "poisonChance", battleMode))
				{
					_003Croll_003E5__5 = _003C_003E4__this._rng.NextDouble();
					_003Cpoisoned_003E5__6 = _003Croll_003E5__5 < 0.3;
					Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "poisonChance", battleMode)}] poisonChance ({attacker.BaseSpirit.Name}) — roll {_003Croll_003E5__5:F2} {(_003Cpoisoned_003E5__6 ? "< 0.30 → POISONED" : ">= 0.30 → no effect")}");
					if (_003Cpoisoned_003E5__6)
					{
						_003Cpoison_003E5__7 = new ActiveStatusEffect(StatusEffectType.Poison, 3, 0.25f);
						_003C_003E4__this.GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID).ActiveStatusEffects.Add(_003Cpoison_003E5__7);
						_003Cresult_003E5__1.StatusEffectsApplied.Add(_003Cpoison_003E5__7);
						_003Cresult_003E5__1.EffectDescriptions.Add(defender.BaseSpirit.Name + " was poisoned!");
						_003Cpoison_003E5__7 = null;
					}
				}
				if (_003C_003E4__this.HasSpecialAbility(defender, "adaptation", battleMode))
				{
					_003C_003E4__this.GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID).LastReceivedAttackType = move.Type;
				}
				if (damageDealt > 0)
				{
					if (_003C_003E4__this.HasSpecialAbility(attacker, "corrosiveStrike", battleMode))
					{
						_003CdefenderFx_003E5__8 = _003C_003E4__this.GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID);
						if (_003CdefenderFx_003E5__8.CorrosiveDebuffStacks < 10)
						{
							_003CdefenderFx_003E5__8.CorrosiveDebuffStacks++;
							Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "corrosiveStrike", battleMode)}] corrosiveStrike ({attacker.BaseSpirit.Name}) — {defender.BaseSpirit.Name} corrosive stacks now {_003CdefenderFx_003E5__8.CorrosiveDebuffStacks} (-{_003CdefenderFx_003E5__8.CorrosiveDebuffStacks * 5}% DEF/MDF)");
						}
						_003CdefenderFx_003E5__8 = null;
					}
					_003C_003E4__this.GetTurnBasedEffects(attacker.PlayerSpirit.PlayerSpiritID).StubbornWillDealtDamageThisTurn = true;
					_003C_003E4__this.GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID).StubbornWillTookDamageThisTurn = true;
					if (_003C_003E4__this.HasSpecialAbility(defender, "vengeance", battleMode))
					{
						_003C_003E4__this.GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID).VengeanceTriggered = true;
						Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(defender, "vengeance", battleMode)}] vengeance ({defender.BaseSpirit.Name}) — took damage from {attacker.BaseSpirit.Name}, vengeance armed for retaliation");
					}
				}
				_003CdefFx_003E5__2 = _003C_003E4__this.GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID);
				_003CdefFx_003E5__2.LastMoveUsedAgainstMe = move.Name;
				result = _003Cresult_003E5__1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				_003CdefFx_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			_003CdefFx_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleSpeedSwapEffects_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleState battleState;

		public BattleMode battleMode;

		public SpecialAbilityService _003C_003E4__this;

		private BattleSprite _003CplayerSprite_003E5__1;

		private BattleSprite _003CopponentSprite_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e1;
				}
				_003CplayerSprite_003E5__1 = battleState.ActivePlayerSprite;
				_003CopponentSprite_003E5__2 = battleState.ActiveOpponentSprite;
				if (_003CplayerSprite_003E5__1 != null && _003CopponentSprite_003E5__2 != null)
				{
					_003C_003E4__this.TrySpeedSwapOnEntry(_003CplayerSprite_003E5__1, _003CopponentSprite_003E5__2, battleMode);
					_003C_003E4__this.TrySpeedSwapOnEntry(_003CopponentSprite_003E5__2, _003CplayerSprite_003E5__1, battleMode);
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleSpeedSwapEffects_003Ed__9 _003CHandleSpeedSwapEffects_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleSpeedSwapEffects_003Ed__9>(ref awaiter, ref _003CHandleSpeedSwapEffects_003Ed__);
						return;
					}
					goto IL_00e1;
				}
				goto end_IL_0007;
				IL_00e1:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CplayerSprite_003E5__1 = null;
				_003CopponentSprite_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CplayerSprite_003E5__1 = null;
			_003CopponentSprite_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleSpiritEntersBattleEffects_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleState battleState;

		public BattleMode battleMode;

		public SpecialAbilityService _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.HandleSpeedSwapEffects(battleState, battleMode).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleSpiritEntersBattleEffects_003Ed__6 _003CHandleSpiritEntersBattleEffects_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleSpiritEntersBattleEffects_003Ed__6>(ref awaiter, ref _003CHandleSpiritEntersBattleEffects_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this.HandleSpeedMatchEffects(battleState, battleMode);
				_003C_003E4__this.HandleBrainFogOnEntry(battleState, battleMode);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleSpiritKnockout_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<KnockoutEffectResult> _003C_003Et__builder;

		public BattleState battleState;

		public BattleSprite koSpirit;

		public BattleSprite attacker;

		public BattleMode battleMode;

		public SpecialAbilityService _003C_003E4__this;

		private KnockoutEffectResult _003Cresult_003E5__1;

		private TurnBasedEffectTracker _003Ceffects_003E5__2;

		private TurnBasedEffectTracker _003CattackerEffects_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0442: Unknown result type (might be due to invalid IL or missing references)
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_044f: Unknown result type (might be due to invalid IL or missing references)
			//IL_040b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0410: Unknown result type (might be due to invalid IL or missing references)
			//IL_0425: Unknown result type (might be due to invalid IL or missing references)
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			KnockoutEffectResult result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003Cresult_003E5__1 = new KnockoutEffectResult();
					if (_003C_003E4__this.HasSpecialAbility(koSpirit, "revive", battleMode))
					{
						_003Ceffects_003E5__2 = _003C_003E4__this.GetTurnBasedEffects(koSpirit.PlayerSpirit.PlayerSpiritID);
						if (!_003Ceffects_003E5__2.HasUsedRevive)
						{
							_003Cresult_003E5__1.SpiritRevived = true;
							_003Cresult_003E5__1.ReviveHP = (int)((float)koSpirit.MaxHP * 0.5f);
							koSpirit.HP = _003Cresult_003E5__1.ReviveHP;
							_003Ceffects_003E5__2.HasUsedRevive = true;
							_003Cresult_003E5__1.EffectDescriptions.Add(koSpirit.BaseSpirit.Name + " was revived by Phoenix Feather!");
							Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(koSpirit, "revive", battleMode)}] revive ({koSpirit.BaseSpirit.Name}) — restored to {_003Cresult_003E5__1.ReviveHP} HP (50% of {koSpirit.MaxHP})");
						}
						else
						{
							Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(koSpirit, "revive", battleMode)}] revive ({koSpirit.BaseSpirit.Name}) — already used, no effect");
						}
						_003Ceffects_003E5__2 = null;
					}
					if (!_003Cresult_003E5__1.SpiritRevived && _003C_003E4__this.HasSpecialAbility(attacker, "snowball", battleMode))
					{
						attacker.HP = attacker.MaxHP;
						_003CattackerEffects_003E5__3 = _003C_003E4__this.GetTurnBasedEffects(attacker.PlayerSpirit.PlayerSpiritID);
						_003CattackerEffects_003E5__3.SnowballStacks++;
						_003Cresult_003E5__1.StatBoosts.Add(new StatBoost
						{
							SpiritID = attacker.PlayerSpirit.PlayerSpiritID,
							StatName = "ATK",
							Multiplier = 1.1f,
							IsPermanent = true,
							Source = "Snowball"
						});
						_003Cresult_003E5__1.EffectDescriptions.Add(attacker.BaseSpirit.Name + " gained power from victory!");
						Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "snowball", battleMode)}] snowball ({attacker.BaseSpirit.Name}) — stack {_003CattackerEffects_003E5__3.SnowballStacks}, full heal to {attacker.MaxHP} HP, ATK ×1.1 (permanent)");
						_003CattackerEffects_003E5__3 = null;
					}
					awaiter = _003C_003E4__this.HandleComebackKidEffect(battleState, koSpirit, _003Cresult_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleSpiritKnockout_003Ed__38 _003CHandleSpiritKnockout_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleSpiritKnockout_003Ed__38>(ref awaiter, ref _003CHandleSpiritKnockout_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				result = _003Cresult_003E5__1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleSquadSynergyEffects_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public global::System.Collections.Generic.IReadOnlyList<BattleSprite> team;

		public SpecialAbilityService _003C_003E4__this;

		private HashSet<string> _003CconsumedStackingGroups_003E5__1;

		private global::System.Collections.Generic.IEnumerator<BattleSprite> _003C_003Es__2;

		private BattleSprite _003Csource_003E5__3;

		private _003C_003Ec__DisplayClass13_0 _003C_003E8__4;

		private Item _003Ctalent_003E5__5;

		private string _003CstackingGroup_003E5__6;

		private int _003CmatchCount_003E5__7;

		private float _003Cbonus_003E5__8;

		private global::System.Collections.Generic.IEnumerable<BattleSprite> _003Ctargets_003E5__9;

		private global::System.Collections.Generic.IEnumerator<BattleSprite> _003C_003Es__10;

		private BattleSprite _003Ctarget_003E5__11;

		private int _003Cbefore_003E5__12;

		private int _003Cafter_003E5__13;

		private TurnBasedEffectTracker _003Cfx_003E5__14;

		private float _003Cexisting_003E5__15;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0621: Unknown result type (might be due to invalid IL or missing references)
			//IL_0626: Unknown result type (might be due to invalid IL or missing references)
			//IL_062e: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0604: Unknown result type (might be due to invalid IL or missing references)
			//IL_0606: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003CconsumedStackingGroups_003E5__1 = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.OrdinalIgnoreCase);
					_003C_003Es__2 = ((global::System.Collections.Generic.IEnumerable<BattleSprite>)team).GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__2).MoveNext())
						{
							_003Csource_003E5__3 = _003C_003Es__2.Current;
							_003C_003E8__4 = new _003C_003Ec__DisplayClass13_0();
							if (!_003Csource_003E5__3.Equipments.TryGetValue("talent", ref _003Ctalent_003E5__5) || _003Ctalent_003E5__5?.Effect?.SquadSynergy == null)
							{
								continue;
							}
							_003CstackingGroup_003E5__6 = _003Ctalent_003E5__5.Effect.StackingGroup;
							if (!string.IsNullOrEmpty(_003CstackingGroup_003E5__6) && _003CconsumedStackingGroups_003E5__1.Contains(_003CstackingGroup_003E5__6))
							{
								Debug.WriteLine($"[AbilityFX] [talent] squadSynergy ({_003Csource_003E5__3.BaseSpirit.Name}) — skipped, StackingGroup '{_003CstackingGroup_003E5__6}' already applied by earlier squadmate");
								continue;
							}
							_003C_003E8__4.synergy = _003Ctalent_003E5__5.Effect.SquadSynergy;
							if (string.IsNullOrEmpty(_003C_003E8__4.synergy.RequiredType) || string.IsNullOrEmpty(_003C_003E8__4.synergy.BoostedStat))
							{
								continue;
							}
							_003CmatchCount_003E5__7 = Enumerable.Count<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)team, (Func<BattleSprite, bool>)((BattleSprite s) => ((object)s.BaseSpirit.Type1).ToString().Equals(_003C_003E8__4.synergy.RequiredType, (StringComparison)5) || ((object)s.BaseSpirit.Type2).ToString().Equals(_003C_003E8__4.synergy.RequiredType, (StringComparison)5)));
							if (_003CmatchCount_003E5__7 < _003C_003E8__4.synergy.MinimumCount)
							{
								continue;
							}
							if (!string.IsNullOrEmpty(_003CstackingGroup_003E5__6))
							{
								_003CconsumedStackingGroups_003E5__1.Add(_003CstackingGroup_003E5__6);
							}
							_003Cbonus_003E5__8 = 1f + _003C_003E8__4.synergy.BonusPerSpirit * (float)_003CmatchCount_003E5__7;
							global::System.Collections.Generic.IReadOnlyList<BattleSprite> readOnlyList2;
							if (!_003C_003E8__4.synergy.AppliesToAllSpirits)
							{
								List<BattleSprite> obj = new List<BattleSprite>();
								obj.Add(_003Csource_003E5__3);
								global::System.Collections.Generic.IReadOnlyList<BattleSprite> readOnlyList = (global::System.Collections.Generic.IReadOnlyList<BattleSprite>)obj;
								readOnlyList2 = readOnlyList;
							}
							else
							{
								readOnlyList2 = team;
							}
							_003Ctargets_003E5__9 = (global::System.Collections.Generic.IEnumerable<BattleSprite>)readOnlyList2;
							Debug.WriteLine($"[AbilityFX] [talent] squadSynergy ({_003Csource_003E5__3.BaseSpirit.Name}) — {_003C_003E8__4.synergy.RequiredType} count:{_003CmatchCount_003E5__7} → {DisplayStatName(_003C_003E8__4.synergy.BoostedStat)}×{_003Cbonus_003E5__8:F2} applied to {(_003C_003E8__4.synergy.AppliesToAllSpirits ? "all" : "self")}");
							_003C_003Es__10 = Enumerable.Where<BattleSprite>(_003Ctargets_003E5__9, (Func<BattleSprite, bool>)((BattleSprite t) => t.HP > 0)).GetEnumerator();
							try
							{
								while (((global::System.Collections.IEnumerator)_003C_003Es__10).MoveNext())
								{
									_003Ctarget_003E5__11 = _003C_003Es__10.Current;
									_003Cbefore_003E5__12 = GetStatValue(_003Ctarget_003E5__11, _003C_003E8__4.synergy.BoostedStat);
									_003C_003E4__this.ApplySynergyStatBoost(_003Ctarget_003E5__11, _003C_003E8__4.synergy.BoostedStat, _003Cbonus_003E5__8);
									_003Cafter_003E5__13 = GetStatValue(_003Ctarget_003E5__11, _003C_003E8__4.synergy.BoostedStat);
									Debug.WriteLine($"[AbilityFX] [talent]   {_003Ctarget_003E5__11.BaseSpirit.Name} {DisplayStatName(_003C_003E8__4.synergy.BoostedStat)}: {_003Cbefore_003E5__12}→{_003Cafter_003E5__13}");
									_003Cfx_003E5__14 = _003C_003E4__this.GetTurnBasedEffects(_003Ctarget_003E5__11.PlayerSpirit.PlayerSpiritID);
									if (_003Cfx_003E5__14.SquadSynergyBonuses.TryGetValue(_003C_003E8__4.synergy.BoostedStat, ref _003Cexisting_003E5__15))
									{
										_003Cfx_003E5__14.SquadSynergyBonuses[_003C_003E8__4.synergy.BoostedStat] = _003Cexisting_003E5__15 * _003Cbonus_003E5__8;
									}
									else
									{
										_003Cfx_003E5__14.SquadSynergyBonuses[_003C_003E8__4.synergy.BoostedStat] = _003Cbonus_003E5__8;
									}
									_003Cfx_003E5__14 = null;
									_003Ctarget_003E5__11 = null;
								}
							}
							finally
							{
								if (num < 0 && _003C_003Es__10 != null)
								{
									((global::System.IDisposable)_003C_003Es__10).Dispose();
								}
							}
							_003C_003Es__10 = null;
							_003C_003E8__4 = null;
							_003Ctalent_003E5__5 = null;
							_003CstackingGroup_003E5__6 = null;
							_003Ctargets_003E5__9 = null;
							_003Csource_003E5__3 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__2 != null)
						{
							((global::System.IDisposable)_003C_003Es__2).Dispose();
						}
					}
					_003C_003Es__2 = null;
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleSquadSynergyEffects_003Ed__13 _003CHandleSquadSynergyEffects_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleSquadSynergyEffects_003Ed__13>(ref awaiter, ref _003CHandleSquadSynergyEffects_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CconsumedStackingGroups_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CconsumedStackingGroups_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleTurnEndEffects_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleState battleState;

		public BattleMode battleMode;

		public SpecialAbilityService _003C_003E4__this;

		private float _003ChealFatigue_003E5__1;

		private float _003CdamageFatigue_003E5__2;

		private global::System.Collections.Generic.IEnumerator<BattleSprite> _003C_003Es__3;

		private BattleSprite _003Csprite_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02da: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003ChealFatigue_003E5__1 = battleState.FatigueHealMultiplier;
					_003CdamageFatigue_003E5__2 = battleState.FatigueDamageMultiplier;
					_003C_003Es__3 = Enumerable.Concat<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.PlayerBattleSprites, (global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.OpponentBattleSprites).GetEnumerator();
					goto case 0;
				case 0:
				case 1:
					try
					{
						TaskAwaiter awaiter3;
						if (num != 0)
						{
							if (num != 1)
							{
								goto IL_0207;
							}
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01a5;
						}
						TaskAwaiter awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_012b;
						IL_01a5:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003C_003E4__this.ApplyStatusEffectDamage(_003Csprite_003E5__4, _003CdamageFatigue_003E5__2);
						if (_003C_003E4__this.HasSpecialAbility(_003Csprite_003E5__4, "stubbornWill", battleMode))
						{
							_003C_003E4__this.UpdateStubbornWill(_003Csprite_003E5__4, battleMode);
						}
						_003Csprite_003E5__4 = null;
						goto IL_0207;
						IL_0207:
						while (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
						{
							_003Csprite_003E5__4 = _003C_003Es__3.Current;
							if (_003Csprite_003E5__4.HP <= 0)
							{
								continue;
							}
							awaiter4 = _003C_003E4__this.ApplyHealOverTime(_003Csprite_003E5__4, battleMode, _003ChealFatigue_003E5__1).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003CHandleTurnEndEffects_003Ed__31 _003CHandleTurnEndEffects_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleTurnEndEffects_003Ed__31>(ref awaiter4, ref _003CHandleTurnEndEffects_003Ed__);
								return;
							}
							goto IL_012b;
						}
						goto end_IL_0076;
						IL_012b:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						awaiter3 = _003C_003E4__this.ApplyDamageOverTime(_003Csprite_003E5__4, battleMode, _003CdamageFatigue_003E5__2).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter3;
							_003CHandleTurnEndEffects_003Ed__31 _003CHandleTurnEndEffects_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleTurnEndEffects_003Ed__31>(ref awaiter3, ref _003CHandleTurnEndEffects_003Ed__);
							return;
						}
						goto IL_01a5;
						end_IL_0076:;
					}
					finally
					{
						if (num < 0 && _003C_003Es__3 != null)
						{
							((global::System.IDisposable)_003C_003Es__3).Dispose();
						}
					}
					_003C_003Es__3 = null;
					awaiter2 = _003C_003E4__this.ApplyGuardianAngelAuraHeal((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.PlayerBattleSprites, battleMode, _003ChealFatigue_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter2;
						_003CHandleTurnEndEffects_003Ed__31 _003CHandleTurnEndEffects_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleTurnEndEffects_003Ed__31>(ref awaiter2, ref _003CHandleTurnEndEffects_003Ed__);
						return;
					}
					goto IL_02b0;
				case 2:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02b0;
				case 3:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_02b0:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					awaiter = _003C_003E4__this.ApplyGuardianAngelAuraHeal((global::System.Collections.Generic.IReadOnlyList<BattleSprite>)battleState.OpponentBattleSprites, battleMode, _003ChealFatigue_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter;
						_003CHandleTurnEndEffects_003Ed__31 _003CHandleTurnEndEffects_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleTurnEndEffects_003Ed__31>(ref awaiter, ref _003CHandleTurnEndEffects_003Ed__);
						return;
					}
					break;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleTurnStartEffects_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleState battleState;

		public BattleMode battleMode;

		public SpecialAbilityService _003C_003E4__this;

		private BattleSprite _003CactivePlayer_003E5__1;

		private BattleSprite _003CactiveOpponent_003E5__2;

		private global::System.Collections.Generic.IEnumerator<BattleSprite> _003C_003Es__3;

		private BattleSprite _003Csprite_003E5__4;

		private TurnBasedEffectTracker _003Ceffects_003E5__5;

		private bool _003CisActive_003E5__6;

		private SpiritType _003CresistedType_003E5__7;

		private float _003Ccurrent_003E5__8;

		private float _003CnewResistance_003E5__9;

		private Enumerator<ActiveStatusEffect> _003C_003Es__10;

		private ActiveStatusEffect _003Cstatus_003E5__11;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_076e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0773: Unknown result type (might be due to invalid IL or missing references)
			//IL_0788: Unknown result type (might be due to invalid IL or missing references)
			//IL_078a: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003CactivePlayer_003E5__1 = battleState.ActivePlayerSprite;
					_003CactiveOpponent_003E5__2 = battleState.ActiveOpponentSprite;
					_003C_003Es__3 = Enumerable.Concat<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.PlayerBattleSprites, (global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.OpponentBattleSprites).GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
						{
							_003Csprite_003E5__4 = _003C_003Es__3.Current;
							_003Csprite_003E5__4.IsStunned = false;
							if (_003Csprite_003E5__4.HP <= 0)
							{
								continue;
							}
							_003Ceffects_003E5__5 = _003C_003E4__this.GetTurnBasedEffects(_003Csprite_003E5__4.PlayerSpirit.PlayerSpiritID);
							_003CisActive_003E5__6 = _003Csprite_003E5__4 == _003CactivePlayer_003E5__1 || _003Csprite_003E5__4 == _003CactiveOpponent_003E5__2;
							if (_003CisActive_003E5__6 && _003C_003E4__this.HasSpecialAbility(_003Csprite_003E5__4, "momentum", battleMode))
							{
								_003Ceffects_003E5__5.MomentumStacks = Math.Min(_003Ceffects_003E5__5.MomentumStacks + 1, 10);
								Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(_003Csprite_003E5__4, "momentum", battleMode)}] momentum ({_003Csprite_003E5__4.BaseSpirit.Name}) — stack now {_003Ceffects_003E5__5.MomentumStacks} (+{Math.Min((float)_003Ceffects_003E5__5.MomentumStacks * 0.05f, 0.5f):P0} dmg)");
							}
							if (_003CisActive_003E5__6 && _003C_003E4__this.HasSpecialAbility(_003Csprite_003E5__4, "patience", battleMode))
							{
								_003Ceffects_003E5__5.PatienceTurns = Math.Min(_003Ceffects_003E5__5.PatienceTurns + 1, 10);
								Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(_003Csprite_003E5__4, "patience", battleMode)}] patience ({_003Csprite_003E5__4.BaseSpirit.Name}) — turn {_003Ceffects_003E5__5.PatienceTurns} (+{Math.Min((float)_003Ceffects_003E5__5.PatienceTurns * 0.1f, 1f):P0} dmg)");
							}
							if (_003C_003E4__this.HasSpecialAbility(_003Csprite_003E5__4, "adaptation", battleMode) && _003Ceffects_003E5__5.LastReceivedAttackType.HasValue)
							{
								_003CresistedType_003E5__7 = _003Ceffects_003E5__5.LastReceivedAttackType.Value;
								_003Ceffects_003E5__5.AdaptationResistances.TryGetValue(_003CresistedType_003E5__7, ref _003Ccurrent_003E5__8);
								_003CnewResistance_003E5__9 = Math.Min(_003Ccurrent_003E5__8 + 0.05f, 0.5f);
								_003Ceffects_003E5__5.AdaptationResistances[_003CresistedType_003E5__7] = _003CnewResistance_003E5__9;
								Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(_003Csprite_003E5__4, "adaptation", battleMode)}] adaptation ({_003Csprite_003E5__4.BaseSpirit.Name}) — {_003CresistedType_003E5__7} resistance {_003Ccurrent_003E5__8:P0}→{_003CnewResistance_003E5__9:P0}");
							}
							_003Ceffects_003E5__5.VengeanceTriggered = false;
							_003Ceffects_003E5__5.StubbornWillDealtDamageThisTurn = false;
							_003Ceffects_003E5__5.StubbornWillTookDamageThisTurn = false;
							if (_003Ceffects_003E5__5.BrainFogTurnsRemaining > 0)
							{
								_003Ceffects_003E5__5.BrainFogTurnsRemaining--;
								if (_003Ceffects_003E5__5.BrainFogTurnsRemaining == 0 && _003Ceffects_003E5__5.OriginalIntBeforeBrainFog > 0)
								{
									Debug.WriteLine($"[AbilityFX] brainFog expired ({_003Csprite_003E5__4.BaseSpirit.Name}) — INT restored {_003Csprite_003E5__4.INT}→{_003Ceffects_003E5__5.OriginalIntBeforeBrainFog}");
									_003Csprite_003E5__4.INT = _003Ceffects_003E5__5.OriginalIntBeforeBrainFog;
									_003Ceffects_003E5__5.OriginalIntBeforeBrainFog = 0;
								}
							}
							_003C_003Es__10 = _003Ceffects_003E5__5.ActiveStatusEffects.GetEnumerator();
							try
							{
								while (_003C_003Es__10.MoveNext())
								{
									_003Cstatus_003E5__11 = _003C_003Es__10.Current;
									if ((_003Cstatus_003E5__11.Type == StatusEffectType.Stun || _003Cstatus_003E5__11.Type == StatusEffectType.Sleep) && _003Cstatus_003E5__11.TurnsRemaining > 0)
									{
										_003Csprite_003E5__4.IsStunned = true;
										Debug.WriteLine($"[AbilityFX] {_003Cstatus_003E5__11.Type} ({_003Csprite_003E5__4.BaseSpirit.Name}) — {_003Cstatus_003E5__11.TurnsRemaining} turn(s) remaining → stunned this turn");
									}
									_003Cstatus_003E5__11.TurnsRemaining--;
									_003Cstatus_003E5__11 = null;
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__10).Dispose();
								}
							}
							_003C_003Es__10 = default(Enumerator<ActiveStatusEffect>);
							_003Ceffects_003E5__5.ActiveStatusEffects.RemoveAll((Predicate<ActiveStatusEffect>)((ActiveStatusEffect s) => s.TurnsRemaining < 0));
							_003Ceffects_003E5__5 = null;
							_003Csprite_003E5__4 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__3 != null)
						{
							((global::System.IDisposable)_003C_003Es__3).Dispose();
						}
					}
					_003C_003Es__3 = null;
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleTurnStartEffects_003Ed__30 _003CHandleTurnStartEffects_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleTurnStartEffects_003Ed__30>(ref awaiter, ref _003CHandleTurnStartEffects_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CactivePlayer_003E5__1 = null;
				_003CactiveOpponent_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CactivePlayer_003E5__1 = null;
			_003CactiveOpponent_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly ITypeEffectivenessService _typeEffectivenessService;

	private readonly Dictionary<string, TurnBasedEffectTracker> _turnBasedEffects = new Dictionary<string, TurnBasedEffectTracker>();

	private readonly Random _rng = new Random();

	public SpecialAbilityService(ITypeEffectivenessService typeEffectivenessService)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		_typeEffectivenessService = typeEffectivenessService;
	}

	[AsyncStateMachine(typeof(_003CHandleBattleStartEffects_003Ed__4))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task HandleBattleStartEffects(BattleState battleState, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleBattleStartEffects_003Ed__4 _003CHandleBattleStartEffects_003Ed__ = new _003CHandleBattleStartEffects_003Ed__4();
		_003CHandleBattleStartEffects_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleBattleStartEffects_003Ed__._003C_003E4__this = this;
		_003CHandleBattleStartEffects_003Ed__.battleState = battleState;
		_003CHandleBattleStartEffects_003Ed__.battleMode = battleMode;
		_003CHandleBattleStartEffects_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleBattleStartEffects_003Ed__._003C_003Et__builder)).Start<_003CHandleBattleStartEffects_003Ed__4>(ref _003CHandleBattleStartEffects_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleBattleStartEffects_003Ed__._003C_003Et__builder)).Task;
	}

	private static void ApplyStatConversions(BattleSprite sprite, HashSet<string> abilities)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, int> stats = new Dictionary<string, int>((IEqualityComparer<string>)(object)StringComparer.Ordinal)
		{
			["ATK"] = sprite.ATK,
			["DEF"] = sprite.DEF,
			["SATK"] = sprite.SATK,
			["SDEF"] = sprite.SDEF,
			["SPD"] = sprite.SPD,
			["INT"] = sprite.INT
		};
		Dictionary<string, int> val = StatConversions.Compute((IReadOnlyDictionary<string, int>)(object)stats, (IReadOnlySet<string>)(object)abilities);
		if (val.Count == 0)
		{
			return;
		}
		Enumerator<string, int> enumerator = val.GetEnumerator();
		try
		{
			string text = default(string);
			int num = default(int);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(ref text, ref num);
				string text2 = text;
				int num2 = num;
				if (num2 == 0)
				{
					continue;
				}
				string text3 = text2;
				string text4 = text3;
				if (!(text4 == "ATK"))
				{
					if (!(text4 == "DEF"))
					{
						if (!(text4 == "SATK"))
						{
							if (!(text4 == "SDEF"))
							{
								if (!(text4 == "SPD"))
								{
									if (text4 == "INT")
									{
										sprite.INT += num2;
									}
								}
								else
								{
									sprite.SPD += num2;
								}
							}
							else
							{
								sprite.SDEF += num2;
							}
						}
						else
						{
							sprite.SATK += num2;
						}
					}
					else
					{
						sprite.DEF += num2;
					}
				}
				else
				{
					sprite.ATK += num2;
				}
				Debug.WriteLine($"[AbilityFX] statConversion ({sprite.BaseSpirit.Name}) — +{num2} {DisplayStatName(text2)} → now {GetStatValue(sprite, text2)}");
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
	}

	[AsyncStateMachine(typeof(_003CHandleSpiritEntersBattleEffects_003Ed__6))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task HandleSpiritEntersBattleEffects(BattleState battleState, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleSpiritEntersBattleEffects_003Ed__6 _003CHandleSpiritEntersBattleEffects_003Ed__ = new _003CHandleSpiritEntersBattleEffects_003Ed__6();
		_003CHandleSpiritEntersBattleEffects_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleSpiritEntersBattleEffects_003Ed__._003C_003E4__this = this;
		_003CHandleSpiritEntersBattleEffects_003Ed__.battleState = battleState;
		_003CHandleSpiritEntersBattleEffects_003Ed__.battleMode = battleMode;
		_003CHandleSpiritEntersBattleEffects_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleSpiritEntersBattleEffects_003Ed__._003C_003Et__builder)).Start<_003CHandleSpiritEntersBattleEffects_003Ed__6>(ref _003CHandleSpiritEntersBattleEffects_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleSpiritEntersBattleEffects_003Ed__._003C_003Et__builder)).Task;
	}

	private void HandleBrainFogOnEntry(BattleState battleState, BattleMode battleMode)
	{
		BattleSprite activePlayerSprite = battleState.ActivePlayerSprite;
		BattleSprite activeOpponentSprite = battleState.ActiveOpponentSprite;
		if (activePlayerSprite != null && activeOpponentSprite != null)
		{
			TryApplyBrainFogOnEntry(activePlayerSprite, activeOpponentSprite, battleMode);
			TryApplyBrainFogOnEntry(activeOpponentSprite, activePlayerSprite, battleMode);
		}
	}

	private void TryApplyBrainFogOnEntry(BattleSprite entering, BattleSprite opponent, BattleMode battleMode)
	{
		if (!entering.HasTriggeredEntry && HasSpecialAbility(entering, "brainFog", battleMode))
		{
			TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(opponent.PlayerSpirit.PlayerSpiritID);
			if (turnBasedEffects.BrainFogTurnsRemaining <= 0)
			{
				turnBasedEffects.OriginalIntBeforeBrainFog = opponent.INT;
				turnBasedEffects.BrainFogTurnsRemaining = 3;
				opponent.INT = (int)((float)opponent.INT * 0.5f);
				Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(entering, "brainFog", battleMode)}] brainFog ({entering.BaseSpirit.Name}) — {opponent.BaseSpirit.Name} INT {turnBasedEffects.OriginalIntBeforeBrainFog}→{opponent.INT} for 3 turns");
			}
		}
	}

	[AsyncStateMachine(typeof(_003CHandleSpeedSwapEffects_003Ed__9))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleSpeedSwapEffects(BattleState battleState, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleSpeedSwapEffects_003Ed__9 _003CHandleSpeedSwapEffects_003Ed__ = new _003CHandleSpeedSwapEffects_003Ed__9();
		_003CHandleSpeedSwapEffects_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleSpeedSwapEffects_003Ed__._003C_003E4__this = this;
		_003CHandleSpeedSwapEffects_003Ed__.battleState = battleState;
		_003CHandleSpeedSwapEffects_003Ed__.battleMode = battleMode;
		_003CHandleSpeedSwapEffects_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleSpeedSwapEffects_003Ed__._003C_003Et__builder)).Start<_003CHandleSpeedSwapEffects_003Ed__9>(ref _003CHandleSpeedSwapEffects_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleSpeedSwapEffects_003Ed__._003C_003Et__builder)).Task;
	}

	private void TrySpeedSwapOnEntry(BattleSprite entering, BattleSprite opponent, BattleMode battleMode)
	{
		if (!entering.HasTriggeredEntry)
		{
			if (HasSpecialAbility(entering, "speedSwap", battleMode))
			{
				string specialAbilitySlot = GetSpecialAbilitySlot(entering, "speedSwap", battleMode);
				Debug.WriteLine($"[AbilityFX] [{specialAbilitySlot}] speedSwap triggered — {entering.BaseSpirit.Name} SPD:{entering.SPD} ↔ {opponent.BaseSpirit.Name} SPD:{opponent.SPD}");
				int sPD = opponent.SPD;
				int sPD2 = entering.SPD;
				entering.SPD = sPD;
				opponent.SPD = sPD2;
				Debug.WriteLine($"[AbilityFX] [{specialAbilitySlot}]   Result → {entering.BaseSpirit.Name} SPD:{entering.SPD} | {opponent.BaseSpirit.Name} SPD:{opponent.SPD}");
			}
			entering.HasTriggeredEntry = true;
		}
	}

	private void HandleSpeedMatchEffects(BattleState battleState, BattleMode battleMode)
	{
		BattleSprite activePlayerSprite = battleState.ActivePlayerSprite;
		BattleSprite activeOpponentSprite = battleState.ActiveOpponentSprite;
		if (activePlayerSprite != null && activeOpponentSprite != null)
		{
			TryApplySpeedMatch(activePlayerSprite, activeOpponentSprite, battleMode);
			TryApplySpeedMatch(activeOpponentSprite, activePlayerSprite, battleMode);
		}
	}

	private void TryApplySpeedMatch(BattleSprite holder, BattleSprite opponent, BattleMode battleMode)
	{
		if (HasSpecialAbility(holder, "speedMatch", battleMode) && opponent.SPD != holder.SPD)
		{
			int sPD = opponent.SPD;
			opponent.SPD = holder.SPD;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(holder, "speedMatch", battleMode)}] speedMatch ({holder.BaseSpirit.Name}) — {opponent.BaseSpirit.Name} SPD {sPD}→{opponent.SPD} (matched holder {holder.SPD})");
		}
		if (HasSpecialAbility(holder, "atomicMatch", battleMode) && holder.SPD != opponent.SPD)
		{
			int sPD2 = holder.SPD;
			holder.SPD = opponent.SPD;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(holder, "atomicMatch", battleMode)}] atomicMatch ({holder.BaseSpirit.Name}) — self SPD {sPD2}→{holder.SPD} (matched opponent {opponent.BaseSpirit.Name} {opponent.SPD})");
		}
	}

	[AsyncStateMachine(typeof(_003CHandleSquadSynergyEffects_003Ed__13))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleSquadSynergyEffects(global::System.Collections.Generic.IReadOnlyList<BattleSprite> team)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleSquadSynergyEffects_003Ed__13 _003CHandleSquadSynergyEffects_003Ed__ = new _003CHandleSquadSynergyEffects_003Ed__13();
		_003CHandleSquadSynergyEffects_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleSquadSynergyEffects_003Ed__._003C_003E4__this = this;
		_003CHandleSquadSynergyEffects_003Ed__.team = team;
		_003CHandleSquadSynergyEffects_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleSquadSynergyEffects_003Ed__._003C_003Et__builder)).Start<_003CHandleSquadSynergyEffects_003Ed__13>(ref _003CHandleSquadSynergyEffects_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleSquadSynergyEffects_003Ed__._003C_003Et__builder)).Task;
	}

	private void ApplySynergyStatBoost(BattleSprite sprite, string boostedStat, float multiplier)
	{
		switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(boostedStat))
		{
		case 1419519929u:
			if (boostedStat == "ATK")
			{
				sprite.ATK = (int)((float)sprite.ATK * multiplier);
			}
			break;
		case 1242496940u:
			if (boostedStat == "DEF")
			{
				sprite.DEF = (int)((float)sprite.DEF * multiplier);
			}
			break;
		case 139277044u:
			if (boostedStat == "SATK")
			{
				sprite.SATK = (int)((float)sprite.SATK * multiplier);
			}
			break;
		case 1164482377u:
			if (boostedStat == "SDEF")
			{
				sprite.SDEF = (int)((float)sprite.SDEF * multiplier);
			}
			break;
		case 1528554166u:
			if (boostedStat == "SPD")
			{
				sprite.SPD = (int)((float)sprite.SPD * multiplier);
			}
			break;
		case 3636696446u:
			if (boostedStat == "INT")
			{
				sprite.INT = (int)((float)sprite.INT * multiplier);
			}
			break;
		case 1894470373u:
			if (boostedStat == "HP")
			{
				float num = (float)sprite.HP / (float)sprite.MaxHP;
				sprite.MaxHP = (int)((float)sprite.MaxHP * multiplier);
				sprite.HP = (int)((float)sprite.MaxHP * num);
			}
			break;
		}
	}

	private void HandleHarmonyEffect(global::System.Collections.Generic.IReadOnlyList<BattleSprite> team, BattleMode battleMode)
	{
		BattleSprite battleSprite = Enumerable.FirstOrDefault<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)team, (Func<BattleSprite, bool>)((BattleSprite s) => HasSpecialAbility(s, "harmony", battleMode)));
		if (battleSprite == null)
		{
			return;
		}
		int num = Enumerable.Count<SpiritType>(Enumerable.Distinct<SpiritType>(Enumerable.Where<SpiritType>(Enumerable.SelectMany<BattleSprite, SpiritType>((global::System.Collections.Generic.IEnumerable<BattleSprite>)team, (Func<BattleSprite, global::System.Collections.Generic.IEnumerable<SpiritType>>)((BattleSprite s) => new SpiritType[2]
		{
			s.BaseSpirit.Type1,
			s.BaseSpirit.Type2
		})), (Func<SpiritType, bool>)((SpiritType t) => t != SpiritType.None))));
		if (num == 0)
		{
			return;
		}
		float num2 = 1f + 0.08f * (float)num;
		string specialAbilitySlot = GetSpecialAbilitySlot(battleSprite, "harmony", battleMode);
		Debug.WriteLine($"[AbilityFX] [{specialAbilitySlot}] harmony — {num} unique type(s) → all stats ×{num2:F2}");
		global::System.Collections.Generic.IEnumerator<BattleSprite> enumerator = Enumerable.Where<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)team, (Func<BattleSprite, bool>)((BattleSprite s) => s.HP > 0)).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				BattleSprite current = enumerator.Current;
				int aTK = current.ATK;
				current.ATK = (int)((float)current.ATK * num2);
				current.DEF = (int)((float)current.DEF * num2);
				current.SATK = (int)((float)current.SATK * num2);
				current.SDEF = (int)((float)current.SDEF * num2);
				current.SPD = (int)((float)current.SPD * num2);
				current.INT = (int)((float)current.INT * num2);
				Debug.WriteLine($"[AbilityFX] [{specialAbilitySlot}]   {current.BaseSpirit.Name} ATK {aTK}→{current.ATK}");
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}

	private void HandleGuardianAngelAura(global::System.Collections.Generic.IReadOnlyList<BattleSprite> team, BattleMode battleMode)
	{
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		HashSet<string> val = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.OrdinalIgnoreCase);
		global::System.Collections.Generic.IEnumerator<BattleSprite> enumerator = ((global::System.Collections.Generic.IEnumerable<BattleSprite>)team).GetEnumerator();
		try
		{
			Item item = default(Item);
			string text = default(string);
			double num = default(double);
			float num3 = default(float);
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				BattleSprite source = enumerator.Current;
				if (!HasSpecialAbility(source, "guardianAngelAura", battleMode) || !source.Equipments.TryGetValue("talent", ref item) || item?.Effect?.StatMultipliers == null)
				{
					continue;
				}
				string stackingGroup = item.Effect.StackingGroup;
				if (!string.IsNullOrEmpty(stackingGroup) && !val.Add(stackingGroup))
				{
					Debug.WriteLine($"[AbilityFX] [talent] guardianAngelAura ({source.BaseSpirit.Name}) — skipped, StackingGroup '{stackingGroup}' already applied by earlier squadmate");
					continue;
				}
				List<BattleSprite> val2 = Enumerable.ToList<BattleSprite>(Enumerable.Where<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)team, (Func<BattleSprite, bool>)((BattleSprite s) => s.HP > 0 && s.PlayerSpirit.PlayerSpiritID != source.PlayerSpirit.PlayerSpiritID)));
				Enumerator<string, double> enumerator2 = item.Effect.StatMultipliers.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						enumerator2.Current.Deconstruct(ref text, ref num);
						string text2 = text;
						double num2 = num;
						Enumerator<BattleSprite> enumerator3 = val2.GetEnumerator();
						try
						{
							while (enumerator3.MoveNext())
							{
								BattleSprite current = enumerator3.Current;
								int statValue = GetStatValue(current, text2);
								ApplySynergyStatBoost(current, text2, (float)num2);
								int statValue2 = GetStatValue(current, text2);
								TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(current.PlayerSpirit.PlayerSpiritID);
								if (turnBasedEffects.SquadSynergyBonuses.TryGetValue(text2, ref num3))
								{
									turnBasedEffects.SquadSynergyBonuses[text2] = num3 * (float)num2;
								}
								else
								{
									turnBasedEffects.SquadSynergyBonuses[text2] = (float)num2;
								}
								Debug.WriteLine($"[AbilityFX] [talent] guardianAngelAura ({source.BaseSpirit.Name}) — {current.BaseSpirit.Name} {DisplayStatName(text2)}: {statValue}→{statValue2} (×{num2:F2})");
							}
						}
						finally
						{
							((global::System.IDisposable)enumerator3).Dispose();
						}
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator2).Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}

	private void HandleMonotypeMasterySetup(global::System.Collections.Generic.IReadOnlyList<BattleSprite> team, BattleMode battleMode)
	{
		BattleSprite battleSprite = Enumerable.FirstOrDefault<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)team, (Func<BattleSprite, bool>)((BattleSprite s) => HasSpecialAbility(s, "monotypeMastery", battleMode)));
		if (battleSprite == null)
		{
			return;
		}
		List<SpiritType> val = Enumerable.ToList<SpiritType>(Enumerable.Distinct<SpiritType>(Enumerable.Select<BattleSprite, SpiritType>((global::System.Collections.Generic.IEnumerable<BattleSprite>)team, (Func<BattleSprite, SpiritType>)((BattleSprite s) => s.BaseSpirit.Type1))));
		if (val.Count != 1)
		{
			return;
		}
		SpiritType spiritType = val[0];
		Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(battleSprite, "monotypeMastery", battleMode)}] monotypeMastery — all spirits are {spiritType} → +40% damage on {spiritType} moves");
		global::System.Collections.Generic.IEnumerator<BattleSprite> enumerator = ((global::System.Collections.Generic.IEnumerable<BattleSprite>)team).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				BattleSprite current = enumerator.Current;
				TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(current.PlayerSpirit.PlayerSpiritID);
				turnBasedEffects.MonotypeMasteryActive = true;
				turnBasedEffects.MonotypeSharedType = spiritType;
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}

	public float ApplyDamageModifiers(BattleSprite attacker, BattleSprite defender, float baseDamage, Move move, BattleMode battleMode)
	{
		float damage = baseDamage;
		damage = ApplyExecutionerEffect(attacker, defender, damage, battleMode);
		damage = ApplyTypeMasterEffect(attacker, defender, damage, move, battleMode);
		damage = ApplyTurnBasedDamageModifiers(attacker, damage, battleMode);
		damage = ApplyMonotypeMasteryEffect(attacker, damage, move, battleMode);
		damage = ApplyVengeanceEffect(attacker, damage, battleMode);
		return ApplyOpeningStrikeEffect(attacker, damage, battleMode);
	}

	public float ApplyDamageReduction(BattleSprite defender, float incomingDamage, SpiritType attackType, Move move, BattleMode battleMode)
	{
		float num = incomingDamage;
		if (HasSpecialAbility(defender, "damageCap", battleMode))
		{
			float num2 = (float)defender.MaxHP * 0.3f;
			if (num > num2)
			{
				Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(defender, "damageCap", battleMode)}] damageCap ({defender.BaseSpirit.Name}) — incoming {num:F1} capped to {num2:F1} (30% of {defender.MaxHP} HP)");
				num = num2;
			}
		}
		if (HasSpecialAbility(defender, "damageCap45", battleMode))
		{
			float num3 = (float)defender.MaxHP * 0.75f;
			if (num > num3)
			{
				Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(defender, "damageCap45", battleMode)}] damageCap45 ({defender.BaseSpirit.Name}) — incoming {num:F1} capped to {num3:F1} (45% of {defender.MaxHP} HP)");
				num = num3;
			}
		}
		TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID);
		if (HasSpecialAbility(defender, "righteousStance", battleMode) && move.Name != null && move.Name == turnBasedEffects.LastMoveUsedAgainstMe)
		{
			float num4 = num;
			num *= 0.5f;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(defender, "righteousStance", battleMode)}] righteousStance ({defender.BaseSpirit.Name}) — opponent repeated {move.Name} → dmg {num4:F1}→{num:F1} (×0.5)");
		}
		float num5 = default(float);
		if (turnBasedEffects.AdaptationResistances.TryGetValue(attackType, ref num5) && num5 > 0f)
		{
			float num6 = num;
			num *= 1f - num5;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(defender, "adaptation", battleMode)}] adaptation ({defender.BaseSpirit.Name}) — {attackType} resistance {num5:P0} → dmg {num6:F1}→{num:F1}");
		}
		return num;
	}

	private float ApplyExecutionerEffect(BattleSprite attacker, BattleSprite defender, float damage, BattleMode battleMode)
	{
		if (!HasSpecialAbility(attacker, "executioner", battleMode))
		{
			return damage;
		}
		float num = (float)defender.HP / (float)defender.MaxHP;
		if (num < 0.3f)
		{
			float num2 = damage * 1.5f;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "executioner", battleMode)}] executioner ({attacker.BaseSpirit.Name}) — defender at {num:P0} HP → dmg {damage:F1}→{num2:F1} (×1.5)");
			return num2;
		}
		return damage;
	}

	private float ApplyTypeMasterEffect(BattleSprite attacker, BattleSprite defender, float damage, Move move, BattleMode battleMode)
	{
		if (!HasSpecialAbility(attacker, "typeMaster", battleMode))
		{
			return damage;
		}
		SpiritType type = attacker.BaseSpirit.Type1;
		SpiritType type2 = attacker.BaseSpirit.Type2;
		SpiritType type3 = move.Type;
		if (type3 == type || type3 == type2)
		{
			float num = damage * 1.5f;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "typeMaster", battleMode)}] typeMaster ({attacker.BaseSpirit.Name}) — move {type3} matches type → dmg {damage:F1}→{num:F1} (×1.5)");
			return num;
		}
		if (IsOppositeType(type3, type) || IsOppositeType(type3, type2))
		{
			float num2 = damage * 0.75f;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "typeMaster", battleMode)}] typeMaster ({attacker.BaseSpirit.Name}) — move {type3} is opposite type → dmg {damage:F1}→{num2:F1} (×0.75)");
			return num2;
		}
		return damage;
	}

	private float ApplyTurnBasedDamageModifiers(BattleSprite attacker, float damage, BattleMode battleMode)
	{
		TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(attacker.PlayerSpirit.PlayerSpiritID);
		if (turnBasedEffects.PatienceTurns > 0)
		{
			float num = Math.Min((float)turnBasedEffects.PatienceTurns * 0.25f, 1f);
			float num2 = damage;
			damage *= 1f + num;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "patience", battleMode)}] patience ({attacker.BaseSpirit.Name}) — turn {turnBasedEffects.PatienceTurns} → dmg {num2:F1}→{damage:F1} (+{num:P0})");
		}
		if (turnBasedEffects.MomentumStacks > 0)
		{
			float num3 = Math.Min((float)turnBasedEffects.MomentumStacks * 0.05f, 0.5f);
			float num4 = damage;
			damage *= 1f + num3;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "momentum", battleMode)}] momentum ({attacker.BaseSpirit.Name}) — stack {turnBasedEffects.MomentumStacks} → dmg {num4:F1}→{damage:F1} (+{num3:P0})");
		}
		return damage;
	}

	private float ApplyMonotypeMasteryEffect(BattleSprite attacker, float damage, Move move, BattleMode battleMode)
	{
		TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(attacker.PlayerSpirit.PlayerSpiritID);
		if (!turnBasedEffects.MonotypeMasteryActive || turnBasedEffects.MonotypeSharedType != move.Type)
		{
			return damage;
		}
		float num = damage * 1.4f;
		string text = GetSpecialAbilitySlot(attacker, "monotypeMastery", battleMode);
		if (string.IsNullOrEmpty(text))
		{
			text = "talent";
		}
		Debug.WriteLine($"[AbilityFX] [{text}] monotypeMastery ({attacker.BaseSpirit.Name}) — {move.Type} matches shared type → dmg {damage:F1}→{num:F1} (×1.4)");
		return num;
	}

	private float ApplyVengeanceEffect(BattleSprite attacker, float damage, BattleMode battleMode)
	{
		if (!HasSpecialAbility(attacker, "vengeance", battleMode))
		{
			return damage;
		}
		TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(attacker.PlayerSpirit.PlayerSpiritID);
		if (!turnBasedEffects.VengeanceTriggered)
		{
			return damage;
		}
		float num = damage * 1.3f;
		Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "vengeance", battleMode)}] vengeance ({attacker.BaseSpirit.Name}) — retaliating after taking hit → dmg {damage:F1}→{num:F1} (×1.3)");
		return num;
	}

	private float ApplyOpeningStrikeEffect(BattleSprite attacker, float damage, BattleMode battleMode)
	{
		if (!HasSpecialAbility(attacker, "openingStrike", battleMode))
		{
			return damage;
		}
		TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(attacker.PlayerSpirit.PlayerSpiritID);
		if (turnBasedEffects.HasUsedFirstMove)
		{
			return damage;
		}
		turnBasedEffects.HasUsedFirstMove = true;
		float num = damage * 1.5f;
		Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "openingStrike", battleMode)}] openingStrike ({attacker.BaseSpirit.Name}) — first move → dmg {damage:F1}→{num:F1} (×1.5)");
		return num;
	}

	[AsyncStateMachine(typeof(_003CHandlePostCombatEffects_003Ed__26))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<PostCombatEffectResult> HandlePostCombatEffects(BattleSprite attacker, BattleSprite defender, int damageDealt, Move move, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		PostCombatEffectResult result = new PostCombatEffectResult();
		if (HasSpecialAbility(attacker, "lifeDrain", battleMode))
		{
			int healAmount = (result.AttackerHealAmount = (int)((float)damageDealt * 0.2f));
			result.EffectDescriptions.Add($"{attacker.BaseSpirit.Name} absorbed {healAmount} HP!");
		}
		if (HasSpecialAbility(defender, "thornReflect", battleMode))
		{
			int reflectDamage = (result.DefenderReflectDamage = (int)((float)damageDealt * 0.5f));
			result.EffectDescriptions.Add($"{defender.BaseSpirit.Name}'s thorns dealt {reflectDamage} damage!");
		}
		if (HasSpecialAbility(attacker, "poisonChance", battleMode))
		{
			double roll = _rng.NextDouble();
			bool poisoned = roll < 0.3;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "poisonChance", battleMode)}] poisonChance ({attacker.BaseSpirit.Name}) — roll {roll:F2} {(poisoned ? "< 0.30 → POISONED" : ">= 0.30 → no effect")}");
			if (poisoned)
			{
				ActiveStatusEffect poison = new ActiveStatusEffect(StatusEffectType.Poison, 3, 0.25f);
				GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID).ActiveStatusEffects.Add(poison);
				result.StatusEffectsApplied.Add(poison);
				result.EffectDescriptions.Add(defender.BaseSpirit.Name + " was poisoned!");
			}
		}
		if (HasSpecialAbility(defender, "adaptation", battleMode))
		{
			GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID).LastReceivedAttackType = move.Type;
		}
		if (damageDealt > 0)
		{
			if (HasSpecialAbility(attacker, "corrosiveStrike", battleMode))
			{
				TurnBasedEffectTracker defenderFx = GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID);
				if (defenderFx.CorrosiveDebuffStacks < 10)
				{
					defenderFx.CorrosiveDebuffStacks++;
					Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "corrosiveStrike", battleMode)}] corrosiveStrike ({attacker.BaseSpirit.Name}) — {defender.BaseSpirit.Name} corrosive stacks now {defenderFx.CorrosiveDebuffStacks} (-{defenderFx.CorrosiveDebuffStacks * 5}% DEF/MDF)");
				}
			}
			GetTurnBasedEffects(attacker.PlayerSpirit.PlayerSpiritID).StubbornWillDealtDamageThisTurn = true;
			GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID).StubbornWillTookDamageThisTurn = true;
			if (HasSpecialAbility(defender, "vengeance", battleMode))
			{
				GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID).VengeanceTriggered = true;
				Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(defender, "vengeance", battleMode)}] vengeance ({defender.BaseSpirit.Name}) — took damage from {attacker.BaseSpirit.Name}, vengeance armed for retaliation");
			}
		}
		TurnBasedEffectTracker defFx = GetTurnBasedEffects(defender.PlayerSpirit.PlayerSpiritID);
		defFx.LastMoveUsedAgainstMe = move.Name;
		return result;
	}

	public bool HasOpeningStrikePriority(BattleSprite sprite, BattleMode battleMode)
	{
		if (!HasSpecialAbility(sprite, "openingStrike", battleMode))
		{
			return false;
		}
		return !GetTurnBasedEffects(sprite.PlayerSpirit.PlayerSpiritID).HasUsedFirstMove;
	}

	public int GetTurnPriority(BattleSprite sprite, BattleMode battleMode)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		global::System.Collections.Generic.IEnumerator<ValueTuple<string, Item>> enumerator = GetActiveSlotItems(sprite, battleMode).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				ValueTuple<string, Item> current = enumerator.Current;
				string item = current.Item1;
				Item item2 = current.Item2;
				int num2 = item2.Effect?.PriorityBonus ?? 0;
				if (num2 != 0)
				{
					num += num2;
					Debug.WriteLine($"[AbilityFX] [{item}] priorityBonus {item2.Name} ({sprite.BaseSpirit.Name}) — {((num2 > 0) ? "+" : "")}{num2} priority bracket → acts before lower-priority foes");
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		if (HasOpeningStrikePriority(sprite, battleMode))
		{
			num++;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(sprite, "openingStrike", battleMode)}] openingStrike ({sprite.BaseSpirit.Name}) — first move +1 priority bracket → acts before lower-priority foes");
		}
		return num;
	}

	public int? GetForcedMoveSlotIndex(BattleSprite sprite, BattleMode battleMode)
	{
		TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(sprite.PlayerSpirit.PlayerSpiritID);
		if (HasSpecialAbility(sprite, "stubbornWill", battleMode) && turnBasedEffects.StubbornWillForceSlot4)
		{
			turnBasedEffects.StubbornWillForceSlot4 = false;
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(sprite, "stubbornWill", battleMode)}] stubbornWill ({sprite.BaseSpirit.Name}) — forced move slot 4 consumed");
			return 3;
		}
		if (Enumerable.Any<Item>((global::System.Collections.Generic.IEnumerable<Item>)GetActiveItems(sprite, battleMode), (Func<Item, bool>)((Item item) => item != null && (item.Effect?.LocksMove).GetValueOrDefault())))
		{
			return 0;
		}
		return null;
	}

	[AsyncStateMachine(typeof(_003CHandleTurnStartEffects_003Ed__30))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task HandleTurnStartEffects(BattleState battleState, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleTurnStartEffects_003Ed__30 _003CHandleTurnStartEffects_003Ed__ = new _003CHandleTurnStartEffects_003Ed__30();
		_003CHandleTurnStartEffects_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleTurnStartEffects_003Ed__._003C_003E4__this = this;
		_003CHandleTurnStartEffects_003Ed__.battleState = battleState;
		_003CHandleTurnStartEffects_003Ed__.battleMode = battleMode;
		_003CHandleTurnStartEffects_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleTurnStartEffects_003Ed__._003C_003Et__builder)).Start<_003CHandleTurnStartEffects_003Ed__30>(ref _003CHandleTurnStartEffects_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleTurnStartEffects_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleTurnEndEffects_003Ed__31))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task HandleTurnEndEffects(BattleState battleState, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleTurnEndEffects_003Ed__31 _003CHandleTurnEndEffects_003Ed__ = new _003CHandleTurnEndEffects_003Ed__31();
		_003CHandleTurnEndEffects_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleTurnEndEffects_003Ed__._003C_003E4__this = this;
		_003CHandleTurnEndEffects_003Ed__.battleState = battleState;
		_003CHandleTurnEndEffects_003Ed__.battleMode = battleMode;
		_003CHandleTurnEndEffects_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleTurnEndEffects_003Ed__._003C_003Et__builder)).Start<_003CHandleTurnEndEffects_003Ed__31>(ref _003CHandleTurnEndEffects_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleTurnEndEffects_003Ed__._003C_003Et__builder)).Task;
	}

	private void UpdateStubbornWill(BattleSprite sprite, BattleMode battleMode)
	{
		TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(sprite.PlayerSpirit.PlayerSpiritID);
		string specialAbilitySlot = GetSpecialAbilitySlot(sprite, "stubbornWill", battleMode);
		if (turnBasedEffects.StubbornWillTookDamageThisTurn && !turnBasedEffects.StubbornWillDealtDamageThisTurn)
		{
			turnBasedEffects.StubbornWillDamageTurns++;
			Debug.WriteLine($"[AbilityFX] [{specialAbilitySlot}] stubbornWill ({sprite.BaseSpirit.Name}) — took damage without dealing, counter now {turnBasedEffects.StubbornWillDamageTurns}");
			if (turnBasedEffects.StubbornWillDamageTurns >= 2)
			{
				turnBasedEffects.StubbornWillForceSlot4 = true;
				turnBasedEffects.StubbornWillDamageTurns = 0;
				Debug.WriteLine($"[AbilityFX] [{specialAbilitySlot}] stubbornWill ({sprite.BaseSpirit.Name}) — TRIGGERED, slot-4 forced next turn");
			}
		}
		else
		{
			if (turnBasedEffects.StubbornWillDamageTurns > 0)
			{
				Debug.WriteLine($"[AbilityFX] [{specialAbilitySlot}] stubbornWill ({sprite.BaseSpirit.Name}) — dealt damage, counter reset");
			}
			turnBasedEffects.StubbornWillDamageTurns = 0;
			turnBasedEffects.StubbornWillForceSlot4 = false;
		}
	}

	private void ApplyStatusEffectDamage(BattleSprite sprite, float fatigueMultiplier)
	{
		TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(sprite.PlayerSpirit.PlayerSpiritID);
		global::System.Collections.Generic.IEnumerator<ActiveStatusEffect> enumerator = Enumerable.Where<ActiveStatusEffect>((global::System.Collections.Generic.IEnumerable<ActiveStatusEffect>)turnBasedEffects.ActiveStatusEffects, (Func<ActiveStatusEffect, bool>)((ActiveStatusEffect s) => s.TurnsRemaining >= 0)).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				ActiveStatusEffect current = enumerator.Current;
				switch (current.Type)
				{
				case StatusEffectType.Poison:
				{
					int num2 = (int)((float)sprite.MaxHP * current.Magnitude * fatigueMultiplier);
					int hP2 = sprite.HP;
					sprite.HP = Math.Max(0, sprite.HP - num2);
					Debug.WriteLine($"[AbilityFX] poison ({sprite.BaseSpirit.Name}) — -{num2} HP ({hP2}→{sprite.HP}/{sprite.MaxHP}) [{current.TurnsRemaining} turns left]");
					break;
				}
				case StatusEffectType.Burn:
				{
					int num = (int)((float)sprite.MaxHP * current.Magnitude * fatigueMultiplier);
					int hP = sprite.HP;
					int aTK = sprite.ATK;
					sprite.HP = Math.Max(0, sprite.HP - num);
					sprite.ATK = (int)((float)sprite.ATK * 0.9f);
					Debug.WriteLine($"[AbilityFX] burn ({sprite.BaseSpirit.Name}) — -{num} HP ({hP}→{sprite.HP}/{sprite.MaxHP}), ATK {aTK}→{sprite.ATK} [{current.TurnsRemaining} turns left]");
					break;
				}
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}

	[AsyncStateMachine(typeof(_003CApplyHealOverTime_003Ed__34))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ApplyHealOverTime(BattleSprite sprite, BattleMode battleMode, float fatigueMultiplier)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyHealOverTime_003Ed__34 _003CApplyHealOverTime_003Ed__ = new _003CApplyHealOverTime_003Ed__34();
		_003CApplyHealOverTime_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CApplyHealOverTime_003Ed__._003C_003E4__this = this;
		_003CApplyHealOverTime_003Ed__.sprite = sprite;
		_003CApplyHealOverTime_003Ed__.battleMode = battleMode;
		_003CApplyHealOverTime_003Ed__.fatigueMultiplier = fatigueMultiplier;
		_003CApplyHealOverTime_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CApplyHealOverTime_003Ed__._003C_003Et__builder)).Start<_003CApplyHealOverTime_003Ed__34>(ref _003CApplyHealOverTime_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CApplyHealOverTime_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CApplyDamageOverTime_003Ed__35))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ApplyDamageOverTime(BattleSprite sprite, BattleMode battleMode, float fatigueMultiplier)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyDamageOverTime_003Ed__35 _003CApplyDamageOverTime_003Ed__ = new _003CApplyDamageOverTime_003Ed__35();
		_003CApplyDamageOverTime_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CApplyDamageOverTime_003Ed__._003C_003E4__this = this;
		_003CApplyDamageOverTime_003Ed__.sprite = sprite;
		_003CApplyDamageOverTime_003Ed__.battleMode = battleMode;
		_003CApplyDamageOverTime_003Ed__.fatigueMultiplier = fatigueMultiplier;
		_003CApplyDamageOverTime_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CApplyDamageOverTime_003Ed__._003C_003Et__builder)).Start<_003CApplyDamageOverTime_003Ed__35>(ref _003CApplyDamageOverTime_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CApplyDamageOverTime_003Ed__._003C_003Et__builder)).Task;
	}

	[IteratorStateMachine(typeof(_003CGetActiveSlotItems_003Ed__36))]
	private static global::System.Collections.Generic.IEnumerable<ValueTuple<string, Item>> GetActiveSlotItems(BattleSprite sprite, BattleMode battleMode)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetActiveSlotItems_003Ed__36(-2)
		{
			_003C_003E3__sprite = sprite,
			_003C_003E3__battleMode = battleMode
		};
	}

	[AsyncStateMachine(typeof(_003CApplyGuardianAngelAuraHeal_003Ed__37))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ApplyGuardianAngelAuraHeal(global::System.Collections.Generic.IReadOnlyList<BattleSprite> team, BattleMode battleMode, float fatigueMultiplier)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyGuardianAngelAuraHeal_003Ed__37 _003CApplyGuardianAngelAuraHeal_003Ed__ = new _003CApplyGuardianAngelAuraHeal_003Ed__37();
		_003CApplyGuardianAngelAuraHeal_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CApplyGuardianAngelAuraHeal_003Ed__._003C_003E4__this = this;
		_003CApplyGuardianAngelAuraHeal_003Ed__.team = team;
		_003CApplyGuardianAngelAuraHeal_003Ed__.battleMode = battleMode;
		_003CApplyGuardianAngelAuraHeal_003Ed__.fatigueMultiplier = fatigueMultiplier;
		_003CApplyGuardianAngelAuraHeal_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CApplyGuardianAngelAuraHeal_003Ed__._003C_003Et__builder)).Start<_003CApplyGuardianAngelAuraHeal_003Ed__37>(ref _003CApplyGuardianAngelAuraHeal_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CApplyGuardianAngelAuraHeal_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleSpiritKnockout_003Ed__38))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<KnockoutEffectResult> HandleSpiritKnockout(BattleState battleState, BattleSprite koSpirit, BattleSprite attacker, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		KnockoutEffectResult result = new KnockoutEffectResult();
		if (HasSpecialAbility(koSpirit, "revive", battleMode))
		{
			TurnBasedEffectTracker effects = GetTurnBasedEffects(koSpirit.PlayerSpirit.PlayerSpiritID);
			if (!effects.HasUsedRevive)
			{
				result.SpiritRevived = true;
				result.ReviveHP = (int)((float)koSpirit.MaxHP * 0.5f);
				koSpirit.HP = result.ReviveHP;
				effects.HasUsedRevive = true;
				result.EffectDescriptions.Add(koSpirit.BaseSpirit.Name + " was revived by Phoenix Feather!");
				Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(koSpirit, "revive", battleMode)}] revive ({koSpirit.BaseSpirit.Name}) — restored to {result.ReviveHP} HP (50% of {koSpirit.MaxHP})");
			}
			else
			{
				Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(koSpirit, "revive", battleMode)}] revive ({koSpirit.BaseSpirit.Name}) — already used, no effect");
			}
		}
		if (!result.SpiritRevived && HasSpecialAbility(attacker, "snowball", battleMode))
		{
			attacker.HP = attacker.MaxHP;
			TurnBasedEffectTracker attackerEffects = GetTurnBasedEffects(attacker.PlayerSpirit.PlayerSpiritID);
			attackerEffects.SnowballStacks++;
			result.StatBoosts.Add(new StatBoost
			{
				SpiritID = attacker.PlayerSpirit.PlayerSpiritID,
				StatName = "ATK",
				Multiplier = 1.1f,
				IsPermanent = true,
				Source = "Snowball"
			});
			result.EffectDescriptions.Add(attacker.BaseSpirit.Name + " gained power from victory!");
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "snowball", battleMode)}] snowball ({attacker.BaseSpirit.Name}) — stack {attackerEffects.SnowballStacks}, full heal to {attacker.MaxHP} HP, ATK ×1.1 (permanent)");
		}
		await HandleComebackKidEffect(battleState, koSpirit, result);
		return result;
	}

	[AsyncStateMachine(typeof(_003CHandleComebackKidEffect_003Ed__39))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleComebackKidEffect(BattleState battleState, BattleSprite koSpirit, KnockoutEffectResult result)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleComebackKidEffect_003Ed__39 _003CHandleComebackKidEffect_003Ed__ = new _003CHandleComebackKidEffect_003Ed__39();
		_003CHandleComebackKidEffect_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleComebackKidEffect_003Ed__._003C_003E4__this = this;
		_003CHandleComebackKidEffect_003Ed__.battleState = battleState;
		_003CHandleComebackKidEffect_003Ed__.koSpirit = koSpirit;
		_003CHandleComebackKidEffect_003Ed__.result = result;
		_003CHandleComebackKidEffect_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleComebackKidEffect_003Ed__._003C_003Et__builder)).Start<_003CHandleComebackKidEffect_003Ed__39>(ref _003CHandleComebackKidEffect_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleComebackKidEffect_003Ed__._003C_003Et__builder)).Task;
	}

	public float GetStoredSquadSynergyBonus(string spiritId, string statName)
	{
		TurnBasedEffectTracker turnBasedEffects = GetTurnBasedEffects(spiritId);
		float num = default(float);
		return turnBasedEffects.SquadSynergyBonuses.TryGetValue(statName, ref num) ? num : 1f;
	}

	public float CalculateSquadSynergyBonus(BattleState battleState, BattleSprite spirit, string statName)
	{
		Item item = default(Item);
		if (!spirit.Equipments.TryGetValue("talent", ref item) || item?.Effect?.SquadSynergy == null)
		{
			return 1f;
		}
		SquadSynergyEffect synergy = item.Effect.SquadSynergy;
		if (string.IsNullOrEmpty(synergy.RequiredType) || string.IsNullOrEmpty(synergy.BoostedStat))
		{
			return 1f;
		}
		if (!synergy.BoostedStat.Equals(statName, (StringComparison)5))
		{
			return 1f;
		}
		int num = Enumerable.Count<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)battleState.PlayerBattleSprites, (Func<BattleSprite, bool>)((BattleSprite s) => ((object)s.BaseSpirit.Type1).ToString().Equals(synergy.RequiredType, (StringComparison)5) || ((object)s.BaseSpirit.Type2).ToString().Equals(synergy.RequiredType, (StringComparison)5)));
		if (num < synergy.MinimumCount)
		{
			return 1f;
		}
		return 1f + synergy.BonusPerSpirit * (float)num;
	}

	public void InitializeTurnBasedEffects(BattleSprite sprite, BattleMode battleMode)
	{
		_turnBasedEffects[sprite.PlayerSpirit.PlayerSpiritID] = new TurnBasedEffectTracker();
	}

	public void ResetTemporaryEffects(BattleSprite sprite)
	{
		_turnBasedEffects.Remove(sprite.PlayerSpirit.PlayerSpiritID);
	}

	public float GetTemporaryStatMultiplier(string spiritId, string statName)
	{
		TurnBasedEffectTracker turnBasedEffectTracker = default(TurnBasedEffectTracker);
		if (!_turnBasedEffects.TryGetValue(spiritId, ref turnBasedEffectTracker))
		{
			return 1f;
		}
		float num = 1f;
		if (statName == "INT" && turnBasedEffectTracker.BrainFogTurnsRemaining > 0)
		{
			num *= 0.5f;
		}
		if ((statName == "DEF" || statName == "SDEF") && turnBasedEffectTracker.CorrosiveDebuffStacks > 0)
		{
			num *= Math.Max(0.5f, 1f - (float)turnBasedEffectTracker.CorrosiveDebuffStacks * 0.05f);
		}
		return num;
	}

	public float GetDefenseModifier(BattleSprite attacker, BattleSprite defender, Move move, BattleMode battleMode)
	{
		if (HasSpecialAbility(attacker, "defenseIgnore", battleMode) && (float)defender.HP < (float)defender.MaxHP * 0.4f)
		{
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "defenseIgnore", battleMode)}] defenseIgnore ({attacker.BaseSpirit.Name}) — {defender.BaseSpirit.Name} at {(float)defender.HP / (float)defender.MaxHP:P0} HP → defense bypassed");
			return 0.001f;
		}
		if (HasSpecialAbility(attacker, "feralInstinct", battleMode) && move.MoveType == MoveType.Physical && attacker.INT < defender.INT)
		{
			Debug.WriteLine($"[AbilityFX] [{GetSpecialAbilitySlot(attacker, "feralInstinct", battleMode)}] feralInstinct ({attacker.BaseSpirit.Name}) — INT {attacker.INT} < {defender.INT} → 25% DEF bypass (×0.75)");
			return 0.75f;
		}
		return 1f;
	}

	private static int GetStatValue(BattleSprite sprite, string statName)
	{
		if (1 == 0)
		{
		}
		int result;
		switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(statName))
		{
		case 1894470373u:
			if (!(statName == "HP"))
			{
				goto default;
			}
			result = sprite.HP;
			break;
		case 1419519929u:
			if (!(statName == "ATK"))
			{
				goto default;
			}
			result = sprite.ATK;
			break;
		case 1242496940u:
			if (!(statName == "DEF"))
			{
				goto default;
			}
			result = sprite.DEF;
			break;
		case 139277044u:
			if (!(statName == "SATK"))
			{
				goto default;
			}
			result = sprite.SATK;
			break;
		case 1164482377u:
			if (!(statName == "SDEF"))
			{
				goto default;
			}
			result = sprite.SDEF;
			break;
		case 1528554166u:
			if (!(statName == "SPD"))
			{
				goto default;
			}
			result = sprite.SPD;
			break;
		case 3636696446u:
			if (!(statName == "INT"))
			{
				goto default;
			}
			result = sprite.INT;
			break;
		default:
			result = 0;
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}

	private bool HasSpecialAbility(BattleSprite sprite, string abilityName, BattleMode battleMode)
	{
		string abilityName2 = abilityName;
		return Enumerable.Any<Item>((global::System.Collections.Generic.IEnumerable<Item>)GetActiveItems(sprite, battleMode), (Func<Item, bool>)((Item item) => item != null && (item.Effect?.SpecialAbilities?.Contains(abilityName2)).GetValueOrDefault()));
	}

	private static string DisplayStatName(string stat)
	{
		if (1 == 0)
		{
		}
		string result = ((stat == "SATK") ? "MGK" : ((!(stat == "SDEF")) ? stat : "MDF"));
		if (1 == 0)
		{
		}
		return result;
	}

	private static string GetSpecialAbilitySlot(BattleSprite sprite, string abilityName, BattleMode battleMode)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		global::System.Collections.Generic.IEnumerator<ValueTuple<string, Item>> enumerator = GetActiveSlotItems(sprite, battleMode).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				ValueTuple<string, Item> current = enumerator.Current;
				string item = current.Item1;
				Item item2 = current.Item2;
				ItemEffect? effect = item2.Effect;
				if (effect != null && (effect.SpecialAbilities?.Contains(abilityName)).GetValueOrDefault())
				{
					return item;
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		return "";
	}

	private HashSet<string> GetAllSpecialAbilities(BattleSprite sprite, BattleMode battleMode)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		HashSet<string> val = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		Enumerator<Item> enumerator = GetActiveItems(sprite, battleMode).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Item current = enumerator.Current;
				if (current?.Effect?.SpecialAbilities == null)
				{
					continue;
				}
				Enumerator<string> enumerator2 = current.Effect.SpecialAbilities.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						string current2 = enumerator2.Current;
						val.Add(current2);
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator2).Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		return val;
	}

	private List<Item> GetActiveItems(BattleSprite sprite, BattleMode battleMode)
	{
		List<Item> val = new List<Item>();
		Dictionary<string, Item?> equipments = sprite.Equipments;
		Item item = default(Item);
		if (equipments != null && equipments.TryGetValue("gear", ref item) && item != null)
		{
			val.Add(item);
		}
		Dictionary<string, Item?> equipments2 = sprite.Equipments;
		Item item2 = default(Item);
		if (equipments2 != null && equipments2.TryGetValue("talent", ref item2) && item2 != null)
		{
			val.Add(item2);
		}
		if (battleMode != BattleMode.PVP)
		{
			Dictionary<string, Item?> equipments3 = sprite.Equipments;
			Item item3 = default(Item);
			if (equipments3 != null && equipments3.TryGetValue("heldItem", ref item3) && item3 != null)
			{
				val.Add(item3);
			}
		}
		return val;
	}

	private TurnBasedEffectTracker GetTurnBasedEffects(string spiritId)
	{
		if (!_turnBasedEffects.ContainsKey(spiritId))
		{
			_turnBasedEffects[spiritId] = new TurnBasedEffectTracker();
		}
		return _turnBasedEffects[spiritId];
	}

	private bool IsOppositeType(SpiritType moveType, SpiritType spiritType)
	{
		return _typeEffectivenessService.GetEffectiveness(moveType, spiritType) < 1.0;
	}
}
