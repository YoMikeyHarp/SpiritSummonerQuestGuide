using System.Threading.Tasks;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Services;

public interface IBottomSheetService
{
	global::System.Threading.Tasks.Task<TResult> ShowSheetAsync<TResult>(BottomSheet sheet, string? sheetId = null);

	global::System.Threading.Tasks.Task ShowSheetAsync(BottomSheet sheet);

	void SetResult<TResult>(string sheetId, TResult result);

	global::System.Threading.Tasks.Task DismissAsync(BottomSheet sheet);
}
