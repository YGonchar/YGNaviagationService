using System;
using Moq;
using NUnit.Framework;
using YG.View;
using YG.ViewLocation;
using YG.ViewModel;

namespace YGNaviagationServiceTests.ViewController
{
    [TestFixture]
    class GetViewTests
    {
        private Mock<IViewLocation> _viewLocationMock;
        private Mock<IView> _mockView;

        [SetUp]
        public void Setup()
        {
            _viewLocationMock = new Mock<IViewLocation>();
            _mockView = new Mock<IView>();
        }

        //[Test]
        //public void Should_return_view_from_viewModelType()
        //{
        //    _viewLocationMock
        //        .Setup(location => location.FindView(It.Is<Type>(type => typeof(IViewModel).IsAssignableFrom(type))))
        //        .Returns(_mockView.Object).Verifiable();

        //    var controller = new YG.Controllers.ViewController(_viewLocationMock.Object);
        //    var view = controller.GetView(typeof(FakeViewModel));

        //    _viewLocationMock.Verify(location => location.FindView(It.Is<Type>(type => typeof(IViewModel).IsAssignableFrom(type))), Times.AtLeast(1));
        //    Assert.NotNull(view);

        //    _viewLocationMock.Reset();
        //}

        [TestCase(typeof(String))]
        [TestCase((Type)null)]
        public void Should_throw_ArgumentException_if_incorrect_value_is_passed(Type type)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var controller = new YG.Controllers.ViewController(_viewLocationMock.Object);
                var view = controller.GetView(type);
            });
        }
    }
}
