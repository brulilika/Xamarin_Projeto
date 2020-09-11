using Projeto.Context;
using Projeto.Interface;
using Projeto.Model;
using System.Collections.Generic;

namespace Projeto.Data
{
    public class AnimaisRepository : IAnimaisRepository
    {
        public ProjetoContext DbContext { get; set; }
        public AnimaisRepository()
        {
            DbContext = ProjetoContext.Current;
        }

        #region TABELA ANIMAIS

        public Animais BuscaAnimal(int id)
        {
            return DbContext.Conexao.FindWithQuery<Animais>("SELECT * " +
                                                            "FROM ANIMAIS " +
                                                            "WHERE (id = ? AND ATIVO = 1)", id);
        }

        public List<Animais> BuscaListaAnimais()
        {
            return DbContext.Conexao.Query<Animais>("SELECT * " +
                                                    "FROM ANIMAIS " +
                                                    "WHERE ATIVO = 1");
        }

        public void InserirAnimal(Animais novoAnimal)
        {
            DbContext.Conexao.Insert(novoAnimal);
        }

        public void DeletaLogicaAnimal(int id)
        {
            DbContext.Conexao.Query<Animais>("UPDATE ANIMAIS " +
                                                "SET ATIVO = 0 " +
                                                "WHERE id = ?", id);
        }

        public void AtualizaNomeCidade(string nome, string cidade, int id)
        {
            DbContext.Conexao.Query<Animais>("UPDATE ANIMAIS " +
                                                "SET NOME = ?,CIDADE = ? " +
                                                "WHERE id = ?", nome, cidade, id); 
        }

        public void AtualizaFotoAnimal(string path, int id)
        {
            DbContext.Conexao.Query<Animais>("UPDATE ANIMAIS " +
                                                "SET PATH = ? " +
                                                "WHERE id = ?", path, id); 
        }
        #endregion

        #region TABELA REGISTROS
        public List<Registros> BuscaListaRegistros(int id)
        {
            return DbContext.Conexao.Query<Registros>("SELECT * " +
                                                        "FROM REGISTROS " +
                                                        "WHERE Animal_id = ? AND Ativo = 1", id);
        }

        public List<Registros> BuscaTodosRegistros()
        {
            return DbContext.Conexao.Query<Registros>("SELECT * " +
                                                        "FROM REGISTROS " +
                                                        "WHERE Ativo = 1");
        }

        public Registros BuscaRegistros(int id)
        {
            return DbContext.Conexao.FindWithQuery<Registros>("SELECT * " +
                                                            "FROM REGISTROS " +
                                                            "WHERE id = ?", id);
        }

        public void InserirRegistro(Registros novoRegistro)
        {
            DbContext.Conexao.Insert(novoRegistro);
        }

        public void DeletaLogicaRegistro(int id)
        {
            DbContext.Conexao.Query<Animais>("UPDATE REGISTROS " +
                                                "SET ATIVO = 0 " +
                                                "WHERE id = ?", id);
        }

        public void DeletaLogicaAnimalRegistro(int id)
        {
            DbContext.Conexao.Query<Animais>("UPDATE REGISTROS " +
                                                "SET ATIVO = 0 " +
                                                "WHERE Animal_id = ?", id);
        }

        #endregion
   
        #region TABELA IMAGENS
        public void InserirImagem(Imagens novaImagem)
        {
            DbContext.Conexao.Insert(novaImagem);
        }

        public List<Imagens> BuscaListaImagens()
        {
            return DbContext.Conexao.Query<Imagens>("SELECT * " +
                                                    "FROM IMAGENS " +
                                                    "WHERE Ativo = 1");
        }
        #endregion

        #region MANIPULACAO NAS TABELAS REGISTROS E ANIMAIS
        public Animais BuscaNomeAnimal(int id)
        {
            return DbContext.Conexao.FindWithQuery<Animais>("SELECT * " +
                                                            "FROM ANIMAIS " +
                                                            "INNER JOIN REGISTROS " +
                                                            "ON ANIMAIS.id = REGISTROS.Animal_id " +
                                                            "WHERE REGISTROS.id =?", id);
        }
        #endregion
    }
}
