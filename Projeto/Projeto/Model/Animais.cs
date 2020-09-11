using SQLite;
using System;
using Xamarin.Forms;

namespace Projeto.Model
{
    public class Animais
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Nome { get; set; }
        public DateTime Data_Nasc { get; set; }
        public string Cidade { get; set; }
        public string Especie { get; set; }
        public string Path { get; set; }

        [Ignore]
        public ImageSource Foto { get; set; }
        public int Ativo { get; set; }

    }
}
