using Acr.UserDialogs;
using Projeto.Data;
using Projeto.Model;
using Projeto.View;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Projeto.ViewModel
{
    public class AnimalTabbedPageViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private AnimaisRepository _repositorio;
        private List<Animais> _listaAnimais;
        private List<Registros> _listaRegistros;
        private List<Imagens> _listaImagens;
        private ImageSource _imagem;
        private Command _cadastroCmd;
        private Command _detalheAnimalCmd;
        private int _posicionamento;
        #endregion
        public AnimalTabbedPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _posicionamento = 1;
            _repositorio = new AnimaisRepository();
        }

        #region Encapsulamento
        public List<Animais> ListaAnimais { get { return _listaAnimais; } set { _listaAnimais = value; OnPropertyChanged("ListaAnimais"); } }
        public List<Registros> ListaRegistros { get { return _listaRegistros; } set { _listaRegistros = value; OnPropertyChanged("ListaRegistros"); } }
        public List<Imagens> ListaImagens { get { return _listaImagens; } set { _listaImagens = value; OnPropertyChanged("ListaImagens"); } }
        public ImageSource Imagem { get { return _imagem; } set { _imagem = value; OnPropertyChanged("Imagem"); } }
        public int Posicionamento { get { return _posicionamento; } set { _posicionamento = value; OnPropertyChanged("Posicionamento"); } }
        #endregion

        #region Commands
        public Command CadsCommand => _cadastroCmd ?? (_cadastroCmd = new Command(async () =>
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await _navigation.PushAsync(new CadsPage());
            }
            catch
            {
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }));

        public Command DetalheAnimalCmd => _detalheAnimalCmd ?? (_detalheAnimalCmd = new Command(async () =>
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await App.Current.MainPage.DisplayAlert("ALERT", Posicionamento.ToString(), "OK");
                //await PopupNavigation.Instance.PushAsync(new DetalheAnimalPopupPage(Posicionamento));
            }
            catch
            {
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }));
        
        #endregion

        #region Funções
        public void BuscaLAnimais()
        {
            ListaAnimais = _repositorio.BuscaListaAnimais();
        }

        public void BuscaTRegistros()
        {
            ListaRegistros = _repositorio.BuscaTodosRegistros();
        }

        public void BuscaLImagens()
        {
            ListaImagens = _repositorio.BuscaListaImagens();
        }
        public ImageSource GetImage(string path)
        {
            return ImageSource.FromFile(path);
        }
        #endregion
    }
}
