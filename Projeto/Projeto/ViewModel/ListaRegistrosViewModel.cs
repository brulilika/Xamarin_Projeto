using Projeto.Data;
using Projeto.Model;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Projeto.ViewModel
{
    public class ListaRegistrosViewModel : BaseViewModel
    {
        #region Propriedades
        private INavigation _navigation;
        private AnimaisRepository _repositorio;
        private List<Registros> _listaRegistros;
        #endregion
        public ListaRegistrosViewModel(INavigation navigation, int id)
        {
            _navigation = navigation;
            _repositorio = new AnimaisRepository();
        }
        #region Encapsulamento
        public List<Registros> ListaRegistros { get { return _listaRegistros; } set { _listaRegistros = value; OnPropertyChanged("ListaRegistros"); } }
        #endregion

        #region Funções
        public void BuscaRegistros(int id)
        {
            ListaRegistros = _repositorio.BuscaListaRegistros(id);
        }
        #endregion
    }
}
