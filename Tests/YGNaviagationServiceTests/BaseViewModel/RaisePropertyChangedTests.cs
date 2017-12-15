using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace YGNaviagationServiceTests.BaseViewModel
{
    [TestFixture]
    public class RaisePropertyChangedTests
    {
        [Test]
        public void Should_Notify_When_Correct_Property_Expression_Is_Passed()
        {
            var mock = new Mock<FakeViewModel>();
            mock.Protected().Setup("RaisePropertyChanged", ItExpr.IsNull<string>()).Verifiable();

            mock.Object.State = "NewState";

            mock.Protected().Verify("RaisePropertyChanged", Times.Exactly(1), ItExpr.Is<string>(s => string.Equals(nameof(mock.Object.State), s)));
        }
    }
}
