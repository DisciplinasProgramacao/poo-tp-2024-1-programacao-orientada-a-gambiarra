using System;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando o cliente do restaurante.
    /// </summary>
    public class Cliente {
        private string? nome;
        public Cliente(string nome) {
            this.nome = nome;
        }

       /// <summary>
       /// Retorna a lista de clientes cadastrados
       /// </summary>
       /// <returns>
       /// Nome do cliente
       /// </returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(" | Cliente: " + nome);
            return sb.ToString();
        }

        public string getNome()
        {
            return this.nome;
        }
      
    }
}

