using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace YGNaviagationServiceTests.BaseViewModel
{
    [TestFixture]
    class SetPropertyAndRiseTests
    {
        [Test]
        public void Should_return_True_if_value_is_changes()
        {
            var mock = new Mock<YG.ViewModel.BaseViewModel>();
            mock.Protected().Setup("RaisePropertyChanged", ItExpr.IsNull<string>()).Verifiable();

            object value = "Idle";
            var result = mock.Object.SetPropertyAndRise(ref value, "NewState", null);

            mock.Protected().Verify("RaisePropertyChanged", Times.Exactly(1), ItExpr.IsNull<string>());
            Assert.IsTrue(result);
        }
    }
}
