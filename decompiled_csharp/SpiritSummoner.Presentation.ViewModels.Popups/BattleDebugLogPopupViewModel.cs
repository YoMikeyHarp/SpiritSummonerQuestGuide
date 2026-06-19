using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Infrastructure.Diagnostics;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class BattleDebugLogPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CTapToExit_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleDebugLogPopupViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0 || !_003C_003E4__this._isClosing)
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							_003C_003E4__this._isClosing = true;
							awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTapToExit_003Ed__39 _003CTapToExit_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTapToExit_003Ed__39>(ref awaiter, ref _003CTapToExit_003Ed__);
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
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this._isClosing = false;
						}
					}
				}
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

	private readonly IPopupService _popupService;

	private bool _isClosing;

	private static readonly Regex GuidRegex = new Regex("\\s*\\([a-fA-F0-9]{8}-(?:[a-fA-F0-9]{4}-){3}[a-fA-F0-9]{12}\\)", (RegexOptions)8);

	private static readonly Regex EquipmentRegex = new Regex("Recalculating stats for\\s+(?:\\[(P|E)\\])?\\s*(.*?)\\s+equipment:\\s*(.*)", (RegexOptions)1);

	private static readonly Regex EntranceRegex = new Regex("[=═]+\\s*(.*?)\\s*[=═]+.*HP=(\\d+)");

	private static readonly Regex StatChangeRegex = new Regex("([A-Z]+):(\\d+)[→\\->\\u2192]+(\\d+)");

	private static readonly Regex BaseStatRegex = new Regex("([A-Z]{3,4})=(\\d+)\\((\\d+)\\+(\\d+)pts×([\\d\\.]+)\\)");

	private static readonly Regex SimpleMultRegex = new Regex("^([a-zA-Z\\s]+)×([\\d\\.]+)$");

	private static readonly Regex AnyMultRegex = new Regex("×([\\d\\.]+)");

	private static readonly Regex MathModifierRegex = new Regex("—\\s*([A-Z]+)\\s*(\\d+)×([\\d\\.]+)=(\\d+)");

	private static readonly Color ColorPlayer = Color.FromArgb("#4DB6AC");

	private static readonly Color ColorEnemy = Color.FromArgb("#9575CD");

	private static readonly Color ColorMove = Color.FromArgb("#FFB300");

	private static readonly Color ColorBuff = Color.FromArgb("#81C784");

	private static readonly Color ColorMath = Color.FromArgb("#888888");

	private static readonly Color ColorText = Color.FromArgb("#E0E0E0");

	private static readonly Color ColorError = Color.FromArgb("#FF5252");

	private static readonly Color ColorGear = Color.FromArgb("#29B6F6");

	private static readonly Color ColorTalent = Color.FromArgb("#EC407A");

	private static readonly Color ColorHeldItem = Color.FromArgb("#FFA000");

	private static readonly string[] ActionSeparators = new string[2] { " used ", " on " };

	private readonly Dictionary<string, string> _itemSlotMap = new Dictionary<string, string>((IEqualityComparer<string>)(object)StringComparer.OrdinalIgnoreCase);

	private List<BattleLogEntry> _logEntries = new List<BattleLogEntry>();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? tapToExitCommand;

	public List<BattleLogEntry> LogEntries
	{
		get
		{
			return _logEntries;
		}
		set
		{
			((ObservableObject)this).SetProperty<List<BattleLogEntry>>(ref _logEntries, value, "LogEntries");
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand TapToExitCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = tapToExitCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)TapToExit);
				AsyncRelayCommand val2 = val;
				tapToExitCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	private static Color GetSlotColor(string slot)
	{
		string text = slot.ToLowerInvariant();
		if (1 == 0)
		{
		}
		Color result = ((text == "gear") ? ColorGear : ((text == "talent") ? ColorTalent : ((!(text == "helditem")) ? ColorBuff : ColorHeldItem)));
		if (1 == 0)
		{
		}
		return result;
	}

	private static string GetSlotLabel(string slot)
	{
		string text = slot.ToLowerInvariant();
		if (1 == 0)
		{
		}
		string result = ((text == "gear") ? "Gear" : ((text == "talent") ? "Talent" : ((!(text == "helditem")) ? slot : "Held")));
		if (1 == 0)
		{
		}
		return result;
	}

	public BattleDebugLogPopupViewModel(IPopupService popupService)
	{
		_popupService = popupService;
		global::System.Collections.Generic.IReadOnlyList<string> rawLogs = BattleLogCapture.Instance.Snapshot();
		LogEntries = ProcessLogsIntoSpans((global::System.Collections.Generic.IEnumerable<string>)rawLogs);
	}

	private List<BattleLogEntry> ProcessLogsIntoSpans(global::System.Collections.Generic.IEnumerable<string> rawLogs)
	{
		List<BattleLogEntry> val = new List<BattleLogEntry>();
		_itemSlotMap.Clear();
		global::System.Collections.Generic.IEnumerator<string> enumerator = rawLogs.GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string current = enumerator.Current;
				string cleanLine = GuidRegex.Replace(current, string.Empty);
				if (!TryParseEquipment(cleanLine, val) && !TryParseStatChanges(cleanLine, val) && !TryParseEntranceAnimation(cleanLine, val) && !TryParseTurnHeader(cleanLine, val) && !TryParsePassiveAbilities(cleanLine, val) && !TryParseMathModifiers(cleanLine, val) && !TryParseBaseStats(cleanLine, val) && !TryParseNarrativeAttacks(cleanLine, val))
				{
					ParseDefaultOrBackgroundMath(cleanLine, val);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		return val;
	}

	private bool TryParseEquipment(string cleanLine, List<BattleLogEntry> parsedList)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		if (!cleanLine.Contains("Recalculating stats for", (StringComparison)5))
		{
			return false;
		}
		Match val = EquipmentRegex.Match(cleanLine);
		if (!((Group)val).Success)
		{
			return true;
		}
		string text = ((Capture)val.Groups[1]).Value.ToUpperInvariant();
		string text2 = ((Capture)val.Groups[2]).Value.Trim();
		string text3 = ((Capture)val.Groups[3]).Value.Trim();
		Color textColor = ((text == "E") ? ColorError : ColorPlayer);
		FormattedString val2 = new FormattedString();
		((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
		{
			Text = "\n" + text2 + " is equipped with:",
			TextColor = textColor,
			FontAttributes = (FontAttributes)1
		});
		parsedList.Add(new BattleLogEntry
		{
			FormattedContent = val2
		});
		if (string.Equals(text3, "None", (StringComparison)5))
		{
			FormattedString val3 = new FormattedString();
			((global::System.Collections.Generic.ICollection<Span>)val3.Spans).Add(new Span
			{
				Text = "  • Nothing",
				TextColor = ColorMath,
				FontAttributes = (FontAttributes)2
			});
			parsedList.Add(new BattleLogEntry
			{
				FormattedContent = val3
			});
			return true;
		}
		string[] array = text3.Split('|', (StringSplitOptions)1);
		foreach (string text4 in array)
		{
			string text5 = text4.Trim();
			string text6 = "";
			string text7 = text5;
			int num = text5.IndexOf(':');
			if (num > 0)
			{
				text6 = text5.Substring(0, num).Trim();
				text7 = text5.Substring(num + 1).Trim();
			}
			string text8 = text7;
			string text9 = "";
			int num2 = text7.IndexOf('(');
			if (num2 != -1)
			{
				text8 = text7.Substring(0, num2).Trim();
				text9 = text7.Substring(num2).Trim();
			}
			if (!string.IsNullOrEmpty(text6) && !string.IsNullOrEmpty(text8))
			{
				_itemSlotMap[text8] = text6;
			}
			Color textColor2 = (string.IsNullOrEmpty(text6) ? ColorBuff : GetSlotColor(text6));
			FormattedString val4 = new FormattedString();
			((global::System.Collections.Generic.ICollection<Span>)val4.Spans).Add(new Span
			{
				Text = "  • ",
				TextColor = ColorMath
			});
			if (!string.IsNullOrEmpty(text6))
			{
				((global::System.Collections.Generic.ICollection<Span>)val4.Spans).Add(new Span
				{
					Text = "[" + GetSlotLabel(text6) + "] ",
					TextColor = textColor2,
					FontAttributes = (FontAttributes)1
				});
			}
			((global::System.Collections.Generic.ICollection<Span>)val4.Spans).Add(new Span
			{
				Text = text8 + " ",
				TextColor = textColor2,
				FontAttributes = (FontAttributes)1
			});
			if (!string.IsNullOrEmpty(text9))
			{
				((global::System.Collections.Generic.ICollection<Span>)val4.Spans).Add(new Span
				{
					Text = text9,
					TextColor = ColorMath,
					FontAttributes = (FontAttributes)2
				});
			}
			parsedList.Add(new BattleLogEntry
			{
				FormattedContent = val4
			});
		}
		return true;
	}

	private static bool TryParseEntranceAnimation(string cleanLine, List<BattleLogEntry> parsedList)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		if (!cleanLine.Contains("══"))
		{
			return false;
		}
		Match val = EntranceRegex.Match(cleanLine);
		if (!((Group)val).Success)
		{
			return false;
		}
		string text = ((Capture)val.Groups[1]).Value.Trim();
		string value = ((Capture)val.Groups[2]).Value;
		Color textColor = ColorPlayer;
		if (text.StartsWith("[P]", (StringComparison)5))
		{
			text = text.Substring(3).Trim();
		}
		else if (text.StartsWith("[E]", (StringComparison)5))
		{
			textColor = ColorError;
			text = text.Substring(3).Trim();
		}
		FormattedString val2 = new FormattedString();
		((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
		{
			Text = "\n══ " + text + " ══ ",
			TextColor = textColor,
			FontAttributes = (FontAttributes)1
		});
		((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
		{
			Text = "(HP: " + value + ")",
			TextColor = ColorBuff,
			FontAttributes = (FontAttributes)1
		});
		parsedList.Add(new BattleLogEntry
		{
			FormattedContent = val2
		});
		return true;
	}

	private static bool TryParseStatChanges(string cleanLine, List<BattleLogEntry> parsedList)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		if (!cleanLine.Contains("After Equipment"))
		{
			return false;
		}
		MatchCollection val = StatChangeRegex.Matches(cleanLine);
		foreach (Match item in val)
		{
			Match val2 = item;
			string value = ((Capture)val2.Groups[1]).Value;
			int num = int.Parse(((Capture)val2.Groups[2]).Value);
			int num2 = int.Parse(((Capture)val2.Groups[3]).Value);
			int num3 = num2 - num;
			if (num3 != 0)
			{
				string text = ((num3 > 0) ? "+" : "-");
				int num4 = Math.Abs(num3);
				Color textColor = ((num3 > 0) ? ColorBuff : ColorError);
				Color textColor2 = ((num3 > 0) ? ColorBuff : ColorError);
				FormattedString val3 = new FormattedString();
				((global::System.Collections.Generic.ICollection<Span>)val3.Spans).Add(new Span
				{
					Text = "  ↳ " + value + ": ",
					TextColor = ColorMove,
					FontAttributes = (FontAttributes)1
				});
				((global::System.Collections.Generic.ICollection<Span>)val3.Spans).Add(new Span
				{
					Text = $"{num} ",
					TextColor = ColorMath
				});
				((global::System.Collections.Generic.ICollection<Span>)val3.Spans).Add(new Span
				{
					Text = $"{text} ({num4}) ",
					TextColor = textColor,
					FontAttributes = (FontAttributes)1
				});
				((global::System.Collections.Generic.ICollection<Span>)val3.Spans).Add(new Span
				{
					Text = "→ ",
					TextColor = ColorText
				});
				((global::System.Collections.Generic.ICollection<Span>)val3.Spans).Add(new Span
				{
					Text = $"{num2}",
					TextColor = textColor2,
					FontAttributes = (FontAttributes)1
				});
				parsedList.Add(new BattleLogEntry
				{
					FormattedContent = val3
				});
			}
		}
		return true;
	}

	private static bool TryParseBaseStats(string cleanLine, List<BattleLogEntry> parsedList)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		if (!cleanLine.Contains("Base+Pts×Bonus") && !cleanLine.Contains("│ MDF="))
		{
			return false;
		}
		string text = cleanLine.Replace("[BattleStats]", "").Trim();
		FormattedString val = new FormattedString();
		bool flag = text.StartsWith("Base+Pts×Bonus");
		MatchCollection val2 = BaseStatRegex.Matches(text);
		if (val2.Count > 0)
		{
			int num = 0;
			foreach (Match item in val2)
			{
				Match val3 = item;
				string value = ((Capture)val3.Groups[1]).Value;
				string value2 = ((Capture)val3.Groups[2]).Value;
				string text2 = $"({((Capture)val3.Groups[3]).Value}+{((Capture)val3.Groups[4]).Value}pts×{((Capture)val3.Groups[5]).Value}) ";
				if (1 == 0)
				{
				}
				Color val4 = (Color)((value == "ATK") ? Color.FromArgb("#EF5350") : ((value == "DEF") ? Color.FromArgb("#42A5F5") : ((value == "MGK") ? Color.FromArgb("#AB47BC") : ((value == "MDF") ? Color.FromArgb("#26C6DA") : ((value == "SPD") ? Color.FromArgb("#D4E157") : ((!(value == "INT")) ? ((object)ColorText) : ((object)Color.FromArgb("#FFA726"))))))));
				if (1 == 0)
				{
				}
				Color textColor = val4;
				if (num == 0)
				{
					if (flag)
					{
						((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
						{
							Text = "  ↳ ",
							TextColor = ColorMath,
							FontAttributes = (FontAttributes)1
						});
					}
					else
					{
						((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
						{
							Text = "\u00a0\u00a0\u00a0\u00a0",
							TextColor = ColorMath
						});
					}
				}
				else
				{
					((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
					{
						Text = "\n\u00a0\u00a0\u00a0\u00a0",
						TextColor = ColorMath
					});
				}
				((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
				{
					Text = value + ":",
					TextColor = textColor,
					FontAttributes = (FontAttributes)1,
					FontSize = 12.0
				});
				((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
				{
					Text = value2 + " ",
					TextColor = ColorText,
					FontAttributes = (FontAttributes)1,
					FontSize = 12.0
				});
				((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
				{
					Text = text2,
					TextColor = ColorMath,
					FontSize = 10.0,
					FontAttributes = (FontAttributes)2
				});
				num++;
			}
			parsedList.Add(new BattleLogEntry
			{
				FormattedContent = val
			});
			return true;
		}
		return false;
	}

	private static bool TryParseTurnHeader(string cleanLine, List<BattleLogEntry> parsedList)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		if (!cleanLine.Contains("--- Turn") && !cleanLine.Contains("Turn #"))
		{
			return false;
		}
		string text = cleanLine.Replace("[BattleStats]", "").Trim();
		FormattedString val = new FormattedString();
		((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
		{
			Text = "\n" + text,
			TextColor = ColorMath,
			FontAttributes = (FontAttributes)1
		});
		parsedList.Add(new BattleLogEntry
		{
			FormattedContent = val
		});
		return true;
	}

	private bool TryParsePassiveAbilities(string cleanLine, List<BattleLogEntry> parsedList)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		if (!cleanLine.StartsWith("[AbilityFX]"))
		{
			return false;
		}
		string text = cleanLine.Replace("[AbilityFX]", "").Trim();
		string text2 = "";
		if (text.StartsWith('['))
		{
			int num = text.IndexOf(']');
			if (num > 0)
			{
				text2 = text.Substring(1, num - 1).Trim();
				text = text.Substring(num + 1).Trim();
			}
		}
		int num2 = text.IndexOf('—');
		FormattedString val = new FormattedString();
		if (num2 != -1)
		{
			string text3 = text.Substring(0, num2).Trim();
			string text4 = text.Substring(num2 + 1).Trim();
			if (string.IsNullOrEmpty(text2))
			{
				int num3 = text3.IndexOf('(');
				string text5 = ((num3 >= 0) ? text3.Substring(0, num3).Trim() : text3);
				string text6 = default(string);
				if (_itemSlotMap.TryGetValue(text5, ref text6))
				{
					text2 = text6;
				}
			}
			Color textColor = (string.IsNullOrEmpty(text2) ? ColorMove : GetSlotColor(text2));
			Match val2 = SimpleMultRegex.Match(text4);
			if (((Group)val2).Success)
			{
				float num4 = default(float);
				float num5 = (float.TryParse(((Capture)val2.Groups[2]).Value, ref num4) ? num4 : 1f);
				if (!(Math.Abs(num5 - 1f) > 0.001f))
				{
					return true;
				}
				((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
				{
					Text = text3,
					TextColor = textColor,
					FontAttributes = (FontAttributes)1
				});
				((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
				{
					Text = "\n  ↳ " + ((Capture)val2.Groups[1]).Value.Trim() + ": ",
					TextColor = ColorMath
				});
				((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
				{
					Text = "× (" + ((Capture)val2.Groups[2]).Value + ")",
					TextColor = textColor,
					FontAttributes = (FontAttributes)1
				});
			}
			else
			{
				Match val3 = AnyMultRegex.Match(text4);
				if (((Group)val3).Success)
				{
					float num6 = default(float);
					float num7 = (float.TryParse(((Capture)val3.Groups[1]).Value, ref num6) ? num6 : 1f);
					if (Math.Abs(num7 - 1f) < 0.001f)
					{
						return true;
					}
				}
				((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
				{
					Text = text3,
					TextColor = textColor,
					FontAttributes = (FontAttributes)1
				});
				if (!string.IsNullOrEmpty(text4))
				{
					((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
					{
						Text = " — " + text4,
						TextColor = textColor
					});
				}
			}
		}
		else
		{
			Color textColor2 = (string.IsNullOrEmpty(text2) ? ColorMove : GetSlotColor(text2));
			((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
			{
				Text = text,
				TextColor = textColor2,
				FontAttributes = (FontAttributes)1
			});
		}
		if (((global::System.Collections.Generic.ICollection<Span>)val.Spans).Count > 0)
		{
			parsedList.Add(new BattleLogEntry
			{
				FormattedContent = val
			});
		}
		return true;
	}

	private static bool TryParseMathModifiers(string cleanLine, List<BattleLogEntry> parsedList)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		if (!cleanLine.Contains("DefenseMod"))
		{
			return false;
		}
		Match val = MathModifierRegex.Match(cleanLine);
		if (((Group)val).Success)
		{
			float num = default(float);
			float num2 = (float.TryParse(((Capture)val.Groups[3]).Value, ref num) ? num : 1f);
			if (Math.Abs(num2 - 1f) > 0.001f)
			{
				Color textColor = ((num2 > 1f) ? ColorBuff : ColorError);
				FormattedString val2 = new FormattedString();
				((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
				{
					Text = "  ↳ " + ((Capture)val.Groups[1]).Value + ": ",
					TextColor = ColorMove,
					FontAttributes = (FontAttributes)1
				});
				((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
				{
					Text = ((Capture)val.Groups[2]).Value + " ",
					TextColor = ColorMath
				});
				((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
				{
					Text = "× (" + ((Capture)val.Groups[3]).Value + ") ",
					TextColor = textColor,
					FontAttributes = (FontAttributes)1
				});
				((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
				{
					Text = "→ ",
					TextColor = ColorText
				});
				((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
				{
					Text = (((Capture)val.Groups[4]).Value ?? ""),
					TextColor = textColor,
					FontAttributes = (FontAttributes)1
				});
				parsedList.Add(new BattleLogEntry
				{
					FormattedContent = val2
				});
			}
		}
		return true;
	}

	private static bool TryParseNarrativeAttacks(string cleanLine, List<BattleLogEntry> parsedList)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		if (!cleanLine.StartsWith("[BattleCalc] Damage"))
		{
			return false;
		}
		string text = cleanLine.Replace("[BattleCalc] Damage", "").Trim();
		string text2 = text;
		char[] array = new char[4];
		RuntimeHelpers.InitializeArray((global::System.Array)array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		text = text2.TrimStart(array);
		string[] array2 = text.Split(ActionSeparators, (StringSplitOptions)1);
		if (array2.Length < 3)
		{
			FormattedString val = new FormattedString();
			((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
			{
				Text = text,
				TextColor = ColorText
			});
			parsedList.Add(new BattleLogEntry
			{
				FormattedContent = val
			});
			return true;
		}
		string text3 = array2[0].Trim();
		string text4 = array2[1].Trim();
		string text5 = array2[2].Trim();
		Color textColor = ColorText;
		if (text3.StartsWith("[P]"))
		{
			textColor = ColorPlayer;
			text3 = text3.Substring(3).Trim();
		}
		else if (text3.StartsWith("[E]"))
		{
			textColor = ColorError;
			text3 = text3.Substring(3).Trim();
		}
		Color textColor2 = ColorText;
		if (text5.StartsWith("[P]"))
		{
			textColor2 = ColorPlayer;
			text5 = text5.Substring(3).Trim();
		}
		else if (text5.StartsWith("[E]"))
		{
			textColor2 = ColorError;
			text5 = text5.Substring(3).Trim();
		}
		FormattedString val2 = new FormattedString();
		((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
		{
			Text = text3 + " ",
			TextColor = textColor,
			FontAttributes = (FontAttributes)1
		});
		((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
		{
			Text = "used ",
			TextColor = ColorText
		});
		((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
		{
			Text = text4 + " ",
			TextColor = ColorMove,
			FontAttributes = (FontAttributes)1
		});
		((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
		{
			Text = "on ",
			TextColor = ColorText
		});
		((global::System.Collections.Generic.ICollection<Span>)val2.Spans).Add(new Span
		{
			Text = text5,
			TextColor = textColor2,
			FontAttributes = (FontAttributes)1
		});
		parsedList.Add(new BattleLogEntry
		{
			FormattedContent = val2
		});
		return true;
	}

	private static void ParseDefaultOrBackgroundMath(string cleanLine, List<BattleLogEntry> parsedList)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		FormattedString val = new FormattedString();
		if (cleanLine.StartsWith("[BattleCalc]"))
		{
			string text = cleanLine.Replace("[BattleCalc]", "").Trim();
			if (text.StartsWith("→ final=") || text.StartsWith("→ hit for="))
			{
				string[] array = text.Split('(', (StringSplitOptions)0);
				string text2 = array[0].Replace("→ hit for=", "→ final=").Trim() + " ";
				((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
				{
					Text = text2,
					TextColor = ColorError,
					FontAttributes = (FontAttributes)1
				});
				if (array.Length > 1)
				{
					((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
					{
						Text = "(" + array[1],
						TextColor = ColorMath,
						FontAttributes = (FontAttributes)2
					});
				}
			}
			else if (text.StartsWith("Mults"))
			{
				text = text.Replace("type×1.00", "").Replace("STAB×1.00", "").Replace("crit×1.00", "")
					.Replace("dmg×1.00", "")
					.Replace("hpThresh×1.00", "")
					.Replace("resist×1.00", "")
					.Replace("  ", " ")
					.Trim();
				if (text != "Mults |" && text != "Mults │")
				{
					((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
					{
						Text = text,
						TextColor = ColorMath,
						FontSize = 11.0,
						FontAttributes = (FontAttributes)2
					});
				}
			}
			else
			{
				((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
				{
					Text = text,
					TextColor = ColorMath,
					FontSize = 11.0,
					FontAttributes = (FontAttributes)2
				});
			}
		}
		else
		{
			((global::System.Collections.Generic.ICollection<Span>)val.Spans).Add(new Span
			{
				Text = cleanLine.Replace("[BattleStats]", "").Trim(),
				TextColor = ColorText,
				FontAttributes = (FontAttributes)1
			});
		}
		if (((global::System.Collections.Generic.ICollection<Span>)val.Spans).Count > 0)
		{
			parsedList.Add(new BattleLogEntry
			{
				FormattedContent = val
			});
		}
	}

	[AsyncStateMachine(typeof(_003CTapToExit_003Ed__39))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task TapToExit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTapToExit_003Ed__39 _003CTapToExit_003Ed__ = new _003CTapToExit_003Ed__39();
		_003CTapToExit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CTapToExit_003Ed__._003C_003E4__this = this;
		_003CTapToExit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CTapToExit_003Ed__._003C_003Et__builder)).Start<_003CTapToExit_003Ed__39>(ref _003CTapToExit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CTapToExit_003Ed__._003C_003Et__builder)).Task;
	}
}
