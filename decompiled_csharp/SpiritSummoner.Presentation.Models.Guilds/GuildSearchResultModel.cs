using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Models.Guilds;

public record GuildSearchResultModel
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GuildSearchResultModel);
		}
	}

	public string Id
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	public string Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	public string Description
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	public string Emblem
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = "\ud83d\udc51";


	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public int Rank
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public int MemberCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public int MaxMembers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public int Trophies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool IsPublic
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool RequiresApproval
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public int MinLevelRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public int MinTrophiesRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool IsEligible
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public string? IneligibilityReason
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public string LevelDisplay => $"Lv. {Level}";

	public string RankDisplay => $"#{Rank}";

	public string MemberDisplay => $"{MemberCount}/{MaxMembers}";

	public string TrophiesDisplay => $"{Trophies:N0} \ud83c\udfc6";

	public bool IsFull => MemberCount >= MaxMembers;

	public string StatusDisplay => IsFull ? "Full" : (RequiresApproval ? "Request to Join" : "Open");

	public string RequirementsDisplay
	{
		get
		{
			List<string> val = new List<string>();
			if (MinLevelRequired > 1)
			{
				val.Add($"Lv. {MinLevelRequired}+");
			}
			if (MinTrophiesRequired > 0)
			{
				val.Add($"{MinTrophiesRequired:N0} \ud83c\udfc6");
			}
			return (val.Count > 0) ? string.Join(", ", (global::System.Collections.Generic.IEnumerable<string>)val) : "No requirements";
		}
	}

	public Color StatusColor => IsFull ? Color.FromArgb("#FF0000") : (IsEligible ? Color.FromArgb("#00FF00") : Color.FromArgb("#FFA500"));

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GuildSearchResultModel");
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
		builder.Append("Id = ");
		builder.Append((object)Id);
		builder.Append(", Name = ");
		builder.Append((object)Name);
		builder.Append(", Description = ");
		builder.Append((object)Description);
		builder.Append(", Emblem = ");
		builder.Append((object)Emblem);
		builder.Append(", Level = ");
		builder.Append(((object)Level).ToString());
		builder.Append(", Rank = ");
		builder.Append(((object)Rank).ToString());
		builder.Append(", MemberCount = ");
		builder.Append(((object)MemberCount).ToString());
		builder.Append(", MaxMembers = ");
		builder.Append(((object)MaxMembers).ToString());
		builder.Append(", Trophies = ");
		builder.Append(((object)Trophies).ToString());
		builder.Append(", IsPublic = ");
		builder.Append(((object)IsPublic).ToString());
		builder.Append(", RequiresApproval = ");
		builder.Append(((object)RequiresApproval).ToString());
		builder.Append(", MinLevelRequired = ");
		builder.Append(((object)MinLevelRequired).ToString());
		builder.Append(", MinTrophiesRequired = ");
		builder.Append(((object)MinTrophiesRequired).ToString());
		builder.Append(", IsEligible = ");
		builder.Append(((object)IsEligible).ToString());
		builder.Append(", IneligibilityReason = ");
		builder.Append((object)IneligibilityReason);
		builder.Append(", LevelDisplay = ");
		builder.Append((object)LevelDisplay);
		builder.Append(", RankDisplay = ");
		builder.Append((object)RankDisplay);
		builder.Append(", MemberDisplay = ");
		builder.Append((object)MemberDisplay);
		builder.Append(", TrophiesDisplay = ");
		builder.Append((object)TrophiesDisplay);
		builder.Append(", IsFull = ");
		builder.Append(((object)IsFull).ToString());
		builder.Append(", StatusDisplay = ");
		builder.Append((object)StatusDisplay);
		builder.Append(", RequirementsDisplay = ");
		builder.Append((object)RequirementsDisplay);
		builder.Append(", StatusColor = ");
		builder.Append((object)StatusColor);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GuildSearchResultModel? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Id, other.Id) && EqualityComparer<string>.Default.Equals(Name, other.Name) && EqualityComparer<string>.Default.Equals(Description, other.Description) && EqualityComparer<string>.Default.Equals(Emblem, other.Emblem) && EqualityComparer<int>.Default.Equals(Level, other.Level) && EqualityComparer<int>.Default.Equals(Rank, other.Rank) && EqualityComparer<int>.Default.Equals(MemberCount, other.MemberCount) && EqualityComparer<int>.Default.Equals(MaxMembers, other.MaxMembers) && EqualityComparer<int>.Default.Equals(Trophies, other.Trophies) && EqualityComparer<bool>.Default.Equals(IsPublic, other.IsPublic) && EqualityComparer<bool>.Default.Equals(RequiresApproval, other.RequiresApproval) && EqualityComparer<int>.Default.Equals(MinLevelRequired, other.MinLevelRequired) && EqualityComparer<int>.Default.Equals(MinTrophiesRequired, other.MinTrophiesRequired) && EqualityComparer<bool>.Default.Equals(IsEligible, other.IsEligible) && EqualityComparer<string>.Default.Equals(IneligibilityReason, other.IneligibilityReason));
	}
}
