using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YG.View;

namespace NavigationTesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstView : ContentPage, IView
    {
        public FirstView()
        {
            InitializeComponent();
        }
    }
}