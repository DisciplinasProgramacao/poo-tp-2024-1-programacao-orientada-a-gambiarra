using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando o cliente do restaurante
    /// </summary>
    public class Cliente
	{   
  		String nome;
		int quantidadePessoa;

        /// <summary>
        /// M�todo para solicitar uma reserva no restaurante
        /// </summary>
        /// <param name="quantidadePessoa">Quantidade de pessoas no grupo</param>
        /// <returns>Objeto Requisicao representando a solicita��o de reserva</returns>
        public Requisicao solicitarReserva(int quantidadePessoa)
		{
			throw new NotImplementedException();
		}
	}
}
