using Projeto.Model;
using Projeto.ViewModel;
using Projeto.ViewModel.Popup;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace Projeto.View.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesRegistroPopupPage : PopupPage
    {

        private DetalheRegistoPopupViewModel _detalheRegistoPopupViewModel;
        public DetalhesRegistroPopupPage(Registros registro, AnimalTabbedPageViewModel animalTabbedPageViewModel)
        {
            InitializeComponent();
            _detalheRegistoPopupViewModel = new DetalheRegistoPopupViewModel(registro, animalTabbedPageViewModel);
            BindingContext = _detalheRegistoPopupViewModel;
        }


    }
}