using Projeto.ViewModel.Popup;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace Projeto.View.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheAnimalPopupPage : PopupPage
    {
        private DetalheAnimalPopupPageViewModel _detalheAnimalPopupViewModel;
        public DetalheAnimalPopupPage(int id)
        {
            InitializeComponent();
            _detalheAnimalPopupViewModel = new DetalheAnimalPopupPageViewModel(id);
            BindingContext = _detalheAnimalPopupViewModel;
        }
    }
}