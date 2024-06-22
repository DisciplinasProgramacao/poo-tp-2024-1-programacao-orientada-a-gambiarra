using System;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>Classe representando o cliente do restaurante.</summary>
    public class Cliente {
        private string nome { get; set; }

        public Cliente(string nome) { this.nome = nome; }    

       /// <summary>Retorna o nome do Cliente</summary>
       /// <returns>String contendo o nome do cliente</returns>
        public string? getNome(){ return nome; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            return sb.Append(" | Cliente: " + nome).ToString();
        }  
    }
}

