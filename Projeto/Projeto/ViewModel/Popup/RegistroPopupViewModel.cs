using Projeto.Data;
using Projeto.Model;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Projeto.ViewModel.Popup
{
    class RegistroPopupViewModel : BaseViewModel
    {
        #region Propriedades
        private string _titulo;
        private string _ocorrencia;
        
        public Registros _novoRegistro;
        private Command _registroCommand;
        private AnimaisRepository _repositorio;
        private INavigation _navigation;
        #endregion

        public RegistroPopupViewModel(int animal_id, INavigation navigation)
        {
            _novoRegistro = new Registros();
            _repositorio = new AnimaisRepository();
            _navigation = navigation;
            _novoRegistro.Animal_id = animal_id;
        }

        #region Encapsulamento
        public string Titulo { get { return _titulo; } set { _titulo = value; OnPropertyChanged("Titulo"); } }
        public string Ocorrencia { get { return _ocorrencia; } set { _ocorrencia = value; OnPropertyChanged("Ocorrencia"); } }
        #endregion

        #region Commands
        public Command RegistroCommand => _registroCommand ?? (_registroCommand = new Command( async () => {
            _novoRegistro.Registro = Ocorrencia;
            _novoRegistro.Titulo = Titulo;
            _novoRegistro.Ativo = 1;
            _repositorio.InserirRegistro(_novoRegistro);
            await PopupNavigation.Instance.PopAsync();
        }));
        #endregion
    }
}
