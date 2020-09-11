using Projeto.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectPage : ContentPage
    {
        private DirectViewModel _directViewModel;
        
        public DirectPage()
        {
            InitializeComponent();
            _directViewModel = new DirectViewModel(this.Navigation);
            BindingContext = _directViewModel;
        }
    }
}