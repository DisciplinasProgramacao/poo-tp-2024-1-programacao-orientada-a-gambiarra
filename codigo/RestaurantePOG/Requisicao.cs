using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando uma requisição de atendimento no restaurante
    /// </summary>
    public class Requisicao
	{
		int id;
		Cliente cliente;
		DateTime entrada;
		DateTime saida;
		Mesa mesa;

        /// <summary>
        /// Método para adicionar uma mesa à requisição
        /// </summary>
        /// <returns>A mesa adicionada à requisição</returns>
        public Mesa addMesa()
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// Método para verificar se o atendimento da requisição foi encerrado
        /// </summary>
        /// <returns>True se o atendimento foi encerrado, False caso contrário</returns>
        public bool atendimentoEncerrado()
		{
			throw new NotImplementedException();
		}
	}
}
