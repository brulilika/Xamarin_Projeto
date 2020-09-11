using Acr.UserDialogs;
using Projeto.Model;
using Projeto.View.Popup;
using Projeto.ViewModel;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimalTabbedPage : TabbedPage
    {
        private AnimalTabbedPageViewModel _animalTabbedViewModel;
        INavigation _navigation;
        public AnimalTabbedPage(INavigation navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            _animalTabbedViewModel = new AnimalTabbedPageViewModel(this.Navigation);
            BindingContext = _animalTabbedViewModel;
        }

        protected override void OnAppearing()
        {
            _animalTabbedViewModel.BuscaLAnimais();
            _animalTabbedViewModel.BuscaTRegistros();
            _animalTabbedViewModel.BuscaLImagens();
        }

        #region FUNÇÕES SELECIONAR REGISTRO, ANIMAL E IMAGEM
        private async void SelectedRegistro(object sender, SelectedItemChangedEventArgs e)
        {
            var uwu = e.SelectedItem as Registros;
            if (uwu == null)
                return;

            (sender as ListView).SelectedItem = null;

            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await PopupNavigation.Instance.PushAsync(new DetalhesRegistroPopupPage(uwu,_animalTabbedViewModel));
            }
            catch
            {

            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void SelectedAnimal(object sender, SelectedItemChangedEventArgs e)
        {
            var uwu = e.SelectedItem as Animais;
            if (uwu == null)
                return;

            (sender as ListView).SelectedItem = null;

            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await _navigation.PushAsync(new AnimalPage(this._navigation, uwu.id));
            }
            catch
            {

            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await PopupNavigation.Instance.PushAsync(new DetalheAnimalPopupPage(_animalTabbedViewModel.ListaImagens[_animalTabbedViewModel.Posicionamento].Animal_id));
            }
            catch
            {
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
        #endregion
    }
}