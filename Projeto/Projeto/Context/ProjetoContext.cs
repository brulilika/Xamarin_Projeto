using Projeto.Interface;
using Projeto.Model;
using SQLite;
using Xamarin.Forms;

namespace Projeto.Context
{
    public class ProjetoContext
    {
        private static SQLiteConnection _sqLiteConnection;
        public static ProjetoContext _lazy;

        public static ProjetoContext Current
        {
            get
            {
                if (_lazy == null)
                    _lazy = new ProjetoContext();
                return _lazy;
            }
        }
        private ProjetoContext()
        {
            _sqLiteConnection = new SQLiteConnection(DependencyService.Get<IDbPath>().GetDbPath());

            //Instanciação das Tabelas

            _sqLiteConnection.CreateTable<Animais>();
            _sqLiteConnection.CreateTable<Registros>();
            _sqLiteConnection.CreateTable<Imagens>();
        }

        public SQLiteConnection Conexao
        {
            get { return _sqLiteConnection; }
            set { _sqLiteConnection = value; }
        }
    }
}
