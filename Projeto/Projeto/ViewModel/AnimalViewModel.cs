using Acr.UserDialogs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Projeto.Data;
using Projeto.Model;
using Projeto.View;
using Projeto.View.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Projeto.ViewModel
{
    class AnimalViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private AnimaisRepository _repositorio;

        private List<string> _listaCidades;
        private string _nomeEspecie;
        private string _idadeEspecie;
        private string _edicao;
        private bool _visibilidadeEditar;
        private bool _visibilidadeBotao;
        private int _cidadeindex;

        private Animais _escolhido;
        private Imagens novaImagem;
        private ImageSource _imagemAnimal;

        private Command _deleteCommand;
        private Command _novoRegistroCommand;
        private Command _novaFotoCommand;
        private Command _abrirRegistroCommand;
        private Command _editarCommand;
        #endregion
        public AnimalViewModel(INavigation navigation, int id)
        {
            _navigation = navigation;
            _repositorio = new AnimaisRepository();
            _edicao = "Editar";
            BuscaUAnimal(id);
            InicializeComponents();
            PreencherLista();
            ItemLista(id);
        }

        #region Encapsulamento
        public Animais Escolhido { get { return _escolhido; } set { _escolhido = value; OnPropertyChanged("Escolhido"); } }
        //public Imagens NovaImagem { get { return _novaImagem; } set { _novaImagem = value; OnPropertyChanged("NovaImagem"); } }
        public ImageSource ImagemAnimal { get { return _imagemAnimal; } set { _imagemAnimal = value; OnPropertyChanged("ImagemAnimal"); } }

        public bool VisibilidadeEditar { get { return _visibilidadeEditar; } set { _visibilidadeEditar = value; OnPropertyChanged("VisibilidadeEditar"); } }
        public bool VisibilidadeBotao { get { return _visibilidadeBotao; } set { _visibilidadeBotao = value; OnPropertyChanged("VisibilidadeBotao"); } }
        public string Edicao { get { return _edicao; } set { _edicao = value; OnPropertyChanged("Edicao"); } }
        public string NomeEspecie { get { return _nomeEspecie; } set { _nomeEspecie = value; OnPropertyChanged("NomeEspecie"); } }
        public string IdadeEspecie { get { return _idadeEspecie; } set { _idadeEspecie = value; OnPropertyChanged("IdadeEspecie"); } }
        public int IndexCidadeSelecionada { get { return _cidadeindex; } set { _cidadeindex = value; OnPropertyChanged("IndexCidadeSelecionada"); } }

        public List<string> ListaCidades { get { return _listaCidades; } set { _listaCidades = value; OnPropertyChanged("ListaCidades"); } }
        #endregion

        #region Commands
        public Command AbrirRegistroCommand => _abrirRegistroCommand ?? (_abrirRegistroCommand = new Command(async () => {

            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await _navigation.PushAsync(new ListaRegistrosPage(this._navigation, Escolhido.id));
            }
            catch
            {

            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }


        }));

        public Command DeleteCommand => _deleteCommand ?? (_deleteCommand = new Command(async () => {
            if (await App.Current.MainPage.DisplayAlert("REMOÇÃO", "Deseja mesmo remover o animal?", "ACCEPT", "REMOVE"))
            {
                _repositorio.DeletaLogicaAnimal(Escolhido.id);
                _repositorio.DeletaLogicaAnimalRegistro(Escolhido.id);
                await Application.Current.MainPage.DisplayAlert("REMOÇÃO", "O novo animal foi REMOVIDO com sucesso!", "OK");
                await _navigation.PopAsync();
            }
        }));

        public Command NovaFotoCommand => _novaFotoCommand ?? (_novaFotoCommand = new Command(async () => {
            
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
            {
                await App.Current.MainPage.DisplayAlert("Erro!", "Problema ao conectar com a camera!","OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true
                    });
            if (file == null) return;

            _repositorio.AtualizaFotoAnimal(file.Path, Escolhido.id);
            novaImagem.Animal_id = Escolhido.id;
            novaImagem.Path = file.Path;
            novaImagem.Ativo = 1;
            _repositorio.InserirImagem(novaImagem);

            ImagemAnimal = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }));
        public Command NovoRegistroCommand => _novoRegistroCommand ?? (_novoRegistroCommand = new Command(async () => {

            try
            {
                UserDialogs.Instance.ShowLoading("Carregando página");
                await PopupNavigation.Instance.PushAsync(new RegistroPopupPage(Escolhido.id, this._navigation));
            }
            catch
            {

            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
            

        }));

        public Command EditarCommand => _editarCommand ?? (_editarCommand = new Command(() => {
            if (Edicao == "Editar")
            {
                VisibilidadeEditar = true;
                VisibilidadeBotao = false;
                Edicao = "Confirmar";
            }
            else
            {
                VisibilidadeEditar = false;
                VisibilidadeBotao = true;
                Edicao = "Editar";
                Escolhido.Cidade = ListaCidades[IndexCidadeSelecionada];
                _repositorio.AtualizaNomeCidade(Escolhido.Nome, Escolhido.Cidade, Escolhido.id);
            }
            
        }));
        #endregion

        #region Funções
        public void BuscaUAnimal(int id)
        {
            Escolhido = _repositorio.BuscaAnimal(id);
        }

        public void InicializeComponents()
        {
            _listaCidades = new List<string>();
            VisibilidadeBotao = false;
            novaImagem = new Imagens();
            if (Escolhido.Path != null)
            {
                ImagemAnimal = GetImage(Escolhido.Path);
            }
            else
            {
                switch (Escolhido.Especie)
                {
                    case "Cachorro": //cao
                        _imagemAnimal = "cao.png";
                        break;
                    case "Gato": //gato
                        _imagemAnimal = "gato.png";
                        break;
                    case "Coelho": //coelho
                        _imagemAnimal = "coelho.png";
                        break;
                    case "Hamster": //hamster
                        _imagemAnimal = "hamster.png";
                        break;
                    case "Peixe": //peixe
                        _imagemAnimal = "peixe.png";
                        break;
                    case "Polvo": //polvo
                        _imagemAnimal = "polvo.png";
                        break;
                    case "Serpente": //serpente
                        _imagemAnimal = "serpente.png";
                        break;
                    case "Tartaruga": //tartaruga
                        _imagemAnimal = "tartaruga.png";
                        break;
                    default: //animal_icon
                        _imagemAnimal = "animal_icon.png";
                        break;
                }
            }
            
            VerificaIdade();
        }

        public void VerificaIdade()
        {
            System.TimeSpan days = DateTime.Now.Subtract(Escolhido.Data_Nasc);

            IdadeEspecie = Converter(days.Days);
        }

        public void ItemLista(int id)
        {
            for(var i = 0; i< 27; i++)
            {
                if(Escolhido.Cidade == ListaCidades[i])
                {
                    IndexCidadeSelecionada = i;
                }
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
        public string Converter(int dias)
        {
            string retorno;
            int mes,ano;

            if (dias > 30) //animal possui alguns meses de vida
            {
                mes = dias / 30;

                if (mes > 12) // animal possui alguns anos de vida
                {
                    ano = mes / 12;
                    retorno = ano + " anos";
                }
                else //animal nao possui mais do que 1 ano de vida
                {
                    retorno = mes + " meses";
                }
            }
            else //aninmal nao tem mais do que 1 mes
            {
                retorno = dias + " dias";
            }
            return retorno;
        }

        public ImageSource GetImage(string path)
        {
            return ImageSource.FromFile(path);
        }
        #endregion
    }
}
