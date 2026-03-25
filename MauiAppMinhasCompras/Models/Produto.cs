using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto // Criação da classe Produto 
    {
        string _descricao;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao
        {
            get => _descricao;

            set
            {
                if (value == null)
                {
                    throw new Exception("A descrição do produto é obrigatória!");
                }
                _descricao = value;
            }
        }
        public double Quantidade { get; set; }
        public double Preco { get; set; }

        public double Total { get => Quantidade * Preco; } // Propriedade calculada para obter o total do produto

        public string Categoria { get; set; } // Propriedade para armazenar a categoria do produto
    }
}