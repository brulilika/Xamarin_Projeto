using Projeto.ViewModel;
using Xamarin.Forms;

namespace Projeto
{
    public partial class MainPage : ContentPage
    {
        private  MainViewModel _mainViewModel;
        public MainPage()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
            BindingContext = _mainViewModel;
        }
    }
}
