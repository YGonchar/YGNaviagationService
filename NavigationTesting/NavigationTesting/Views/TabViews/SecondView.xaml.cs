using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YG.View;

namespace NavigationTesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondView : ContentPage, IView
    {
        public SecondView()
        {
            InitializeComponent();
        }
    }
}