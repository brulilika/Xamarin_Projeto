using Projeto.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimalPage : ContentPage
    {
        private AnimalViewModel _animalViewModel;
        private INavigation _navigation;
        public AnimalPage(INavigation navigation, int id)
        {
            InitializeComponent();
            _navigation = navigation;
            _animalViewModel = new AnimalViewModel(this.Navigation, id);
            BindingContext = _animalViewModel;
        }


    }
}