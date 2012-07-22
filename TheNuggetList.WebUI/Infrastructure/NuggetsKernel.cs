#region

using System.Configuration;
using System.Data.Common;
using Ninject;
using Ninject.Modules;
using TheNuggetList.Domain.Repositories;
using TheNuggetList.Domain.Services;
using TheNuggetList.Domain.Util;
using EventAggregator;
using TheNuggetList.Domain.Achievements;
using TheNuggetList.Domain.Achievements.Listeners;

#endregion

namespace TheNuggetList.WebUI.Infrastructure
{
    public class NuggetsKernel : StandardKernel
    {
        public NuggetsKernel(DbConnection connection) : base(new NuggetsNinjectModule(connection))
        {
        }
    }

    public class NuggetsNinjectModule : NinjectModule
    {
        private readonly DbConnection _connection;

        public NuggetsNinjectModule(DbConnection connection)
        {
            _connection = connection;
        }

        public override void Load()
        {
            Bind<TheNuggetsListDbContext>().ToSelf().InRequestScope().WithConstructorArgument("connection", _connection);

            Bind<IServiceLocator>().To<NinjectServiceLocator>();

			Bind<IEventAggregator>().To<EventAggregator.EventAggregator>().InSingletonScope();

			Bind<IAchievementListenersRegistration>().To<AchievementListenersRegistration>();

            // repos
            Bind<INuggetsRepository>().To<NuggetsRepository>();
            Bind<IContentTypesRepository>().To<ContentTypesRepository>();
            Bind<ITaggedItemsRepository>().To<TaggedItemsRepository>();
            Bind<ITagsRepository>().To<TagsRepository>();
            Bind<IMembersRepository>().To<MembersRepository>();
			Bind<ICommentsRepository>().To<CommentsRepository>();
			Bind<IAchievementsRepository>().To<AchievementsRepository>();
			Bind<IEarnedAchievementsRepository>().To<EarnedAchievementsRepository>();
            Bind<IVotesRepository>().To<VotesRepository>();

            // services
            Bind<INuggetsService>().To<NuggetsService>();
            Bind<ITagsService>().To<TagsService>();
			Bind<ICommentsService>().To<CommentsService>();
			Bind<IAchievementsService>().To<AchievementsService>();
            Bind<IVotingService>().To<VotingService>();

            // utils
            Bind<ITagsParser>().To<CsvTagsParser>();

            Bind<IMemberAuthenticationService>()
                .To<MemberAuthenticationService>()
                .WithConstructorArgument("passwordSalt", ConfigurationManager.AppSettings["passwordSalt"]);

			//Achievement Event Listeners
			Bind<IMemberRegisteredAchievementListener>().To<MemberRegisteredAchievementListener>();
        }
    }
}