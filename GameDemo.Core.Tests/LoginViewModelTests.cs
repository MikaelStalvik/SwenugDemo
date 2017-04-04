using GameDemo.Core.Interfaces;
using GameDemo.Core.Services;
using GameDemo.Core.ViewModels;
using NSubstitute;
using NUnit.Framework;
using TinyIoC;
using XLabs.Ioc.TinyIOC;
using XLabs.Ioc;

namespace GameDemo.Core.Tests
{
    [TestFixture]
    public class LoginViewModelTests
    {
        private ILoginViewModel _subject;
        private IGameApp _app;

        [SetUp]
        public void SetupTests()
        {
            var container = new TinyIoCContainer();
            Resolver.ResetResolver(new TinyResolver(container));

            _app = Substitute.For<IGameApp>();
            container.Register(_app);

            container.Register<IDataService, DataService>();

            container.Register<ILoginViewModel, LoginViewModel>();
            _subject = container.Resolve<ILoginViewModel>();
        }

        [Test]
        public void WhenIncorrectCredentialsAreSetErrorMessageShallBseTrue()
        {
            _subject.Username = string.Empty;
            _subject.Password = string.Empty;
            Assert.IsFalse(_subject.LoginCommand.CanExecute(null));
        }

        [Test]
        public void WhenIncorrectCredentialsAreSetErrorMessageShallBeTrue()
        {
            _subject.Username = "Kalle";
            _subject.Password = "12345";
            _subject.LoginCommand.Execute(null);
            Assert.IsFalse(string.IsNullOrEmpty(_subject.ErrorMessage));
        }

        [Test]
        public void WhenCorrectCredentialsPageShallOpen()
        {
            _subject.Username = "demo";
            _subject.Password = "12345";
            _subject.LoginCommand.Execute(null);
            _app.Received(1).OpenPage(typeof(IMainViewModel));
        }

    }
}
