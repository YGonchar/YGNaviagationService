using System.ComponentModel;
using System.Threading.Tasks;

namespace YG.ViewModel
{
    /// <summary>
    ///  Describes base bahavior for ViewModels
    /// </summary>
    public interface IViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Indicates operation performing in background thread
        /// </summary>
        bool IsBusy { get; set; }

        /// <summary>
        /// Responds for ViewModel initialization.
        /// Put Initialization logic here, e.g. working with remote sevices.
        /// </summary>
        /// <returns></returns>
        Task InitAsync();

        /// <summary>
        ///  Is called when the view is appearing
        /// </summary>
        void OnAppearing();

        /// <summary>
        /// Is called when the view is disappearing
        /// </summary>
        void OnDisappearing();
    }
}
