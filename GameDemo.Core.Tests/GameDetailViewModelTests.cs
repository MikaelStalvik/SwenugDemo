using GameDemo.Core.Classes;
using GameDemo.Core.Interfaces;
using GameDemo.Core.Models;
using GameDemo.Core.Services;
using GameDemo.Core.ViewModels;
using NSubstitute;
using NUnit.Framework;
using TinyIoC;
using XLabs.Ioc;
using XLabs.Ioc.TinyIOC;

namespace GameDemo.Core.Tests
{

    [TestFixture]
    public class GameDetailViewModelTests
    {
        private IGameDetailViewModel _subject;
        private IGamePayload _payload;

        [SetUp]
        public void Setup()
        {
            var container = new TinyIoCContainer();
            Resolver.ResetResolver(new TinyResolver(container));

            container.Register<IGamePayload, GamePayload>();
            _payload = container.Resolve<IGamePayload>();

            container.Register<IDataService, DataService>();

            container.Register<IGameDetailViewModel, GameDetailViewModel>();
            _subject = container.Resolve<IGameDetailViewModel>();
        }

        [Test]
        public void EnsureThatPayloadIsFetched()
        {
            _payload.PayloadObject = new Game
            {
                Id = 123,
                Name = "Super Frog",
                Platform = "Amiga",
                Publisher = "Team 17",
                ReleaseYear = 1993
            };

            _subject.Load();

            Assert.IsTrue(_subject.SelectedGame.Id == 123);
            Assert.IsTrue(_subject.SelectedGame.Name.Equals("Super Frog"));
        }

    }
}
