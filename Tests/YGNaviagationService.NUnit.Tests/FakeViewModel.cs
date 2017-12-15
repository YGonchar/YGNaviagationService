namespace YGNaviagationServiceTests
{
    public class FakeViewModel : YG.ViewModel.BaseViewModel
    {
        private object _state;
        private object _state2;

        public object State
        {
            get => _state;
            set
            {
                _state = value;
                RaisePropertyChanged(() => State);
            }
        }
    }
}