using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Application.UseCases.Common;

public class ValidationResult
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsValid
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ErrorMessage
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ValidationError? Error
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public static ValidationResult Success()
	{
		return new ValidationResult
		{
			IsValid = true
		};
	}

	public static ValidationResult Failure(string message)
	{
		return new ValidationResult
		{
			IsValid = false,
			ErrorMessage = message
		};
	}

	public static ValidationResult Failure(string message, ValidationError error)
	{
		return new ValidationResult
		{
			IsValid = false,
			ErrorMessage = message,
			Error = error
		};
	}
}
