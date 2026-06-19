using System;
using Microsoft.Extensions.DependencyInjection;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Infrastructure.FirebaseListeners;
using SpiritSummoner.Infrastructure.Persistence.Repositories;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.ViewModels.Battles;

namespace SpiritSummoner.Infrastructure.Configuration;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		ServiceCollectionServiceExtensions.AddSingleton<IPreferencesService, MauiPreferencesService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerNotificationService, PlayerNotificationService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerRepository, PlayerRepository>(services);
		ServiceCollectionServiceExtensions.AddSingleton<ISpiritRepository, SpiritRepository>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IMoveRepository, MoveRepository>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IItemRepository, ItemRepository>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IQuestRepository, QuestRepository>(services);
		ServiceCollectionServiceExtensions.AddSingleton<ILeaderboardRepository, LeaderboardRepository>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IBattleLogRepository, BattleLogRepository>(services);
		ServiceCollectionServiceExtensions.AddSingleton<GuildRepository>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IGuildRepository>(services, (Func<IServiceProvider, IGuildRepository>)((IServiceProvider sp) => ServiceProviderServiceExtensions.GetRequiredService<GuildRepository>(sp)));
		ServiceCollectionServiceExtensions.AddSingleton<IGuildCoreRepository>(services, (Func<IServiceProvider, IGuildCoreRepository>)((IServiceProvider sp) => ServiceProviderServiceExtensions.GetRequiredService<GuildRepository>(sp)));
		ServiceCollectionServiceExtensions.AddSingleton<IGuildMemberRepository>(services, (Func<IServiceProvider, IGuildMemberRepository>)((IServiceProvider sp) => ServiceProviderServiceExtensions.GetRequiredService<GuildRepository>(sp)));
		ServiceCollectionServiceExtensions.AddSingleton<IGuildSearchRepository>(services, (Func<IServiceProvider, IGuildSearchRepository>)((IServiceProvider sp) => ServiceProviderServiceExtensions.GetRequiredService<GuildRepository>(sp)));
		ServiceCollectionServiceExtensions.AddSingleton<IGuildWarRepository>(services, (Func<IServiceProvider, IGuildWarRepository>)((IServiceProvider sp) => ServiceProviderServiceExtensions.GetRequiredService<GuildRepository>(sp)));
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerSpiritRepository, PlayerSpiritRepository>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IStaticDataCacheService, StaticDataCacheService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IDMCacheService, DMCacheService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IGuildChatCacheService, GuildChatCacheService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IServerTimeProvider, ServerTimeProvider>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IAppVersionService, AppVersionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IAuthService, AuthService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<QuestParagraphService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IBattleAnimationService, BattleAnimationService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerEnergyRegenerationService, PlayerEnergyRegenerationService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<ISpiritActionService, SpiritActionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IBatchQueueService, PersistentBatchQueueService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IPresenceService, PresenceService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IDailyGiftService, DailyGiftService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerNotificationListenerService, PlayerNotificationListenerService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IGuildListenerService, GuildListenerService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<ISessionListenerService, SessionListenerService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IAppVersionListenerService, AppVersionListenerService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<INotificationProcessorService, NotificationProcessorService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IChatListenerService, ChatListenerService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IChatRepository, ChatRepository>(services);
		return services;
	}
}
