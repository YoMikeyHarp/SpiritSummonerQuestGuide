using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public record FilterCriteria(global::System.Collections.Generic.IEnumerable<string> SelectedTypes, global::System.Collections.Generic.IEnumerable<string> SelectedCategories, bool Favorites)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(FilterCriteria);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("FilterCriteria");
		val.Append(" { ");
		if (PrintMembers(val))
		{
			val.Append(' ');
		}
		val.Append('}');
		return ((object)val).ToString();
	}

	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("SelectedTypes = ");
		builder.Append((object)SelectedTypes);
		builder.Append(", SelectedCategories = ");
		builder.Append((object)SelectedCategories);
		builder.Append(", Favorites = ");
		builder.Append(((object)Favorites).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(FilterCriteria? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<global::System.Collections.Generic.IEnumerable<string>>.Default.Equals(SelectedTypes, other.SelectedTypes) && EqualityComparer<global::System.Collections.Generic.IEnumerable<string>>.Default.Equals(SelectedCategories, other.SelectedCategories) && EqualityComparer<bool>.Default.Equals(Favorites, other.Favorites));
	}
}
