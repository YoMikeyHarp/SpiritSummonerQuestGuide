using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Domain.Services;

public class SpiritMoveResolver : ISpiritMoveResolver
{
	private readonly ISpiritRepository _spiritRepository;

	public SpiritMoveResolver(ISpiritRepository spiritRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_spiritRepository = spiritRepository ?? throw new ArgumentNullException("spiritRepository");
	}

	public Move? FindMoveTemplate(string moveName, Spirit currentTemplate)
	{
		string moveName2 = moveName;
		if (string.IsNullOrEmpty(moveName2) || currentTemplate == null)
		{
			return null;
		}
		Spirit spirit = currentTemplate;
		HashSet<int> val = new HashSet<int>();
		while (spirit != null)
		{
			List<Move>? learnableMoves = spirit.LearnableMoves;
			Move move = ((learnableMoves != null) ? Enumerable.FirstOrDefault<Move>((global::System.Collections.Generic.IEnumerable<Move>)learnableMoves, (Func<Move, bool>)((Move m) => m.Name == moveName2)) : null);
			if (move != null)
			{
				return move;
			}
			if (spirit.PreEvolution <= 0 || !val.Add(spirit.PreEvolution))
			{
				break;
			}
			spirit = _spiritRepository.GetById(spirit.PreEvolution.ToString());
		}
		return null;
	}

	public global::System.Collections.Generic.IReadOnlyList<Move> GetAllMovesAcrossChain(Spirit currentTemplate)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		if (currentTemplate == null)
		{
			return global::System.Array.Empty<Move>();
		}
		HashSet<string> val = new HashSet<string>();
		List<Move> val2 = new List<Move>();
		Spirit spirit = currentTemplate;
		HashSet<int> val3 = new HashSet<int>();
		while (spirit != null)
		{
			if (spirit.LearnableMoves != null)
			{
				Enumerator<Move> enumerator = spirit.LearnableMoves.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Move current = enumerator.Current;
						string text = current.Name ?? string.Empty;
						if (!string.IsNullOrEmpty(text) && val.Add(text))
						{
							val2.Add(current);
						}
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			if (spirit.PreEvolution <= 0 || !val3.Add(spirit.PreEvolution))
			{
				break;
			}
			spirit = _spiritRepository.GetById(spirit.PreEvolution.ToString());
		}
		return (global::System.Collections.Generic.IReadOnlyList<Move>)val2;
	}
}
