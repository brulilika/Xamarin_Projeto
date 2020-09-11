using Projeto.Model;
using Projeto.ViewModel;
using Projeto.ViewModel.Popup;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace Projeto.View.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheRegistroAnimalPopupPage : PopupPage
    {
        private DetalheRegistoAnimalPopupViewModel _detalheRegistoAnimalPopupViewModel;
        public DetalheRegistroAnimalPopupPage(Registros registro, ListaRegistrosViewModel listaRegistrosPageViewModel)
        {
            InitializeComponent();
            _detalheRegistoAnimalPopupViewModel = new DetalheRegistoAnimalPopupViewModel(registro, listaRegistrosPageViewModel);
            BindingContext = _detalheRegistoAnimalPopupViewModel;
        }
    }
}