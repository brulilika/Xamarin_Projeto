using Projeto.Model;
using System.Collections.Generic;

namespace Projeto.Interface
{
    interface IAnimaisRepository
    {
        List<Animais> BuscaListaAnimais();
        Animais BuscaAnimal(int id);
        void InserirAnimal(Animais novo);
        List<Registros> BuscaListaRegistros(int id);
        void InserirRegistro(Registros novoRegistro);
        void AtualizaFotoAnimal(string path, int id);
        List<Imagens> BuscaListaImagens();
    }
}
