using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Application.UseCases.Common;

public class Result<T>
{
	public bool Success
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public T? Data
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public string? ErrorMessage
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public List<ValidationError> ValidationErrors
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<ValidationError>();


	public static Result<T> SuccessResult(T data)
	{
		return new Result<T>
		{
			Success = true,
			Data = data
		};
	}

	public static Result<T> FailureResult(string errorMessage)
	{
		return new Result<T>
		{
			Success = false,
			ErrorMessage = errorMessage
		};
	}

	public static Result<T> FailureResult(string errorMessage, ValidationError validationError)
	{
		Result<T> obj = new Result<T>
		{
			Success = false,
			ErrorMessage = errorMessage
		};
		List<ValidationError> obj2 = new List<ValidationError>();
		obj2.Add(validationError);
		obj.ValidationErrors = obj2;
		return obj;
	}

	public static Result<T> ValidationFailureResult(List<ValidationError> validationErrors)
	{
		return new Result<T>
		{
			Success = false,
			ValidationErrors = validationErrors,
			ErrorMessage = "Validation failed"
		};
	}

	public static Result<T> ValidationFailureResult(string fieldName, string errorMessage)
	{
		Result<T> obj = new Result<T>
		{
			Success = false
		};
		List<ValidationError> obj2 = new List<ValidationError>();
		obj2.Add(new ValidationError(fieldName, errorMessage));
		obj.ValidationErrors = obj2;
		obj.ErrorMessage = errorMessage;
		return obj;
	}
}
