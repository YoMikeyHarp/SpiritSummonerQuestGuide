using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Enums.Items;

namespace SpiritSummoner.Domain.Entities.Items;

public class Item
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Description
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Image
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public RequirementTypes? Requirements
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ItemType ItemType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ItemEffect? Effect
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsNew
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public Item()
	{
	}

	public Item(Item original)
	{
		ID = original.ID;
		Name = original.Name;
		Description = original.Description;
		Image = original.Image;
		Requirements = original.Requirements;
		ItemType = original.ItemType;
		Effect = original.Effect;
		IsNew = original.IsNew;
	}

	public static Item Rehydrate(string id, string name, string description, string image, ItemType itemType, RequirementTypes? requirements, ItemEffect? effect)
	{
		return new Item
		{
			ID = id,
			Name = name,
			Description = description,
			Image = image,
			ItemType = itemType,
			Requirements = requirements,
			Effect = effect,
			IsNew = false
		};
	}
}
