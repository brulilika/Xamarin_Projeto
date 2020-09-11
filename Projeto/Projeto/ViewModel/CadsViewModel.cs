using Projeto.Data;
using Projeto.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Projeto.ViewModel
{
    public class CadsViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private DateTime _nascDate;
        private DateTime _limiteDate;
        private List<string> _listaCidades;

        private int _animalindex;
        private int _cidadeindex;
        private string _cidade;
        private string _acao;
        private string _nome;

        private AnimaisRepository _repositorio;
        private Animais novoAnimal;

        private Command _acaoCommand;
        private Command _cancelarCommand;
        #endregion
        public CadsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            CarregarDados();
            PreencherLista();

        }
        #region Encapsulamento
        public int AnimalSelecionado { get { return _animalindex; } set { _animalindex = value; OnPropertyChanged("AnimalSelecionado"); } }
        public int IndexCidadeSelecionada { get { return _cidadeindex; } set { _cidadeindex = value; OnPropertyChanged("IndexCidadeSelecionada"); } }
        public DateTime DataNascimento { get { return _nascDate; } set { _nascDate = value; OnPropertyChanged("DataNascimento"); } }
        public DateTime DataLimite { get { return _limiteDate; } set { _limiteDate = value; OnPropertyChanged("DataLimite"); } }
        public string Acao { get { return _acao; } set { _acao = value; OnPropertyChanged("Acao"); } }
        public string Nome { get { return _nome; } set { _nome = value; OnPropertyChanged("Nome"); } }
        public string Cidade { get { return _cidade; } set { _cidade = value; OnPropertyChanged("Cidade"); } }
        public List<string> ListaCidades { get { return _listaCidades; } set { _listaCidades = value; OnPropertyChanged("ListaCidades"); } }
        #endregion

        #region Commands
        public Command AcaoCommand => _acaoCommand ?? (_acaoCommand = new Command(async () =>
        {

            novoAnimal.Nome = Nome;
            novoAnimal.Data_Nasc = DataNascimento;
            novoAnimal.Especie = ConverterEspecie(AnimalSelecionado);
            novoAnimal.Cidade = ListaCidades[IndexCidadeSelecionada];
            novoAnimal.Path = null;
            novoAnimal.Ativo = 1;
            _repositorio.InserirAnimal(novoAnimal);
            await Application.Current.MainPage.DisplayAlert("CADASTRO!", "O novo animal foi CADASTRADO com sucesso!", "OK");
            await _navigation.PopAsync();
        }));

        public Command CancelarCommand => _cancelarCommand ?? (_cancelarCommand = new Command(async () =>
        {
            await _navigation.PopAsync();
        }));
        #endregion

        #region Funções
        public void CarregarDados()
        {
            _animalindex = -1;
            _cidadeindex = 0;
            _nascDate = DateTime.Now;
            _limiteDate = DateTime.Now;
            _repositorio = new AnimaisRepository();
            novoAnimal = new Animais();
            _listaCidades = new List<string>();
        }

        private string ConverterEspecie(int id)
        {
            switch (id)
            {
                case 0: //cachorro
                    return "Cachorro";
                case 1: //gato
                    return "Gato";
                case 2: //coelho
                    return "Coelho";
                case 3: //hamster
                    return "Hamster";
                case 4: //peixe
                    return "Peixe";
                case 5: //polvo
                    return "Polvo";
                case 6: //serpente
                    return "Serpente";
                case 7: //tartaruga
                    return "Tartaruga";
                default:
                    return "Nao registrado";
            }
        }
        public void PreencherLista()
        {
            ListaCidades.Add("Acre");
            ListaCidades.Add("Alagoas");
            ListaCidades.Add("Amapá");
            ListaCidades.Add("Amazonas");
            ListaCidades.Add("Bahia");
            ListaCidades.Add("Ceará");
            ListaCidades.Add("Distrito Federal");
            ListaCidades.Add("Espírito Santo");
            ListaCidades.Add("Goiás");
            ListaCidades.Add("Maranhão");
            ListaCidades.Add("Mato Grosso");
            ListaCidades.Add("Mato Grosso do Sul");
            ListaCidades.Add("Minas Gerais");
            ListaCidades.Add("Pará");
            ListaCidades.Add("Paraíba");
            ListaCidades.Add("Paraná");
            ListaCidades.Add("Pernambuco");
            ListaCidades.Add("Piauí");
            ListaCidades.Add("Rio de Janeiro");
            ListaCidades.Add("Rio Grande do Norte");
            ListaCidades.Add("Rio Grande do Sul");
            ListaCidades.Add("Rondônia");
            ListaCidades.Add("Roraima");
            ListaCidades.Add("Santa Catarina");
            ListaCidades.Add("São Paulo");
            ListaCidades.Add("Sergipe");
            ListaCidades.Add("Tocantins");
        }

        #endregion
    }
}
