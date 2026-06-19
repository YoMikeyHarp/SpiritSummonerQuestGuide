using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SpiritSummoner.Infrastructure.Diagnostics;

public sealed class BattleLogCapture : TraceListener
{
	private static readonly string[] _capturedPrefixes = new string[4] { "[BattleStats]", "[BattleCalc]", "[AbilityFX]", "Recalculating" };

	private readonly Lock _gate = new Lock();

	private readonly List<string> _lines = new List<string>();

	private string? _pending;

	private bool _active;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public static BattleLogCapture Instance
	{
		[CompilerGenerated]
		get;
	} = new BattleLogCapture();


	public bool HasEntries
	{
		get
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			Scope val = _gate.EnterScope();
			try
			{
				return _lines.Count > 0;
			}
			finally
			{
				((Scope)(ref val)).Dispose();
			}
		}
	}

	private BattleLogCapture()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		((TraceListener)this).Name = "BattleLogCapture";
	}

	public global::System.Collections.Generic.IReadOnlyList<string> Snapshot()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Scope val = _gate.EnterScope();
		try
		{
			return new _003C_003Ez__ReadOnlyArray<string>(_lines.ToArray());
		}
		finally
		{
			((Scope)(ref val)).Dispose();
		}
	}

	public void BeginBattle()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Scope val = _gate.EnterScope();
		try
		{
			_lines.Clear();
			_pending = null;
			_active = true;
		}
		finally
		{
			((Scope)(ref val)).Dispose();
		}
	}

	public void EndBattle()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Scope val = _gate.EnterScope();
		try
		{
			_active = false;
		}
		finally
		{
			((Scope)(ref val)).Dispose();
		}
	}

	public override void Write(string? message)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(message))
		{
			return;
		}
		Scope val = _gate.EnterScope();
		try
		{
			_pending = (_pending ?? string.Empty) + message;
		}
		finally
		{
			((Scope)(ref val)).Dispose();
		}
	}

	public override void WriteLine(string? message)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Scope val = _gate.EnterScope();
		try
		{
			string text = (_pending ?? string.Empty) + (message ?? string.Empty);
			_pending = null;
			if (_active && StartsWithCapturedPrefix(text))
			{
				_lines.Add(text);
			}
		}
		finally
		{
			((Scope)(ref val)).Dispose();
		}
	}

	private static bool StartsWithCapturedPrefix(string line)
	{
		string[] capturedPrefixes = _capturedPrefixes;
		foreach (string text in capturedPrefixes)
		{
			if (line.StartsWith(text, (StringComparison)4))
			{
				return true;
			}
		}
		return false;
	}
}
