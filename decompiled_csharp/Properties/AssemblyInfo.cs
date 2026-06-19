using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner;
using SpiritSummoner.Presentation.Controls.SpiritControls;
using SpiritSummoner.Presentation.Controls.SquadControls;
using SpiritSummoner.Presentation.Views;
using SpiritSummoner.Presentation.Views.Battle;
using SpiritSummoner.Presentation.Views.Battle.Controls;
using SpiritSummoner.Presentation.Views.BottomSheets;
using SpiritSummoner.Presentation.Views.BottomSheets.ChatSheets;
using SpiritSummoner.Presentation.Views.BottomSheets.Hub;
using SpiritSummoner.Presentation.Views.BottomSheets.Portal;
using SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;
using SpiritSummoner.Presentation.Views.BottomSheets.SquadSheets;
using SpiritSummoner.Presentation.Views.Chats;
using SpiritSummoner.Presentation.Views.Collection;
using SpiritSummoner.Presentation.Views.Guilds;
using SpiritSummoner.Presentation.Views.Onboarding;
using SpiritSummoner.Presentation.Views.Popups;
using SpiritSummoner.Presentation.Views.Popups.BattlePopups;
using SpiritSummoner.Presentation.Views.Popups.CollectionPopups;
using SpiritSummoner.Presentation.Views.Popups.GuildPopups;
using SpiritSummoner.Presentation.Views.Popups.ItemPopups;
using SpiritSummoner.Presentation.Views.Popups.PlayerPopups;
using SpiritSummoner.Presentation.Views.Popups.QuestPopups;
using SpiritSummoner.Presentation.Views.Popups.Shared;
using SpiritSummoner.Presentation.Views.Pouch;
using SpiritSummoner.Presentation.Views.Quests;
using SpiritSummoner.Presentation.Views.Shared;
using SpiritSummoner.Presentation.Views.Shop;
using SpiritSummoner.Presentation.Views.Shop.Controls;
using SpiritSummoner.Presentation.Views.Spirits;
using SpiritSummoner.Presentation.Views.Spirits.Controls;
using __XamlGeneratedCode__;

[assembly: AssemblyCompany("SpiritSummoner")]
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0+2b39faf687d8ac708c44e4a23af09a647fe2a0a5")]
[assembly: AssemblyProduct("SpiritSummoner")]
[assembly: AssemblyTitle("SpiritSummoner")]
[assembly: TargetPlatform("Android35.0")]
[assembly: SupportedOSPlatform("Android23.0")]
[assembly: XamlResourceId("SpiritSummoner.App.xaml", "App.xaml", typeof(App))]
[assembly: XamlResourceId("SpiritSummoner.AppShell.xaml", "AppShell.xaml", typeof(AppShell))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Controls.SpiritControls.SpiritVerticalCardCollectionView.xaml", "Presentation/Controls/SpiritControls/SpiritVerticalCardCollectionView.xaml", typeof(SpiritVerticalCardCollectionView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Controls.SpiritControls.SpiritVerticalCardView.xaml", "Presentation/Controls/SpiritControls/SpiritVerticalCardView.xaml", typeof(SpiritVerticalCardView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Controls.SquadControls.SpiritSquadCardView.xaml", "Presentation/Controls/SquadControls/SpiritSquadCardView.xaml", typeof(SpiritSquadCardView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Controls.SquadControls.SpiritsSquadBottomCardView.xaml", "Presentation/Controls/SquadControls/SpiritsSquadBottomCardView.xaml", typeof(SpiritsSquadBottomCardView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Battle.BattleHubPage.xaml", "Presentation/Views/Battle/BattleHubPage.xaml", typeof(BattleHubPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Battle.BattleListView.xaml", "Presentation/Views/Battle/BattleListView.xaml", typeof(BattleListView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Battle.BattleView.xaml", "Presentation/Views/Battle/BattleView.xaml", typeof(BattleView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Battle.Controls.BattleRewardsView.xaml", "Presentation/Views/Battle/Controls/BattleRewardsView.xaml", typeof(BattleRewardsView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Battle.Controls.BattleTasksView.xaml", "Presentation/Views/Battle/Controls/BattleTasksView.xaml", typeof(BattleTasksView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Battle.Controls.GuildPerksView.xaml", "Presentation/Views/Battle/Controls/GuildPerksView.xaml", typeof(GuildPerksView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.ChatSheets.NewGuildThreadBottomSheet.xaml", "Presentation/Views/BottomSheets/ChatSheets/NewGuildThreadBottomSheet.xaml", typeof(NewGuildThreadBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.ChatSheets.SelectFriendBottomSheet.xaml", "Presentation/Views/BottomSheets/ChatSheets/SelectFriendBottomSheet.xaml", typeof(SelectFriendBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.ConfirmUserNameSheet.xaml", "Presentation/Views/BottomSheets/ConfirmUserNameSheet.xaml", typeof(ConfirmUserNameSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.GuildWarNotificationBottomSheet.xaml", "Presentation/Views/BottomSheets/GuildWarNotificationBottomSheet.xaml", typeof(GuildWarNotificationBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.Hub.HubBottomSheet.xaml", "Presentation/Views/BottomSheets/Hub/HubBottomSheet.xaml", typeof(HubBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.LinkAccountSheet.xaml", "Presentation/Views/BottomSheets/LinkAccountSheet.xaml", typeof(LinkAccountSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.Portal.PortalBottomSheet.xaml", "Presentation/Views/BottomSheets/Portal/PortalBottomSheet.xaml", typeof(PortalBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.RegisterTermsSheet.xaml", "Presentation/Views/BottomSheets/RegisterTermsSheet.xaml", typeof(RegisterTermsSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.ShopSheets.ShopSpiritBottomSheet.xaml", "Presentation/Views/BottomSheets/ShopSheets/ShopSpiritBottomSheet.xaml", typeof(ShopSpiritBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets.AttributesEditBottomSheet.xaml", "Presentation/Views/BottomSheets/SpiritSheets/AttributesEditBottomSheet.xaml", typeof(AttributesEditBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets.EditGearBottomSheet.xaml", "Presentation/Views/BottomSheets/SpiritSheets/EditGearBottomSheet.xaml", typeof(EditGearBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets.EditHeldItemBottomSheet.xaml", "Presentation/Views/BottomSheets/SpiritSheets/EditHeldItemBottomSheet.xaml", typeof(HeldItemBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets.EditTalentBottomSheet.xaml", "Presentation/Views/BottomSheets/SpiritSheets/EditTalentBottomSheet.xaml", typeof(EditTalentBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets.LevelUpBottomSheet.xaml", "Presentation/Views/BottomSheets/SpiritSheets/LevelUpBottomSheet.xaml", typeof(LevelUpBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets.MovesEditBottomSheet.xaml", "Presentation/Views/BottomSheets/SpiritSheets/MovesEditBottomSheet.xaml", typeof(MovesEditBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets.SpiritHoldNavigationSheet.xaml", "Presentation/Views/BottomSheets/SpiritSheets/SpiritHoldNavigationSheet.xaml", typeof(SpiritHoldNavigationSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets.SpiritsMoreBottomSheet.xaml", "Presentation/Views/BottomSheets/SpiritSheets/SpiritsMoreBottomSheet.xaml", typeof(SpiritsMoreBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.BottomSheets.Squads.SavedSquadsBottomSheet.xaml", "Presentation/Views/BottomSheets/Squads/SavedSquadsBottomSheet.xaml", typeof(SavedSquadsBottomSheet))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Chats.ChatView.xaml", "Presentation/Views/Chats/ChatView.xaml", typeof(ChatView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Chats.DirectMessageView.xaml", "Presentation/Views/Chats/DirectMessageView.xaml", typeof(DirectMessageView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Chats.GuildChatThreadView.xaml", "Presentation/Views/Chats/GuildChatThreadView.xaml", typeof(GuildChatThreadView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Collection.FullCollectionNew.xaml", "Presentation/Views/Collection/FullCollectionNew.xaml", typeof(FullCollectionNew))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Guilds.GuildDefenderManagementPage.xaml", "Presentation/Views/Guilds/GuildDefenderManagementPage.xaml", typeof(GuildDefenderManagementPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Guilds.GuildHubNewPage.xaml", "Presentation/Views/Guilds/GuildHubNewPage.xaml", typeof(GuildHubNewPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Guilds.GuildMembersPage.xaml", "Presentation/Views/Guilds/GuildMembersPage.xaml", typeof(GuildMembersPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Guilds.GuildShopPage.xaml", "Presentation/Views/Guilds/GuildShopPage.xaml", typeof(GuildShopPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Guilds.GuildWarBattleListPage.xaml", "Presentation/Views/Guilds/GuildWarBattleListPage.xaml", typeof(GuildWarBattleListPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Guilds.GuildWarHistoryPage.xaml", "Presentation/Views/Guilds/GuildWarHistoryPage.xaml", typeof(GuildWarHistoryPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Guilds.GuildWarsNewPage.xaml", "Presentation/Views/Guilds/GuildWarsNewPage.xaml", typeof(GuildWarsPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Main.MainPage.xaml", "Presentation/Views/Main/MainPage.xaml", typeof(MainPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.MasterPage.xaml", "Presentation/Views/MasterPage.xaml", typeof(MasterPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Onboarding.OnboardingDialoguePage.xaml", "Presentation/Views/Onboarding/OnboardingDialoguePage.xaml", typeof(OnboardingDialoguePage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Onboarding.OnboardingSpiritsRewardPage.xaml", "Presentation/Views/Onboarding/OnboardingSpiritsRewardPage.xaml", typeof(OnboardingSpiritsRewardPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.BattlePopups.BattleDebugLogPopup.xaml", "Presentation/Views/Popups/BattlePopups/BattleDebugLogPopup.xaml", typeof(BattleDebugLogPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.BattlePopups.BattleSummaryPopup.xaml", "Presentation/Views/Popups/BattlePopups/BattleSummaryPopup.xaml", typeof(BattleSummaryPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.CollectionPopups.FilterCollectionPopup.xaml", "Presentation/Views/Popups/CollectionPopups/FilterCollectionPopup.xaml", typeof(FilterCollectionPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.DailyGiftPopup.xaml", "Presentation/Views/Popups/DailyGiftPopup.xaml", typeof(DailyGiftPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.GameNewsPopup.xaml", "Presentation/Views/Popups/GameNewsPopup.xaml", typeof(GameNewsPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.GuildPopups.CreateGuildPopup.xaml", "Presentation/Views/Popups/GuildPopups/CreateGuildPopup.xaml", typeof(CreateGuildPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.GuildPopups.GuildInvitationsPopup.xaml", "Presentation/Views/Popups/GuildPopups/GuildInvitationsPopup.xaml", typeof(GuildInvitationsPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.GuildPopups.GuildSearchFilterPopup.xaml", "Presentation/Views/Popups/GuildPopups/GuildSearchFilterPopup.xaml", typeof(GuildSearchFilterPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.GuildPopups.InvitePlayerPopup.xaml", "Presentation/Views/Popups/GuildPopups/InvitePlayerPopup.xaml", typeof(InvitePlayerPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.ItemPopups.ItemPopup.xaml", "Presentation/Views/Popups/ItemPopups/ItemPopup.xaml", typeof(ItemPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.PlayerPopups.SelectPlayerIconPopup.xaml", "Presentation/Views/Popups/PlayerPopups/SelectPlayerIconPopup.xaml", typeof(SelectPlayerIconPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.QuestPopups.QuestRewardsPopup.xaml", "Presentation/Views/Popups/QuestPopups/QuestRewardsPopup.xaml", typeof(QuestRewardsPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.QuestPopups.SpiritOrbDropPopup.xaml", "Presentation/Views/Popups/QuestPopups/SpiritOrbDropPopup.xaml", typeof(SpiritOrbDropPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.Shared.CustomAlertPopup.xaml", "Presentation/Views/Popups/Shared/CustomAlertPopup.xaml", typeof(CustomAlertPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.Shared.CustomConfirmationPopup.xaml", "Presentation/Views/Popups/Shared/CustomConfirmationPopup.xaml", typeof(CustomConfirmationPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.Shared.SearchPlayersPopup.xaml", "Presentation/Views/Popups/Shared/SearchPlayersPopup.xaml", typeof(SearchPlayersPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.Shared.StaticDataUpdatingPopup.xaml", "Presentation/Views/Popups/Shared/StaticDataUpdatingPopup.xaml", typeof(StaticDataUpdatingPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.Shared.UpdateRequiredPopup.xaml", "Presentation/Views/Popups/Shared/UpdateRequiredPopup.xaml", typeof(UpdateRequiredPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Popups.ShopPopus.InsufficientFundsPopup.xaml", "Presentation/Views/Popups/ShopPopus/InsufficientFundsPopup.xaml", typeof(InsufficientFundsPopup))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Pouch.PouchView.xaml", "Presentation/Views/Pouch/PouchView.xaml", typeof(PouchView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Quests.QuestParagraphView.xaml", "Presentation/Views/Quests/QuestParagraphView.xaml", typeof(QuestParagraphView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Quests.QuestTaskView.xaml", "Presentation/Views/Quests/QuestTaskView.xaml", typeof(QuestTaskView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Quests.QuestView.xaml", "Presentation/Views/Quests/QuestView.xaml", typeof(QuestView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Shared.ContentResources.xaml", "Presentation/Views/Shared/ContentResources.xaml", typeof(ContentResources))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Shared.NavBar.xaml", "Presentation/Views/Shared/NavBar.xaml", typeof(NavBar))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Shared.PlayerInfoBar.xaml", "Presentation/Views/Shared/PlayerInfoBar.xaml", typeof(PlayerInfoBar))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Shop.ShopHubPage.xaml", "Presentation/Views/Shop/ShopHubPage.xaml", typeof(ShopHubPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Spirits.EvolveRequirementsPage.xaml", "Presentation/Views/Spirits/EvolveRequirementsPage.xaml", typeof(EvolveRequirementsPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Spirits.EvolveView.xaml", "Presentation/Views/Spirits/EvolveView.xaml", typeof(EvolveView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Spirits.SpiritDetailsView.xaml", "Presentation/Views/Spirits/SpiritDetailsView.xaml", typeof(SpiritDetailsView))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Startup.LoadingPage.xaml", "Presentation/Views/Startup/LoadingPage.xaml", typeof(LoadingPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Startup.LoginPage.xaml", "Presentation/Views/Startup/LoginPage.xaml", typeof(LoginPage))]
[assembly: XamlResourceId("SpiritSummoner.Presentation.Views.Startup.WelcomePage.xaml", "Presentation/Views/Startup/WelcomePage.xaml", typeof(WelcomePage))]
[assembly: XamlResourceId("SpiritSummoner.Resources.Styles.Colors.xaml", "Resources/Styles/Colors.xaml", typeof(__Type9C7CDFCDC4F05145))]
[assembly: XamlResourceId("SpiritSummoner.Resources.Styles.Styles.xaml", "Resources/Styles/Styles.xaml", typeof(__TypeABC57535D26EE5DB))]
[assembly: AssemblyVersion("1.0.0.0")]
[module: RefSafetyRules(11)]
