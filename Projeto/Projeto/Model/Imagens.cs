using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Model
{
    public class Imagens
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int Animal_id { get; set; }
        public string Path { get; set; }
        public int Ativo { get; set; }
    }
}
