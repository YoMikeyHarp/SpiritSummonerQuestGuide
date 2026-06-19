using System;

namespace SpiritSummoner.Infrastructure.Contracts;

public interface IServerTimeProvider
{
	void SetServerTime(DateTimeOffset serverTime);

	DateTimeOffset GetCurrentServerTime();
}
