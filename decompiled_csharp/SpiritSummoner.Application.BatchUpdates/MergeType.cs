namespace SpiritSummoner.Application.BatchUpdates;

public enum MergeType
{
	Ignore,
	Accumulate,
	AccumulateNullable,
	LatestWins,
	LatestWinsNonNull,
	OrFlags,
	DictionaryAccumulate,
	DictionaryReplace,
	ListConcat,
	DeepMerge,
	Computed
}
