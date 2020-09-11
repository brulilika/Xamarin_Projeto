using Projeto.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadsPage : ContentPage
    {
        private CadsViewModel _cadsViewModel;
        public CadsPage()
        {
            InitializeComponent();
            _cadsViewModel = new CadsViewModel(this.Navigation);
            BindingContext = _cadsViewModel;
        }
    }
}