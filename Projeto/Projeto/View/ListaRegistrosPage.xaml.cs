using Projeto.ViewModel;
using Projeto.View.Popup;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Projeto.Model;
using Acr.UserDialogs;
using Xamarin.Forms.Xaml;

namespace Projeto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaRegistrosPage : ContentPage
    {
        private ListaRegistrosViewModel _listaRegistrosViewModel;
        private int _id;
        public ListaRegistrosPage(INavigation navigation, int id)
        {
            InitializeComponent();
            _id = id;
            _listaRegistrosViewModel = new ListaRegistrosViewModel(navigation, id);
            BindingContext = _listaRegistrosViewModel;
        }

        private async void SelectedRegistro(object sender, SelectedItemChangedEventArgs e)
        {
            var uwu = e.SelectedItem as Registros;
            if (uwu == null)
                return;

            (sender as ListView).SelectedItem = null;

            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await PopupNavigation.Instance.PushAsync(new DetalheRegistroAnimalPopupPage(uwu, _listaRegistrosViewModel));
            }
            catch
            {

            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        protected override void OnAppearing()
        {
            _listaRegistrosViewModel.BuscaRegistros(_id);
        }
    }
}