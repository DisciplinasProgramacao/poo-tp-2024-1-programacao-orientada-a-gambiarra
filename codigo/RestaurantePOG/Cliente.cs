using System;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando o cliente do restaurante.
    /// </summary>
    public class Cliente
    {
        private static int proximoId = 1; // Campo est�tico para controlar o pr�ximo ID
        private int id;
        private string nome;
        private int quantidadePessoa;

        public Cliente(string nome, int quantidadePessoa)
        {
            this.id = proximoId++; // Atribui o pr�ximo ID e depois incrementa
            this.nome = nome;
            this.quantidadePessoa = quantidadePessoa;
        }

        public int Id { get; internal set; }

        /// <summary>
        /// M�todo para solicitar uma reserva no restaurante.
        /// </summary>
        /// <param name="quantidadePessoa">Quantidade de pessoas no grupo</param>
        /// <returns>Objeto Requisicao representando a solicita��o de reserva</returns>
        public Requisicao solicitarReserva(int quantidadePessoa)
        {
            // Implementa��o do m�todo para solicitar reserva
            throw new NotImplementedException();
        }

       /// <summary>
       /// Retorna a lista de clientes cadastrados
       /// </summary>
       /// <returns>
       /// Id, Nome, N�mero de pessoas
       /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Id: " + id);
            sb.Append(" | Cliente: " + nome);
            sb.Append(" | Quantidade de pessoas: " + quantidadePessoa);

            return sb.ToString();
        }


       
    }
}

