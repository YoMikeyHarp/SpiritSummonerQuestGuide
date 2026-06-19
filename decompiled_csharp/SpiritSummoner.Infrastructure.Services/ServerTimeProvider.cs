using System;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Infrastructure.Services;

public sealed class ServerTimeProvider : IServerTimeProvider
{
	private DateTimeOffset _anchorServerTime;

	private long _anchorTickCount;

	private bool _hasServerTime;

	public void SetServerTime(DateTimeOffset serverTime)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		_anchorServerTime = serverTime;
		_anchorTickCount = Environment.TickCount64;
		_hasServerTime = true;
		Console.WriteLine($"ServerTimeProvider: anchored at {serverTime:O}");
	}

	public DateTimeOffset GetCurrentServerTime()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (!_hasServerTime)
		{
			return DateTimeOffset.UtcNow;
		}
		long num = Environment.TickCount64 - _anchorTickCount;
		return ((DateTimeOffset)(ref _anchorServerTime)).AddMilliseconds((double)num);
	}
}
