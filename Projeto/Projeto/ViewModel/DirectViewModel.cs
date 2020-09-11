using Acr.UserDialogs;
using Projeto.View;
using System;
using Xamarin.Forms;

namespace Projeto.ViewModel
{
    public class DirectViewModel: BaseViewModel

    {
        #region Propriedades
        private INavigation _navigation;
        private Command _calCommand; //direciona para a calculadora
        private Command _sistCommand; //direciona para o sisteminha
        #endregion
        public DirectViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        #region Commands
        public Command CalcCommand => _calCommand ?? (_calCommand = new Command( async() =>
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await _navigation.PushAsync(new MainPage());
            }
            catch
            {

            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }

            
        }));
        public Command SistCommand => _sistCommand ?? (_sistCommand = new Command(async () =>
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await _navigation.PushAsync(new AnimalTabbedPage(this._navigation));
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("alerta", e.Message, "OK");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }));
        #endregion
    }
}
