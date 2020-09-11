using Projeto.Data;
using Projeto.Model;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Projeto.ViewModel.Popup
{
    public class DetalheAnimalPopupPageViewModel : BaseViewModel
    {
        #region Propriedades
        private Animais Escolhido;
        private AnimaisRepository _repositorio;

        private string _nome;
        private string _cidade;
        private string _especie;

        private Command _fecharCmd;
        #endregion
        public DetalheAnimalPopupPageViewModel(int id)
        {
            _repositorio = new AnimaisRepository();
            Inicializa(id);
        }

        #region Encapsulamento
        public string Nome { get { return _nome; } set { _nome = value; OnPropertyChanged("Nome"); } }
        public string Cidade { get { return _cidade; } set { _cidade = value; OnPropertyChanged("Cidade"); } }
        public string Especie { get { return _especie; } set { _especie = value; OnPropertyChanged("Especie"); } }
        #endregion

        #region Command
        public Command FecharCommand => _fecharCmd ?? (_fecharCmd = new Command(async () => {
            await PopupNavigation.Instance.PopAsync();
        }));

        #endregion
        
        #region Funções
        private void Inicializa(int id)
        {
            Escolhido = _repositorio.BuscaAnimal(id);
            Nome = Escolhido.Nome;
            Cidade = Escolhido.Cidade;
            Especie = Escolhido.Especie;
        }
        #endregion
    }
}
