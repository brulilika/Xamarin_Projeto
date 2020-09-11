using Projeto.Data;
using Projeto.Model;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Projeto.ViewModel.Popup
{
    class DetalheRegistoPopupViewModel : BaseViewModel
    {
        #region Propriedades
        private string _titulo;
        private string _ocorrencia;
        private string _nomeAnimal;

        private Registros _escolhido;
        private AnimaisRepository _repositorio;
        private AnimalTabbedPageViewModel _animalTabbedPageViewModel;

        private Command _fecharCommand;
        private Command _deletarCommand;
        #endregion

        public DetalheRegistoPopupViewModel(Registros registro, AnimalTabbedPageViewModel animalTabbedPageViewModel)
        {
            _escolhido = registro;
            _repositorio = new AnimaisRepository();
            _animalTabbedPageViewModel = animalTabbedPageViewModel;
            _escolhido.id = registro.id;
            BuscaURegistro(registro.id);
        }

        #region Encapsulamento
        public string Titulo { get { return _titulo; } set { _titulo = value; OnPropertyChanged("Titulo"); } }
        public string Ocorrencia { get { return _ocorrencia; } set { _ocorrencia = value; OnPropertyChanged("Ocorrencia"); } }
        public string NomeAnimal { get { return _nomeAnimal; } set { _nomeAnimal = value; OnPropertyChanged("Titulo"); } }
        #endregion

        #region Commands
        public Command FecharCommand => _fecharCommand ?? (_fecharCommand = new Command(async () => {
            await PopupNavigation.Instance.PopAsync();
        }));

        public Command DeletarCommand => _deletarCommand ?? (_deletarCommand = new Command( async () => {

            if(await App.Current.MainPage.DisplayAlert("REMOÇÃO", "Deseja mesmo remover o registro?","ACCEPT","REMOVE"))
            {
                _repositorio.DeletaLogicaRegistro(_escolhido.id);
                await App.Current.MainPage.DisplayAlert("REMOÇÃO", "Registro REMOVIDO com sucesso!", "OK");
                await PopupNavigation.Instance.PopAsync();
                _animalTabbedPageViewModel.BuscaTRegistros();
            }
        }));
        #endregion

        #region Funções
        void BuscaURegistro(int id)
        {
            Titulo  = _repositorio.BuscaRegistros(id).Titulo ;
            Ocorrencia = _repositorio.BuscaRegistros(id).Registro;
            NomeAnimal = _repositorio.BuscaNomeAnimal(id).Nome;
        }
        #endregion
    }
}
