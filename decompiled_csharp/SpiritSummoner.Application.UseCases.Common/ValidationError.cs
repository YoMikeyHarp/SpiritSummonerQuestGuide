using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Application.UseCases.Common;

public class ValidationError
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string FieldName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Message
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, object> Metadata
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, object>();


	public ValidationError(string fieldName, string message)
	{
		FieldName = fieldName;
		Message = message;
	}

	public ValidationError(string fieldName, string message, Dictionary<string, object> metadata)
	{
		FieldName = fieldName;
		Message = message;
		Metadata = metadata;
	}

	public virtual string ToString()
	{
		return FieldName + ": " + Message;
	}
}
