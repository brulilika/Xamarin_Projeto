using SQLite;
using Xamarin.Forms;

namespace Projeto.Model
{
    public class Registros
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int Animal_id { get; set; } //ForeignKey com tabela Animais
        public string Titulo { get; set; }
        public string Registro { get; set; }
        public int Ativo { get; set; }
    }
}
