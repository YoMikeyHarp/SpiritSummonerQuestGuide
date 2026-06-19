using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using epj.ProgressBar.Maui;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public interface IBattleAnimationService
{
	global::System.Threading.Tasks.Task AnimateVsScreenFade(Image vsCanvas);

	global::System.Threading.Tasks.Task AnimatePlayerAttack(Image playerSprite, Grid battleContent, double effectiveness = 1.0);

	global::System.Threading.Tasks.Task AnimateEnemyAttack(Image enemySprite, Grid battleContent, double effectiveness = 1.0);

	global::System.Threading.Tasks.Task AnimateSpiritSwitchOut(Image sprite, bool isPlayer);

	global::System.Threading.Tasks.Task AnimateSpiritEntry(Image sprite, bool isPlayer);

	global::System.Threading.Tasks.Task AnimateMoveIndicator(View indicator, bool show);

	global::System.Threading.Tasks.Task AnimateDamageIndicator(HorizontalStackLayout indicator, bool show, double effectiveness = 1.0);

	global::System.Threading.Tasks.Task AnimateHealthDrain(ProgressBar healthBar, double fromValue, double toValue);

	global::System.Threading.Tasks.Task AnimateScreenShake(Grid battleContent, double intensity = 1.0);

	global::System.Threading.Tasks.Task AnimateCriticalHit(Grid battleArea);

	global::System.Threading.Tasks.Task AnimateCriticalLabel(View label, bool show);

	global::System.Threading.Tasks.Task AnimateStatusBadge(View badge, bool show);

	global::System.Threading.Tasks.Task AnimateStatusIcon(View badge, bool show, bool isPlayer);

	global::System.Threading.Tasks.Task AnimateVictoryPose(Image sprite);

	global::System.Threading.Tasks.Task AnimateDefeatPose(Image sprite);
}
