using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto // Criação da classe Produto 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }

        public double Total { get => Quantidade * Preco; } // Propriedade calculada para obter o total do produto

    }
}
