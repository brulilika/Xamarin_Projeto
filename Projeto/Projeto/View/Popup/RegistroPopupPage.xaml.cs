using Projeto.ViewModel.Popup;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.View.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPopupPage : PopupPage
    {
        private RegistroPopupViewModel _registroPopupViewModel;
        private INavigation _navigation;
        public RegistroPopupPage(int animal_id, INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            _registroPopupViewModel = new RegistroPopupViewModel(animal_id, _navigation);
            BindingContext = _registroPopupViewModel;
        }
    }
}