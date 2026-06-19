using System;

namespace SpiritSummoner.Application.UseCases.Common;

public class UseCaseException : global::System.Exception
{
	public UseCaseException(string message)
		: base(message)
	{
	}

	public UseCaseException(string message, global::System.Exception innerException)
		: base(message, innerException)
	{
	}
}
