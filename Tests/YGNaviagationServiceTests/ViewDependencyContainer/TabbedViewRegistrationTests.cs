using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using Xamarin.Forms;
using YG.Registration;

namespace YGNaviagationServiceTests.ViewDependencyContainer
{
    [TestFixture]
    class TabbedViewRegistrationTests
    {
        private YG.Registration.ViewDependencyContainer _dependencyContainerMock;

        [SetUp]
        public void Setup()
        {
            _dependencyContainerMock = new YG.Registration.ViewDependencyContainer();
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Should_add_types_throught_generic_params(int numOfArgs)
        {
            switch (@numOfArgs)
            {
                case 2:
                    _dependencyContainerMock.RegisterTabbedView<TabbedPage, FakeView, FakeView>();
                    break;
                case 3:
                    _dependencyContainerMock.RegisterTabbedView<TabbedPage, FakeView, FakeView, FakeView>();
                    break;
                case 4:
                    _dependencyContainerMock.RegisterTabbedView<TabbedPage, FakeView, FakeView, FakeView, FakeView>();
                    break;
                case 5:
                    _dependencyContainerMock.RegisterTabbedView<TabbedPage, FakeView, FakeView, FakeView, FakeView, FakeView>();
                    break;
            }

            Assert.AreEqual(numOfArgs + 1, _dependencyContainerMock.Items.Count);
        }

        [Test]
        public void Should_add_conatainer_into_Items_collection()
        {
            IViewDependencyContainer container = new YG.Registration.ViewDependencyContainer();

            container = container.RegisterTabbedView<TabbedPage, FakeView, FakeView>();

            Assert.Greater(container.Items.Count, 0);
            Assert.NotNull(container.Items.First().Children);
        }
    }
}
